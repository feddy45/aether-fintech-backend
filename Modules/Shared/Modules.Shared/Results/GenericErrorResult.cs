namespace Modules.Shared.Results;

public record GenericErrorResult(string Message) : ErrorResult(Message);