namespace HOLE.Scripts
{
    public class LimitedValue<T>(T Current, T Maximum)
    {
        public required T Current { get; set; } = Current;
        public required T Maximum { get; set; } = Maximum;
    }

    public class LimitedInt(int Current, int Maximum) : LimitedValue<int>(Current, Maximum) { }
    public class LimitedFloat(float Current, float Maximum) : LimitedValue<float>(Current, Maximum) { }
    public class LimitedDouble(double Current, double Maximum) : LimitedValue<double>(Current, Maximum) { }
}
