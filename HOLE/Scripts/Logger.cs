using System.Diagnostics;

namespace HOLE.Scripts
{
    public static class Logger
    {
        public static void Log(params string[] args)
        {
            foreach(string arg in args)
            {
                Debug.WriteLine(arg);
                //Form1.Log(arg, "H.O.L.E");
            }
        }
    }
}
