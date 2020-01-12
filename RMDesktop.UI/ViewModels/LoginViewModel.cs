using Caliburn.Micro;
using RMDesktop.UI.Helpers;
using System;
using System.Threading.Tasks;

namespace RMDesktop.UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        IAPIHelper _apiHelper;

        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public string Username
        {
            get => _username;
            set { _username = value; NotifyOfPropertyChange(() => Username); }
        }
        public string Password
        {
            get => _password;
            set { _password = value; NotifyOfPropertyChange(() => Password); NotifyOfPropertyChange(() => CanLogIn); }
        }

        public bool CanLogIn => Username?.Length > 0 && Password?.Length > 0;

        public async Task LogIn()
        {
            try
            {
                var result = await _apiHelper.Authenticate(Username, Password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }
    }
}