using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Entities;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.AssessmentRecordManagment.RegisterEvaluation;

public class RegisterEvaluationCommandHandler : IRequestHandler<RegisterEvaluationCommand, Result<RegisterEvaluationCommandResponse>>
{
    private readonly IAssessmentRecordRepository _assessmentRecordRepository;
    private readonly IUserRepository _commonUserRepository;
    private readonly IMovieRepository _movieRepository;
    private readonly IUnityOfWork _unityOfWork;

    public RegisterEvaluationCommandHandler(IAssessmentRecordRepository assessmentRecordRepository, IMovieRepository movieRepository,
        IUnityOfWork unityOfWork, IUserRepository commonUserRepository)
    {
        _assessmentRecordRepository = assessmentRecordRepository;
        _movieRepository = movieRepository;
        _unityOfWork = unityOfWork;
        _commonUserRepository = commonUserRepository;
    }

    public async Task<Result<RegisterEvaluationCommandResponse>> Handle(RegisterEvaluationCommand request, CancellationToken cancellationToken)
    {
        var isUniqueAssessmentRecord = await _assessmentRecordRepository.IsUniqueAssessmentRecord(request.CommonUserId, request.MovieId, cancellationToken);
        var movie = await _movieRepository.GetByIdIncludeAssessment(request.MovieId, cancellationToken);
        var commonUser = await _commonUserRepository.GetByIdAsync(request.CommonUserId, cancellationToken);

        if (isUniqueAssessmentRecord is false)
            return Result.Fail(new ApplicationError("Assessment already registred."));

        if (movie is null)
            return Result.Fail(new ApplicationNotFoundError("Movie not Found"));

        if (commonUser is null)
            return Result.Fail(new ApplicationNotFoundError("User not found."));

        var rating = new AssessmentRecord(request.Rate, request.CommonUserId, request.MovieId);
        _assessmentRecordRepository.Create(rating);
        movie.AttRatingAverage();
        _movieRepository.Update(movie);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(new RegisterEvaluationCommandResponse(rating.Id));
    }
}
