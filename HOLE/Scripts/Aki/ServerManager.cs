/* ServerManager.cs
 * License: NCSA Open Source License
 * 
 * Copyright: Merijn Hendriks
 * AUTHORS:
 * Merijn Hendriks
 */


using Aki.Launcher;
using Aki.Launcher.MiniCommon;
using Aki.Launcher.Models.Aki;
using HOLE.Scripts;

namespace HOLE.Scripts.Aki
{
    public class ServerManager(AkiInstance instance)
    {
        public readonly AkiInstance Instance = instance;
        public Request Request => Instance.Request;
        public ServerInfo? SelectedServer { get; private set; } = null;
        //public RequestHandler RequestHandler { get; private set; } = new();

        public bool PingServer()
        {
            string json = "";

            try
            {
                json = RequestHandler.SendPing(Request);

                if (json != null) return true;
            }
            catch
            {
                return false;
            }

            return false;
        }

        public string GetVersion()
        {
            try
            {
                string json = RequestHandler.RequestServerVersion(Request);

                return Json.Deserialize<string>(json);
            }
            catch
            {
                return "";
            }
        }

        public string GetCompatibleGameVersion()
        {
            try
            {
                string json = RequestHandler.RequestCompatibleGameVersion(Request);

                return Json.Deserialize<string>(json);
            }
            catch
            {
                return "";
            }
        }

        public Dictionary<string, AkiServerModInfo> GetLoadedServerMods()
        {
            try
            {
                string json = RequestHandler.RequestLoadedServerMods(Request);

                return Json.Deserialize<Dictionary<string, AkiServerModInfo>>(json);
            }
            catch
            {
                return new Dictionary<string, AkiServerModInfo>();
            }
        }

        public AkiProfileModInfo[] GetProfileMods()
        {
            try
            {
                string json = RequestHandler.RequestProfileMods(Request);

                return Json.Deserialize<AkiProfileModInfo[]>(json);
            }
            catch
            {
                return new AkiProfileModInfo[] { };
            }
        }

        public bool LoadServer(string backendUrl)
        {
            string json = "";

            try
            {
                RequestHandler.ChangeBackendUrl(Request, backendUrl);
                json = RequestHandler.RequestConnect(Request);
                SelectedServer = Json.Deserialize<ServerInfo>(json);
            }
            catch
            {
                SelectedServer = null;
                return false;
            }

            return true;
        }

        public async Task<bool> LoadDefaultServerAsync(string server)
        {
            return await Task.Run(() => LoadServer(server));
        }
    }
}
