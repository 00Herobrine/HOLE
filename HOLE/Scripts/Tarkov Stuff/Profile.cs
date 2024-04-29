using HOLE.Scripts.Tarkov_Stuff;
using HOLE.Tarkov_Stuff;

namespace HOLE.Scripts
{
    public class Profile
    {
        public PlayerInfo Info { get; private set; }
        public Characters Characters { get; private set; }
        public string[] Suits { get; private set; } = [];
        public AkiInfo Aki { get; private set; }
        public VitalityInfo Vitality { get; private set; }
        public RaidInfo InRaid { get; private set; }
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
        public Encyclopedia? Encyclopedia { get; set; }
        public Health Health { get; set; }
        public Hideout Hideout { get; set; }
        public CharacterInfo Info { get; set; }
        public RagfairInfo RagfairInfo { get; set; }
    }
    public struct CharacterInfo
    {
        public int AccountType { get; set; }
        public bool BannedState { get; set; }
        public int BannedUntil { get; set; }
        public string[] Bans { get; set; }
        public int Experience { get; set; }
        public string GameVersion { get; set; }
        public bool IsStreamerModeAvailable { get; set; }
        public int LastTimePlayedAsSavage { get; set; }
        public int Level { get; set; }
        public string NickName { get; set; }
        public int NickNameChangeDate { get; set; }
        public string LowerNickName { get; set; }
        public int MemberCategory { get; set; }
        public string[] NeedWipeOptions { get; set; }
        public int RegistrationDate { get; set; }
        public int SavageLockTime { get; set; }
        public SavageInfo Settings { get; set; }
        public string Side { get; set; }
        public bool SquadInviteRestriction { get; set; }
        public bool HasCoopExtension { get; set; }
        public string Voice { get; set; }
        public bool lockedMoveCommands { get; set; }
    }
    public struct SavageInfo
    {
        public string BotDifficulty { get; set; }
        public int Experience { get; set; }
        public string Role { get; set; }
    }
    public struct AkiInfo
    {
        public string Version { get; }
        public string[] Mods { get; }
    }
    public struct RaidInfo
    {
        public string Location { get; }
        public string Character { get; }
    }
    public struct VitalityInfo
    {
        public Health Health { get; set; }
        public BodyParts Effects { get; set; }
    }
    public struct RagfairInfo
    {
        public bool isRatingGrowing { get; set; }
        //public string[]
        public float Rating { get; set; }
    }

    public struct SkillsInfo
    {
        public SkillInfo[] Common { get; set; }
        public MasteryInfo[] Mastery { get; set; }
        //public string??? bonuses { get; set; }
        public float Points { get; set; }
    }

    public struct MasteryInfo
    {
        public string Id { get; set; }
        public int Progress { get; set; }
    }
    public struct SkillInfo
    {
        public string Id { get; set; }
        public float Progress { get; set; }
        public float PointsEarnedDuringSession { get; set; }
        public int LastAccess { get; set; }
    }
}
