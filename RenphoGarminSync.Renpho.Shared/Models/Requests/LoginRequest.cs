using System.Text.Json.Serialization;

namespace RenphoGarminSync.Renpho.Shared.Models.Requests
{

    public class LoginRequest
    {
        [JsonPropertyName("questionnaire")]
        public required Questionnaire Questionnaire { get; set; }

        [JsonPropertyName("login")]
        public required Login Login { get; set; }

        [JsonPropertyName("bindingList")]
        public required Bindinglist BindingList { get; set; }
    }

    public class Questionnaire
    {
    }

    public class Login
    {
        [JsonPropertyName("password")]
        public required string Password { get; set; }

        [JsonPropertyName("areaCode")]
        public required string AreaCode { get; set; }

        [JsonPropertyName("appRevision")]
        public required string AppRevision { get; set; }

        [JsonPropertyName("cellphoneType")]
        public required string CellphoneType { get; set; }

        [JsonPropertyName("systemType")]
        public required string SystemType { get; set; }

        [JsonPropertyName("email")]
        public required string Email { get; set; }

        [JsonPropertyName("platform")]
        public required string Platform { get; set; }
    }

    public class Bindinglist
    {
        [JsonPropertyName("deviceTypes")]
        public required string[] DeviceTypes { get; set; }
    }

}
