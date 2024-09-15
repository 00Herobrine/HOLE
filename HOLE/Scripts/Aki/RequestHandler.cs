/* RequestHandler.cs
 * License: NCSA Open Source License
 * 
 * Copyright: Merijn Hendriks
 * AUTHORS:
 * Merijn Hendriks
 */


using Aki.Launcher;

/* RequestHandler.cs
 * License: NCSA Open Source License
 * 
 * Copyright: Merijn Hendriks
 * AUTHORS:
 * Merijn Hendriks
 */


using Aki.Launcher.MiniCommon;

namespace HOLE.Scripts.Aki
{
    public static class RequestHandler
    {
        public static string GetBackendUrl(Request request)
        {
            return request.RemoteEndPoint;
        }

        public static void ChangeBackendUrl(Request request, string remoteEndPoint)
        {
            request.RemoteEndPoint = remoteEndPoint;
        }

        public static void ChangeSession(Request request, string session)
        {
            request.Session = session;
        }

        public static string RequestConnect(Request request)
        {
            return request.GetJson("/launcher/server/connect");
        }

        public static string RequestLogin(Request request, LoginRequestData data)
        {
            return request.PostJson("/launcher/profile/login", Json.Serialize(data));
        }

        public static string RequestRegister(Request request, RegisterRequestData data)
        {
            return request.PostJson("/launcher/profile/register", Json.Serialize(data));
        }

        public static string RequestRemove(Request request, LoginRequestData data)
        {
            return request.PostJson("/launcher/profile/remove", Json.Serialize(data));
        }

        public static string RequestAccount(Request request, LoginRequestData data)
        {
            return request.PostJson("/launcher/profile/get", Json.Serialize(data));
        }

        public static string RequestProfileInfo(Request request, LoginRequestData data)
        {
            return request.PostJson("/launcher/profile/info", Json.Serialize(data));
        }

        public static string RequestExistingProfiles(Request request)
        {
            return request.GetJson("/launcher/profiles");
        }

        public static string RequestChangeUsername(Request request, ChangeRequestData data)
        {
            return request.PostJson("/launcher/profile/change/username", Json.Serialize(data));
        }

        public static string RequestChangePassword(Request request, ChangeRequestData data)
        {
            return request.PostJson("/launcher/profile/change/password", Json.Serialize(data));
        }

        public static string RequestWipe(Request request, RegisterRequestData data)
        {
            return request.PostJson("/launcher/profile/change/wipe", Json.Serialize(data));
        }

        public static string SendPing(Request request)
        {
            return request.GetJson("/launcher/ping");
        }

        public static string RequestServerVersion(Request request)
        {
            return request.GetJson("/launcher/server/version");
        }

        public static string RequestCompatibleGameVersion(Request request)
        {
            return request.GetJson("/launcher/profile/compatibleTarkovVersion");
        }

        public static string RequestLoadedServerMods(Request request)
        {
            return request.GetJson("/launcher/server/loadedServerMods");
        }

        public static string RequestProfileMods(Request request)
        {
            return request.GetJson("/launcher/server/serverModsUsedByProfile");
        }
    }
}
