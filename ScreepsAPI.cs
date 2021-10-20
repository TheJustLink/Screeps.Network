using System.Net;
using Newtonsoft.Json;

using ScreepsNetworkAPI.API;
using ScreepsNetworkAPI.API.Auth;
using ScreepsNetworkAPI.API.User;

namespace ScreepsNetworkAPI
{
    public class ScreepsAPI
    {
        private const string ContentType = "application/json; charset=utf-8";

        public string Protocol { get; set; } = "https";
        public string Host { get; set; } = "screeps.com";
        public ServerType ServerType { get; set; }

        public string BaseURL
            => $"{Protocol}://{Host}/{ServerType.GetAPIPath()}/";

        private readonly WebClient Web;

        public ScreepsAPI(string token)
        {
            Web = new WebClient();
            Web.Headers["X-Token"] = token;
        }
        ~ScreepsAPI() => Web.Dispose();

        public CodeResponse UploadCode(CodeRequest code)
        {
            return SendRequest<CodeResponse>("user/code", code);
        }
        public AccountResponse GetAccount()
        {
            return GetResponse<AccountResponse>("auth/me");
        }
        public string GetUsername()
        {
            return GetResponse<NameResponse>("user/name").Username;
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
                using (var response = ex.Response as HttpWebResponse)
                {
                    if (response == null) throw ex;
                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                        return false;
                }

                throw ex;
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

            return Web.UploadString(uri, data);
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

            return Web.DownloadString(uri);
        }

        private void ResetWebClient()
        {
            Web.BaseAddress = BaseURL;
            Web.Headers[HttpRequestHeader.ContentType] = ContentType;
        }
    }
}