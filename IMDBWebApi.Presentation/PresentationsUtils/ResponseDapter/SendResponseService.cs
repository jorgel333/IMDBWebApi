using IMDBWebApi.Application.Extension;
using Microsoft.AspNetCore.Mvc;
using FluentResults;

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

    public static IResult CreatedAtRoute<T>(Result<T> result, string route, int idd)
    {
        if (result.IsSuccess)
            return Results.CreatedAtRoute(route, new { id = idd }, result.Value);
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
        return Results.Json(new ProblemDetails
        {
            Status = 500,
            Title = "Unknown error"
        }, statusCode: 500);
    }
}
