using System.Net;

namespace Template.Application.Mediator.Responses.Statuses;
public sealed record ApplicationStatus(int Code, string Message)
{
    public static ApplicationStatus Ok = new((int)HttpStatusCode.OK, "Success");
    public static ApplicationStatus InternalServerError = new((int)HttpStatusCode.InternalServerError, "InternalServerError");
    public static ApplicationStatus BadRequest = new((int)HttpStatusCode.BadRequest, "BadRequest");
    public static ApplicationStatus NotFound = new((int)HttpStatusCode.NotFound, "NotFound");
    public static ApplicationStatus Unauthorized = new((int)HttpStatusCode.Unauthorized, "Unauthorized");
    public static ApplicationStatus Forbidden = new((int)HttpStatusCode.Forbidden, "Forbidden");

    public bool Successful => this == Ok;
};
