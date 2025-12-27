using Newtonsoft.Json;

namespace HOLE.Assets.Scripts.SPT;

public class SPTMod
{
    public bool InServer { get; set; }
    public bool InProfile { get; set; }
    public string Author { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public string Url { get; set; }
}

public class SPTProfileModInfo : SPTMod
{
    public string DateAdded { get; set; }
}

public class SPTServerModInfo : SPTMod
{
    public string Main { get; set; }
    public string License { get; set; }
    public string SPTVersion { get; set; }
    public Dictionary<string, string> Scripts { get; set; }
    public DevDependencies DevDependencies { get; set; }
}

public class DevDependencies
{
    [JsonProperty("@types/node")]
    public string TypesNode { get; set; }

    [JsonProperty("@typescript-eslint/eslint-plugin")]
    public string EslintPlugin { get; set; }

    [JsonProperty("@typescript-eslint/parser")]
    public string EslintParser { get; set; }
    public string BestZip { get; set; }
    public string Eslint { get; set; }

    [JsonProperty("fs-extra")]
    public string FsExtra { get; set; }
    public string Glob { get; set; }
    public string Tsyringe { get; set; }
    public string Typescript { get; set; }

}