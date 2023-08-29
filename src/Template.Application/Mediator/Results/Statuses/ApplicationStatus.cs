using System.Net;

namespace Template.Application.Mediator.Results.Statuses;
public sealed record ApplicationStatus
{
    public int Code { get; }
    public string Message { get; }

    private ApplicationStatus(int Code, string Message)
    {
        this.Code = Code;
        this.Message = Message;
    }

    public static ApplicationStatus Ok = new((int)HttpStatusCode.OK, "Success");
    public static ApplicationStatus InternalServerError = new((int)HttpStatusCode.InternalServerError, "InternalServerError");
    public static ApplicationStatus BadRequest = new((int)HttpStatusCode.BadRequest, "BadRequest");
    public static ApplicationStatus NotFound = new((int)HttpStatusCode.NotFound, "NotFound");
    public static ApplicationStatus Unauthorized = new((int)HttpStatusCode.Unauthorized, "Unauthorized");
    public static ApplicationStatus Forbidden = new((int)HttpStatusCode.Forbidden, "Forbidden");

    public static ApplicationStatus Custom(int code, string message) => new(code, message);
    public bool Successful => Code == Ok.Code;
};
