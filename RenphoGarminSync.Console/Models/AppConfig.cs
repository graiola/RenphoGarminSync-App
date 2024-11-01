using RenphoGarminSync.Garmin.Shared.Models;
using RenphoGarminSync.Renpho.Shared.Models;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace RenphoGarminSync.Console.Models
{
    public class AppConfig
    {
        [JsonPropertyName("Garmin")]
        public GarminConfig Garmin { get; set; }

        [JsonPropertyName("Renpho")]
        public RenphoConfig Renpho { get; set; }

        [JsonPropertyName("General")]
        public GeneralConfig General { get; set; }
    }

    public class GeneralConfig
    {
        [JsonPropertyName("UseDefaultCachePath")]
        public bool UseDefaultCachePath { get; set; }

        [JsonPropertyName("CustomCachePath")]
        public string CustomCachePath { get; set; }

        [JsonIgnore]
        public string CachePath
        {
            get
            {
                if (UseDefaultCachePath)
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RenphoGarminSync");
                    
                return CustomCachePath;
            }
        }
    }
}
