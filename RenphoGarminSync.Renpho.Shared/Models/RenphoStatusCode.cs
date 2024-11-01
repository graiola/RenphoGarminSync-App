namespace RenphoGarminSync.Renpho.Shared.Models
{
    public enum RenphoStatusCode : int
    {
        // General code used for any error that happens during request, only use if for api exception
        CUSTOM_REQUEST_FAILED = -1000,
        CUSTOM_AUTH_FAILED = -1001,

        Success = 101,
        Unauthorized = 401,
        Forbidden = 403,

        BadGatewayMaybe = 502, // Renpho application continues with the processing of requests if 502 is returned, which is weird

        // Service errors
        ServiceException1 = -109,
        ServiceException2 = -1,
        ServiceServerError = 500,
        ServiceException3 = -115,
        ServiceDecryptionFailed = -114,
        ServiceException4 = -113,
        ServiceTooManyRequestsMaybe = 429,
        ServicePasswordError = 104,

        SomeBindingException = -100,

        PasswordFormatError = 1004,
        PasswordResetFailed = 118,
        PasswordPreviousWrong = 116,

        UserNotExists = 50005,

        // Email verification codes
        EmailVerifyCodeExpired = 112,
        EmailVerifyError = 111,
        EmailVerifyCodeMax = 1015,
        EmailFormatError = 1009,
        EmailDomainError = 140,
        EmailNotRegistered = 106,
        EmailAlreadyRegistered = 102,

        ErrorAddedRepeatedly = 108,

        // Custom food codes
        AddCustomerFoodNameRepeated = 30001,

        // Possibly food scale related codes
        EmailOrPasswordIncorrect = 20001,
        AccountBound = 20002,
        DataSynchronizationLimitReached = 20003,
        AccountDoesntExist = 20004,

    }
}
