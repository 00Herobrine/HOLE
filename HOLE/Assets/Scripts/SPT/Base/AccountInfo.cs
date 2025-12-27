namespace HOLE.Assets.Scripts.SPT;

public class AccountInfo
{
    public string id;
    public string nickname;
    public string username;
    public string password;
    public bool wipe;
    public string edition;

    public AccountInfo()
    {
        id = "";
        nickname = "";
        username = "";
        password = "";
        wipe = false;
        edition = "";
    }
}

public struct LoginRequestData
{
    public string username;
    public string password;

    public LoginRequestData(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
}

public struct RegisterRequestData
{
    public string username;
    public string password;
    public string edition;

    public RegisterRequestData(string username, string password, string edition)
    {
        this.username = username;
        this.password = password;
        this.edition = edition;
    }
}