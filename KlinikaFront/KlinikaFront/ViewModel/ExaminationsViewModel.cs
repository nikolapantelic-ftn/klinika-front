using KlinikaFront.Utilities;
using Model.Secretary;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class ExaminationsViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToPrevious;
        private ICommand _previousWeek;
        private ICommand _nextWeek;

        public List<Appointment> MondayAppointments { get; set; } = new List<Appointment>();
        public List<Appointment> TuesdayAppointments { get; set; } = new List<Appointment>();
        public List<Appointment> WednesdayAppointments { get; set; } = new List<Appointment>();
        public List<Appointment> ThursdayAppointments { get; set; } = new List<Appointment>();
        public List<Appointment> FridayAppointments { get; set; } = new List<Appointment>();
        public List<Appointment> SaturdayAppointments { get; set; } = new List<Appointment>();
        public List<Appointment> SundayAppointments { get; set; } = new List<Appointment>();
        public bool[] DayNotEmpty { get; set; } = { false, false, false, false, false, false, false };
        public string WeekString { get; private set; }
        public DateTime StartOfWeek { get; private set; }
        public List<DateTime> DaysOfWeek { get; set; } = new List<DateTime>();
        public List<string> DayStrings { get; set; } = new List<string>();

        public ExaminationsViewModel()
        {

            int day = (int)DateTime.Now.DayOfWeek;
            StartOfWeek = DateTime.Now.AddDays(-day + 1);
            WeekString = StartOfWeek.ToString("dd.MM.") + " - " + StartOfWeek.AddDays(7).ToString("dd.MM.");
            PopulateWeek();



            //Test vrednosti
            MondayAppointments.Add(new Appointment(0, new DateTime(2020, 6, 1, 15, 20, 50), new DateTime(), AppointmentType.examination, null, null, null));
            DayNotEmpty[0] = true;
            SaturdayAppointments.Add(new Appointment(0, new DateTime(2020, 6, 1, 8, 30, 50), new DateTime(), AppointmentType.examination, null, null, null));
            SaturdayAppointments.Add(new Appointment(0, new DateTime(2020, 6, 1, 10, 30, 50), new DateTime(), AppointmentType.examination, null, null, null));
            DayNotEmpty[5] = true;
        }

        private void PopulateWeek()
        {
            DaysOfWeek.Clear();
            DayStrings.Clear();
            for (int i = 0; i <= 6; i++)
            {
                DateTime dayOfWeek = StartOfWeek.AddDays(i);
                DaysOfWeek.Add(dayOfWeek);
                DayStrings.Add(dayOfWeek.ToString("dd.MM.yyyy"));
            }
            OnPropertyChanged("DayStrings");
        }

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

        public ICommand PreviousWeek
        {
            get
            {
                return _previousWeek ?? (_previousWeek = new RelayCommand(x =>
                {
                    StartOfWeek = StartOfWeek.AddDays(-7);
                    WeekString = StartOfWeek.ToString("dd.MM.") + " - " + StartOfWeek.AddDays(7).ToString("dd.MM.");
                    OnPropertyChanged("WeekString");
                    PopulateWeek();
                }));
            }
        }

        public ICommand NextWeek
        {
            get
            {
                return _nextWeek ?? (_nextWeek = new RelayCommand(x =>
                {
                    StartOfWeek = StartOfWeek.AddDays(7);
                    WeekString = StartOfWeek.ToString("dd.MM.") + " - " + StartOfWeek.AddDays(7).ToString("dd.MM.");
                    OnPropertyChanged("WeekString");
                    PopulateWeek();
                }));
            }
        }
    }
}
