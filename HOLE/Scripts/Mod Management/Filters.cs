using HOLE.Scripts.Misc;

namespace HOLE.Scripts.Mod_Management
{
    public enum Filters
    {
        Title, Author, Description, Version,
    }

    public enum SortOrder
    {
        [DisplayName("Descending", "DESC")]
        DESCENDING,
        [DisplayName("Ascending", "ASC")]
        ASCENDING
    }
    public enum SortField
    {
        [DisplayName("Newest", "time")]
        NEWEST,
        [DisplayName("Updated", "lastChangeTime")]
        UPDATED,
        [DisplayName("Downloads", "downloads")]
        DOWNLOADS,
        [DisplayName("Ratings", "cumulativeLikes")]
        RATINGS
    }
}
