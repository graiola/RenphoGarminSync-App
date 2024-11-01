using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RenphoGarminSync.Garmin.Auth.Utility
{
    public static class PathEscaper
    {
        const string ESCAPE_CHAR = "%";
        public static string Escape(string path)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            var escapedRegexContent = Regex.Escape($"{ESCAPE_CHAR}{invalidChars}");
            var escaper = new Regex($"[{escapedRegexContent}]");
            return escaper.Replace(path,
                m => ESCAPE_CHAR + ((short)(m.Value[0])).ToString("X4"));
        }

        public static string Unescape(string path)
        {
            var unescaper = new Regex($"{Regex.Escape(ESCAPE_CHAR)}{"([0-9A-Z]{4})"}");
            return unescaper.Replace(path,
                m => ((char)Convert.ToInt16(m.Groups[1].Value, 16)).ToString());
        }
    }
}
