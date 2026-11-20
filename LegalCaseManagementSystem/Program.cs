using LegalCaseManagementSystem.Controller;
using LegalCaseManagementSystem.View;

namespace LegalCaseManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            while (true)
            {
                using (var login = new LoginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        break;   
                }

                bool loggedOut;
                if (AuthController.CurrentUser?.Role == "Client")
                {
                    using var portal = new ClientPortalForm();
                    Application.Run(portal);
                    loggedOut = portal.LoggedOut;
                }
                else if (AuthController.CurrentUser?.Role == "Admin" ||
                         AuthController.CurrentUser?.Role == "Lawyer")
                {
                    using var main = new MainForm();
                    Application.Run(main);
                    loggedOut = main.LoggedOut;
                }
                else
                {
                    AuthController.Logout();
                    loggedOut = true;
                }

                if (!loggedOut)
                    break;   
            }
        }
    }
}