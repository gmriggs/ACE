namespace ACE.Server.Managers
{
    public class DiagnosticsManager
    {
        public static Diagnostics.Server Server;

        public static void Initialize()
        {
            Server = new Diagnostics.Server();
        }
    }
}
