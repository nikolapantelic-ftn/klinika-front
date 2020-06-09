﻿using KlinikaFront.Utilities;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class ScheduleExaminationViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToPrevious;
        private ICommand _goToMain;

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

        public ICommand GoToMain
        {
            get
            {
                return _goToMain ?? (_goToMain = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToMainScreen", "");
                }));
            }
        }


    }
}
