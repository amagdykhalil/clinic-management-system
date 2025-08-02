using Ardalis.Result;

namespace Application.Abstractions.Messaging;

/// <summary>
/// Represents a command that returns no specific response data.
/// </summary>
public interface ICommand : IRequest<Result>;

/// <summary>
/// Represents a command that returns a specific response type.
/// </summary>
/// <typeparam name="TResponse">The type of response data returned by the command.</typeparam>
public interface ICommand<TResponse> : IRequest<Result<TResponse>>;



