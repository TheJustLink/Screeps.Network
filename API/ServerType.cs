using System;

namespace ScreepsNetworkAPI.API
{
    public enum ServerType : byte
    {
        Persistent,
        PTR,
        Season
    }

    public static class ServerTypeExtensions
    {
        public static string GetAPIPath(this ServerType serverType)
        {
            switch (serverType)
            {
                case ServerType.Persistent: return "api";
                case ServerType.PTR: return "ptr/api";
                case ServerType.Season: return "season/api";
                default: throw new ArgumentOutOfRangeException(nameof(serverType));
            }
        }
    }
}