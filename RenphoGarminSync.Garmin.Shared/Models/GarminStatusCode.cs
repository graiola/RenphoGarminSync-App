namespace RenphoGarminSync.Garmin.Shared.Models
{
    public enum GarminStatusCode
    {
        None = 0,
        Forbidden = 1,
        TooManyRequests = 2,
        Unauthorized = 3,

        FailedPriorToCredentialsUsed = 10,
        InvalidCredentials = 11,
        OAuth1TokenInvalid = 12,
        ServiceTicketInvalid = 13,

        UnexpectedMfa = 20,
        FailedPriorToMfaUsed = 21,
        InvalidMfaCode = 22,
        MfaNotFinished = 23,
        MfaRequired = 23,

        AuthAppearedSuccessful = 30,
    }
}
