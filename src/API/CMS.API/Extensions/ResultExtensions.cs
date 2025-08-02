namespace CMS.API.Extensions;

internal static class ResultExtensions
{
    /// <summary>
    /// Converts an Result object to an IActionResult.
    /// </summary>
    /// <param name="result">The ApiResponse object to convert.</param>
    /// <returns>An IActionResult representing the ApiResponse object.</returns>
    public static IActionResult ToActionResult(this Result result)
    {

        return result.Status switch
        {
            ResultStatus.Ok => new OkObjectResult(ApiResponse.Ok(result.SuccessMessage)),
            ResultStatus.Created => new CreatedResult(
                result.Location, ApiResponse.Created(result.SuccessMessage)),
            _ => result.ToHttpNonSuccessResult()
        };
    }


    /// <summary>
    /// Converts an Result{T} to an IActionResult.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="response">The result to convert.</param>
    /// <returns>An IActionResult representing the result.</returns>
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        // If the result is a string and looks like a URL, redirect
        if (typeof(T) == typeof(string) && result.Value is string strValue && !string.IsNullOrEmpty(strValue) && (strValue.StartsWith("http://") || strValue.StartsWith("https://")))
        {
            return new RedirectResult(strValue);
        }

        return result.Status switch
        {
            ResultStatus.Ok => new OkObjectResult(ApiResponse<T>.Ok(result.Value, result.SuccessMessage)),
            ResultStatus.Created => new CreatedResult(
                result.Location, ApiResponse<T>.Created(result.Value, result.SuccessMessage)),
            _ => result.ToHttpNonSuccessResult()
        };
    }


    private static IActionResult ToHttpNonSuccessResult(this Ardalis.Result.IResult result)
    {
        var errors = result.Errors.Select(error => new ApiErrorResponse(error)).ToList();

        return result.Status switch
        {
            ResultStatus.Error => new BadRequestObjectResult(ApiResponse.BadRequest(errors)),
            ResultStatus.Unauthorized => new UnauthorizedObjectResult(ApiResponse.Unauthorized(errors)),
            ResultStatus.Forbidden => new ForbidResult(),
            ResultStatus.NotFound => new NotFoundObjectResult(ApiResponse.NotFound(errors)),
            ResultStatus.NoContent => new NoContentResult(),
            _ => new BadRequestObjectResult(ApiResponse.BadRequest(errors)),
        };
    }
}



