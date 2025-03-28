using System.Text.Json.Serialization;

namespace Managment.Domain.Abstractions.Base;

public class Result<T>(T? data, string message, int statusCode = 200)
{
    [JsonIgnore] public int StatusCode { get; private set; } = statusCode;
    public T? Data { get; set; } = data;
    public string Message { get; set; } = message;

    public static Result<T> Success(T? data, string message = "Sucesso", int statusCode = 200) 
        => new(data, message, statusCode);
    
    public static Result<T> Failure(string message, int statusCode = 400) 
        => new(default, message, statusCode);
}