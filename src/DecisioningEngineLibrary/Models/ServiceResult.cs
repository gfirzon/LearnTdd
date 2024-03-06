using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace DecisioningEngine.Models;

[ExcludeFromCodeCoverage]
public class ServiceResult //put in shared services lib
{
    [JsonIgnore]
    public OperationStatus Status { get; set; }

    public List<string> Notes { get; set; }

    public ServiceResult()
    {
        Status = new OperationStatus(Severity.Success);
        Notes = new List<string>();
    }

    public bool IsError => Status.Severity == Severity.Error;

    public bool IsSuccess => Status.Severity == Severity.Success;

    public string StatusMessage => Status.Message;
}

[ExcludeFromCodeCoverage]
public class ServiceResult<T> : ServiceResult
{
    public ServiceResult() : base() { }

    /// <summary>
    /// Generic Data stored in this Object
    /// </summary>
    public T? Data { get; set; }
}

public enum Severity
{
    Success,
    Error,
    Warning
}

[ExcludeFromCodeCoverage]
public class OperationStatus
{
    public Severity Severity { get; set; }
    public string Message { get; set; }

    public OperationStatus()
    {
        Severity = Severity.Success;
        Message = null!;
    }

    public OperationStatus(Severity severity)
    {
        Severity = severity;
        Message = null!;
    }

    public OperationStatus(Severity severity, string errorMessage)
    {
        Severity = severity;
        Message = errorMessage;
    }
}
