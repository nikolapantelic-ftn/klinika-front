using KlinikaFront.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class MainViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToIndex;
        public ICommand GoToIndex
        {
            get
            {
                return _goToIndex ?? (_goToIndex = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToIndexScreen", "");
                }));
            }
        }
    }
}
