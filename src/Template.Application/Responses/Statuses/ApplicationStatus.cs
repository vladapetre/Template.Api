namespace Template.Application.Responses.Statuses;
public sealed record ApplicationStatus(int Code, string Message)
{
    public static ApplicationStatus Ok = new(200, "Success");
    public static ApplicationStatus InternalServerError = new(500, "InternalServerError");
    public static ApplicationStatus BadRequest = new(500, "BadRequest");
    public static ApplicationStatus NotFound = new(500, "NotFound");
    public static ApplicationStatus Unauthorized = new(500, "Unauthorized");
    public static ApplicationStatus Forbidden = new(500, "Forbidden");

    public bool Successful => this == Ok;
};
