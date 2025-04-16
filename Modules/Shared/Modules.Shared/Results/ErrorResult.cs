namespace Modules.Shared.Results;

public abstract record ErrorResult(string Message) : Result<string>(false, Message);