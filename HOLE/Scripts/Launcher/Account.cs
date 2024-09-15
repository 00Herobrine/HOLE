namespace HOLE.Scripts.Launcher
{
    public struct Account(IAccountInfo accountInfo) : IAccountInfo // Launcher Account Stuff
    {
        public string id { get; set; } = accountInfo.id;
        public string nickname { get; set; } = accountInfo.nickname;
        public string username { get; set; } = accountInfo.username;
        public string password { get; set; } = accountInfo.password;
        public bool wipe { get; set; } = accountInfo.wipe;
        public string edition { get; set; } = accountInfo.edition;
    }

    public struct AccountInfo : IAccountInfo // Server Account Stuff
    {
        public string id { get; set; }
        public string nickname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool wipe { get; set; }
        public string edition { get; set; }
    }

    public interface IAccountInfo
    {
        public string id { get; }
        public string nickname { get; }
        public string username { get; }
        public string password { get; }
        public bool wipe { get; }
        public string edition { get; }
    }
}
