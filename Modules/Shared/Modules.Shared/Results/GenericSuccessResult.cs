namespace Modules.Shared.Results;

public record GenericSuccessResult(string Message) : Result<string>(true, Message);