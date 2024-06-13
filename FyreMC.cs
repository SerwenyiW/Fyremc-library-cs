using System.Net;
using System.Text.Json;

namespace Fyremc_libary
{
    public class PlayerInfo
    {
        public string username { get; set; }
        public string skin { get; set; }
        public List<string> ranks { get; set; }
        public bool premium { get; set; }
        public GuildInfo guild { get; set; }
    }
    public class GuildInfo
    {
        public string name { get; set; }
        public int xp { get; set; }
        public int level { get; set; }
        public int rank { get; set; }
        public List<string> members { get; set; }
    }


    public static partial class FyreMC
    {
        private static string playerApi = "https://account.fyremc.hu/api/player/";
        private static string guildApi = "https://account.fyremc.hu/api/guild/";
        static WebClient wb = new WebClient();

        public static string getRawPlayerApi()
        {
            string jsonApi = wb.DownloadString(playerApi);
            return jsonApi;
        }

        public static PlayerInfo getPlayer() {
            string jsonApi = wb.DownloadString(playerApi);
            var jsonObject = JsonSerializer.Deserialize<dynamic>(jsonApi);
            var player = new PlayerInfo
            {
            username = jsonObject["data"]["username"],
            skin = jsonObject["data"]["skin"],
            ranks = jsonObject["data"]["ranks"].ToObject<List<string>>(),
            premium = jsonObject["data"]["premium"],
            guild = jsonObject["data"]["guild"]
            };
            return player;
        }

        public static GuildInfo getGuild()
        {
            string jsonApi = wb.DownloadString(guildApi);
            var jsonObject = JsonSerializer.Deserialize<dynamic>(jsonApi);
            var guild = new GuildInfo
            {
                name = jsonObject["data"]["name"],
                level = jsonObject["data"]["level"],
                xp = jsonObject["data"]["xp"],
                rank = jsonObject["data"]["rank"],
                members = jsonObject["data"]["members"].ToObject<List<string>>()
            };
            return guild;
        }
    }
}
