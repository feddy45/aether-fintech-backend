namespace Modules.Shared.Results;

public abstract record Result<T>(bool IsSuccess, T Data);