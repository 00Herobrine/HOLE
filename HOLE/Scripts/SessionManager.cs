

namespace HOLE.Scripts
{
    public static class SessionManager
    {
        public static void RegisterEvents()
        {
            GameManager.TarkovStartedEvent += StartSession;
        }

        public static void UnregisterEvents()
        {
            GameManager.TarkovStartedEvent -= StartSession;
        }

        private static void StartSession(GameEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
