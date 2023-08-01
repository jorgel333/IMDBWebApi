using Microsoft.AspNetCore.Mvc;
using FluentResults;
using IMDBWebApi.Application.Errors;

namespace IMDBWebApi.Presentation.PresentationsUtils.ResponseDapter;

public static class SendResponseService
{
    public static IResult SendResponse<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Results.Ok(result.Value);
        }
        return SendResponse(result.ToResult());
    }

    public static IResult CreatedAtRoute<T>(Result<T> result, string route, int valueId)
    {
        if (result.IsSuccess)
            return Results.CreatedAtRoute(route, new { id = valueId }, result.Value);
        return SendResponse(result.ToResult());
    }

    public static IResult SendResponse(Result result)
    {
        if (result.IsSuccess)
        {
            return Results.NoContent();
        }

        if (result.Errors.FirstOrDefault() is ValidationError validationError)
        {
            return Results.Json(new ProblemDetails
            {
                Status = 400,
                Title = "Validation Error",
                Detail = validationError.Message,
                Extensions = { { nameof(validationError.ErrorMessageDictionary), validationError.ErrorMessageDictionary } }
            }, statusCode: 400);
        }

        if (result.Errors.FirstOrDefault() is ApplicationNotFoundError applicationNotFoundError)
        {
            return Results.Json(new ProblemDetails
            {
                Status = 404,
                Title = "The request item has not found",
                Detail = applicationNotFoundError.Message
            }, statusCode: 404);
        }

        if (result.Errors.FirstOrDefault() is ApplicationError applicationError)
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
