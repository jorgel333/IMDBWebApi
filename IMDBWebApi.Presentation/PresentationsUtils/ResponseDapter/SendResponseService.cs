using IMDBWebApi.Application.Errors;
using Microsoft.AspNetCore.Mvc;
using FluentResults;

namespace IMDBWebApi.Presentation.PresentationsUtils.ResponseDapter;

public static class SendResponseService
{
    public static IResult SendResponse<T>(Result<T> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Value);

        return HandleError(result.ToResult());
    }

    public static IResult SendResponse(Result result)
    {
        if (result.IsSuccess)
            return Results.NoContent();

        return HandleError(result);
    }

    public static IResult CreatedAtRoute<T>(Result<T> result, string route, object routeValues, T? value)
    {
        if (result.IsSuccess)
            return Results.CreatedAtRoute(route, routeValues, value);

        return HandleError(result.ToResult());
    }

    private static IResult HandleError(Result result)
    {
        var error = result.Errors.FirstOrDefault();

        if (error is ValidationError validationError)
        {
            return Results.Json(new ProblemDetails
            {
                Status = 400,
                Title = "Validation Error",
                Detail = validationError.Message,
                Extensions = { { nameof(validationError.ErrorMessageDictionary), validationError.ErrorMessageDictionary } }
            }, statusCode: 400);
        }

        if (error is ApplicationNotFoundError applicationNotFoundError)
        {
            return Results.Json(new ProblemDetails
            {
                Status = 404,
                Title = "The request item has not found",
                Detail = applicationNotFoundError.Message
            }, statusCode: 404);
        }

        if (error is ApplicationError applicationError)
        {
            return Results.Json(new ProblemDetails
            {
                Status = 403,
                Title = "The server has refused the request",
                Detail = applicationError.Message
            }, statusCode: 403);
        }

        return Results.Json(new ProblemDetails
        {
            Status = 500,
            Title = "Unknown error"
        }, statusCode: 500);
    }
}
