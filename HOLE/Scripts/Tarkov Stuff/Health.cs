namespace HOLE.Scripts.Tarkov_Stuff
{
    public struct Health
    {
        public BodyParts BodyParts { get; set; }
        public LimitedInt Energy { get; set; }
        public LimitedInt Hydration { get; set; }
        public LimitedInt Temperature { get; set; }
        public int UpdateTime { get; set; } // UTX time?
    }

    public struct BodyParts
    {
        public LimitedInt Head { get; set; }
        public LimitedInt Chest { get; set; }
        public LimitedInt Stomach { get; set; }
        public LimitedInt LeftArm { get; set; }
        public LimitedInt RightArm { get; set; }
        public LimitedInt LeftLeg { get; set; }
        public LimitedInt RightLeg { get; set; }
    }
}
