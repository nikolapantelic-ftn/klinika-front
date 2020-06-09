using KlinikaFront.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class ExaminationRecommendationViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToPrevious;
        private ICommand _goToScheduleExamination;
        private ICommand _findAppointment;
        public bool ShowAppointment { get; set; } = false;

        public ExaminationRecommendationViewModel()
        {
            Mediator.Subscribe("ShowAppointment", EnableAppointment);
        }

        private void EnableAppointment(object obj)
        {
            ShowAppointment = true;
            OnPropertyChanged("ShowAppointment");
        }

        public ICommand GoToPrevious
        {
            get
            {
                return _goToPrevious ?? (_goToPrevious = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToMainScreen", "");
                }));
            }
        }

        public ICommand GoToScheduleExamination
        {
            get
            {
                return _goToScheduleExamination ?? (_goToScheduleExamination = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToScheduleExaminationScreen", "");
                }));
            }
        }

        public ICommand FindAppointment
        {
            get
            {
                return _findAppointment ?? (_findAppointment = new RelayCommand(x =>
                {
                    Mediator.Notify("ShowAppointment", "");
                }));
            }
        }
    }
}
