using Caliburn.Micro;

namespace MemeGenerator.Client.ViewModels
{
    /// <summary>
    /// Main window app
    /// </summary>
    public class ShellViewModel : Conductor<object>
    {
        private readonly MemeCreatorViewModel memeCreatorViewModel;
        private readonly LoginViewModel loginViewModel;
        private readonly RegisterViewModel registerViewModel;
        private readonly MemeLibraryViewModel memeLibraryViewModel;
        private readonly ConnectionViewModel connectionViewModel;

        public ShellViewModel
            
            (MemeCreatorViewModel memeCreatorViewModel,
            LoginViewModel loginViewModel,
            RegisterViewModel registerViewModel,
            MemeLibraryViewModel memeLibraryViewModel,
            ConnectionViewModel connectionViewModel)
        {
            this.memeCreatorViewModel = memeCreatorViewModel;
            this.loginViewModel = loginViewModel;
            this.registerViewModel = registerViewModel;
            this.memeLibraryViewModel = memeLibraryViewModel;
            this.connectionViewModel = connectionViewModel;
        }

        #region Buttons
        /// <summary>
        /// button -> Load meme creator page
        /// </summary>
        public void LoadMemeCreatorPage()
        {
            ActivateItem(memeCreatorViewModel);
        }

        /// <summary>
        /// button -> Load login page
        /// </summary>
        public void LoadLoginPage()
        {
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        /// <summary>
        /// button -> Load register page
        /// </summary>
        public void LoadRegisterPage()
        {
            ActivateItem(registerViewModel);
        }

        /// <summary>
        /// button -> Load library page
        /// </summary>
        public void LoadMemeLibraryPage()
        {
            ActivateItem(memeLibraryViewModel);
        }

        /// <summary>
        /// button -> Load connection page
        /// </summary>
        public void Connect()
        {
            ActivateItem(connectionViewModel);
           // client.GetConnection();
        }
        #endregion
    }
}
