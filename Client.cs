using System;
using System.Net;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Screeps.Network.API;
using Screeps.Network.API.Auth;
using Screeps.Network.API.User;

namespace Screeps.Network;

public class Client
{
    private const string ContentType = "application/json; charset=utf-8";

    private readonly WebClient _web;

    public Client()
    {
        _web = new WebClient();

        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };
    }
    public Client(string token) : this() => SetToken(token);
    public Client(string email, string password) => SetEmailPasswordAuth(email, password);

    ~Client() => _web.Dispose();

    public string Protocol { get; set; } = "https";
    public string Host { get; set; } = "screeps.com";
    public ServerType ServerType { get; set; }

    public string BaseURL => $"{Protocol}://{Host}/{ServerType.GetAPIPath()}/";

    public void SetEmailPasswordAuth(string email, string password)
    {
        var data = System.Text.Encoding.UTF8.GetBytes($"{email}:{password}");
        var base64 = Convert.ToBase64String(data);

        _web.Headers["Authorization"] = $"Basic {base64}";
    }
    public void SetToken(string token)
    {
        _web.Headers["X-Token"] = token;
    }
    public SignInResponse SignIn(string email, string password)
    {
        return SendRequest<SignInResponse>("auth/signin", new SignInRequest
        {
            Email = email,
            Password = password
        });
    }
    public AccountResponse GetAccount()
    {
        return GetResponse<AccountResponse>("auth/me");
    }
    public string GetUsername()
    {
        return GetResponse<NameResponse>("user/name").Username;
    }
    public CodeResponse UploadCode(CodeRequest code)
    {
        return SendRequest<CodeResponse>("user/code", code);
    }
    public bool IsValidToken()
    {
        try
        {
            GetResponse("user/name");
            return true;
        }
        catch (WebException ex)
        {
            using var response = ex.Response as HttpWebResponse;

            if (response == null) throw;
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return false;

            throw;
        }
    }

    private T SendRequest<T>(string uri, object data)
    {
        var rawResponse = SendRequest(uri, JsonConvert.SerializeObject(data));
        var responseObject = JsonConvert.DeserializeObject<T>(rawResponse);

        return responseObject;
    }
    private string SendRequest(string uri, string data)
    {
        ResetWebClient();
        
        return _web.UploadString(uri, data);
    }

    private T GetResponse<T>(string uri)
    {
        var rawResponse = GetResponse(uri);
        var responseObject = JsonConvert.DeserializeObject<T>(rawResponse);

        return responseObject;
    }
    private string GetResponse(string uri)
    {
        ResetWebClient();

        return _web.DownloadString(uri);
    }

    private void ResetWebClient()
    {
        _web.BaseAddress = BaseURL;
        _web.Headers[HttpRequestHeader.ContentType] = ContentType;
    }
}