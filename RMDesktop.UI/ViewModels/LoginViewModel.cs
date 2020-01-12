using Caliburn.Micro;

using System;

namespace RMDesktop.UI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _username;
        private string _password;

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

        public void LogIn() => Console.WriteLine($"{Username}, {Password}");
    }
}