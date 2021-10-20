using System;

namespace Screeps.Network.API
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
            return serverType switch
            {
                ServerType.Persistent => "api",
                ServerType.PTR => "ptr/api",
                ServerType.Season => "season/api",

                _ => throw new ArgumentOutOfRangeException(nameof(serverType)),
            };
        }
    }
}