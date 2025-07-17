namespace HOLE.Assets.Scripts
{
    public static class Logger
    {
        public static void Log(params string[] args)
        {
            foreach (string arg in args)
            {
                Console.WriteLine(arg);
            }
        }
    }
}
