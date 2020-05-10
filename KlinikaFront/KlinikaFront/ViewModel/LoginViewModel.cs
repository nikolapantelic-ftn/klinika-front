using KlinikaFront.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class LoginViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _login;

        public ICommand Login
        {
            get
            {
                return _login ?? (_login = new RelayCommand(x =>
                {
                    Mediator.Notify("Login", "");
                }));
            }
        }
    }
}
