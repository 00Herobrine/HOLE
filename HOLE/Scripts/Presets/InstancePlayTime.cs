namespace HOLE.Scripts.Presets
{
    public struct PlayTime
    {
        public InstancePlayTime[] Instances { get; set; }
        public Session Session { get; set; }
        public readonly TimeSpan GetTotalPlayTime()
        {
            TimeSpan totalPlaytime = TimeSpan.Zero;
            foreach(InstancePlayTime instancePlayTime in Instances)
                totalPlaytime += TimeSpan.FromMinutes(instancePlayTime.TotalPlayTime);
            return totalPlaytime;
        }
    }
    public struct InstancePlayTime(string Instance)
    {
        public string Instance { get; set; } = Instance;
        public Session FirstSession { get; set; } = new();
        public Session LastSession { get; set; } = new();
        public int TotalPlayTime { get; set; } = 0; // In Minutes
        public readonly TimeSpan TimeSinceLastPlayed => LastSession.EndTime - DateTime.Now;
        public void Ended()
        {
            LastSession.Ended();
        }
    }
    public struct Session()
    {
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
        public readonly TimeSpan PlayTime => EndTime - StartTime;
        public void Ended() => EndTime = DateTime.Now;
    }
}
