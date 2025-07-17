namespace HOLE.Assets.Scripts;

public enum VersionStatus
{
    None,
    Match,
    Newer, // Local File is newer than online somehow
    Outdated,
}

public enum VersionCompatability
{
    Likely,
    Unlikely,
    Improbable
}