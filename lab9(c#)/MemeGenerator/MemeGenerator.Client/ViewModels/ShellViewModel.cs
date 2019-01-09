using Caliburn.Micro;

namespace MemeGenerator.Client.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly MemeCreatorViewModel memeCreatorViewModel;
        private readonly LoginViewModel loginViewModel;
        private readonly RegisterViewModel registerViewModel;
        private readonly MemeLibraryViewModel memeLibraryViewModel;
        private readonly ConnectionViewModel connectionViewModel;
        private readonly ClientApp client;

        public ShellViewModel
            (
            MemeCreatorViewModel memeCreatorViewModel,
            LoginViewModel loginViewModel,
            RegisterViewModel registerViewModel,
            MemeLibraryViewModel memeLibraryViewModel,
            ConnectionViewModel connectionViewModel,
            ClientApp client
            )
        {
            this.memeCreatorViewModel = memeCreatorViewModel;
            this.loginViewModel = loginViewModel;
            this.registerViewModel = registerViewModel;
            this.memeLibraryViewModel = memeLibraryViewModel;
            this.connectionViewModel = connectionViewModel;
            this.client = client;
        }

        public void LoadMemeCreatorPage()
        {
            ActivateItem(memeCreatorViewModel);
        }
        public void LoadLoginPage()
        {
            ActivateItem(loginViewModel);
        }
        public void LoadRegisterPage()
        {
            ActivateItem(registerViewModel);
        }
        public void LoadMemeLibraryPage()
        {
            ActivateItem(memeLibraryViewModel);
        }

        public void Connect()
        {
            ActivateItem(connectionViewModel);
           // client.GetConnection();
        }
    }
}
