using HOLE.Scripts.Tarkov_Stuff;
using HOLE.Tarkov_Stuff;

namespace HOLE.Scripts
{
    internal class Profile
    {
        public PlayerInfo PlayerInfo { get; private set; }
        public Characters Characters { get; private set; }
    }

    public struct PlayerInfo
    {
        public string id;
        public string username; 
        public string password;
        public string wipe;
        public string edition;
    }
    public struct Characters
    {
        public Character pmc { get; }
        public Character scav { get; }
    }

    public struct Character 
    {
        public Encyclopedia? Encyclopedia { get; }
        public Health Health { get; }
    }
}
