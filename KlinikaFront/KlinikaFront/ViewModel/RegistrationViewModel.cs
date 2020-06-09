using KlinikaFront.Utilities;
using Model.Patient;
using Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class Registration1ViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToNextRegistration;
        private ICommand _goToLogin;
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public SecureString Password { get; set; }
        public SecureString RepeatedPassword { get; set; }
        public ICommand GoToNextRegistration
        {
            get
            {
                return _goToNextRegistration ?? (_goToNextRegistration = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToNextRegistrationScreen", "");
                }));
            }
        }

        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ?? (_goToLogin = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToLoginScreen", "");
                }));
            }
        }
    }
    class Registration2ViewModel: BaseViewModel, IPageViewModel
    {
        private ICommand _goToPrevious;
        private ICommand _goToLogin;
        private ICommand _register;
        public string Jmbg { get; set; }
        public Sex Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public Address Address { get; set; }

        public ICommand GoToPrevious
        {
            get
            {
                return _goToPrevious ?? (_goToPrevious = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToPreviousScreen", "");
                }));
            }
        }

        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ?? (_goToLogin = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToLoginScreen", "");
                }));
            }
        }

        public ICommand Register
        {
            get
            {
                return _register ?? (_register = new RelayCommand(x =>
                {
                    Mediator.Notify("Register", "");
                }));
            }
        }
    }
}
