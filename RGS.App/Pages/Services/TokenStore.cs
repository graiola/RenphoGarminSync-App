using Microsoft.Maui.Storage;

namespace RGS.App.Services;

// Simple wrapper over MAUI SecureStorage.
// Android uses the system keystore behind the scenes.
public class TokenStore
{
    const string KeyRenpho = "rgs.renpho.token";
    const string KeyGarmin = "rgs.garmin.token";

    public Task SaveRenphoAsync(string json) => SecureStorage.SetAsync(KeyRenpho, json);
    public Task<string?> GetRenphoAsync() => SecureStorage.GetAsync(KeyRenpho);

    public Task SaveGarminAsync(string json) => SecureStorage.SetAsync(KeyGarmin, json);
    public Task<string?> GetGarminAsync() => SecureStorage.GetAsync(KeyGarmin);
}

