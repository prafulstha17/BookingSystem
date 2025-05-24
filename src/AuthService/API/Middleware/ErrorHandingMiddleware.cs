using Application.Common.Exceptions;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json;

namespace Api.Middleware;

public class ErrorHandingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (UnauthorizedAccessException)
        {
            var response = new BaseResponse<string>
            {
                Code = "401",
                Message = "Unauthorized access",
                Status = "Error",
                Data = null
            };
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json"; // Set content type
            await context.Response.WriteAsync(JsonSerializer.Serialize(response)); // Use JsonSerializer
        }
        catch (AccessDeniedException exception)
        {
            var response = new BaseResponse<string>
            {
                Code = "403",
                Message = exception.Message,
                Status = "Error",
                Data = null
            };
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json"; // Set content type
            await context.Response.WriteAsync(JsonSerializer.Serialize(response)); // Use JsonSerializer
        }
        catch (AlreadyExistException exception)
        {
            var response = new BaseResponse<string>
            {
                Code = "409",
                Message = exception.Message,
                Status = "Error",
                Data = null
            };
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            context.Response.ContentType = "application/json"; // Set content type
            await context.Response.WriteAsync(JsonSerializer.Serialize(response)); // Use JsonSerializer
        }
        catch (UnauthorizedException exception)
        {
            var response = new BaseResponse<string>
            {
                Code = "401",
                Message = exception.Message,
                Status = "Error",
                Data = null
            };
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json"; // Set content type
            await context.Response.WriteAsync(JsonSerializer.Serialize(response)); // Use JsonSerializer
        }
        catch (DbUpdateException dbEx) when (dbEx.InnerException is PostgresException postgresEx)
        {
            var response = new BaseResponse<string>
            {
                Code = "001",
                Message = postgresEx.Message.ToString(),
                Status = "Error",
                Data = null
            };
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json"; // Set content type
            await context.Response.WriteAsync(JsonSerializer.Serialize(response)); // Use JsonSerializer
        }
        catch (Exception ex)
        {
            var response = new BaseResponse<string>
            {
                Code = "500",
                Message = "Something went wrong",
                Status = "Error",
                Data = null
            };
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json"; // Set content type
            await context.Response.WriteAsync(JsonSerializer.Serialize(response)); // Use JsonSerializer
        }
    }
}
