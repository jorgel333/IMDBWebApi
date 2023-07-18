using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.MoviesManagment.GetNextReleases;

public record GetNextReleasesQuery() : IRequest<Result<IEnumerable<IGrouping<DateTime, GetNextReleasesQueryResponse>>>>;
