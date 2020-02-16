using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CoolEventProject.Annotations;
using CoolEventProject.Common;
using CoolEventProject.Handler;
using CoolEventProject.Model;

namespace CoolEventProject.ViewModel 
{
    class EventViewModel: INotifyPropertyChanged
    {
        private int _id;
        private string _description;
        private string _name;
        private string _place;
        private DateTimeOffset _date;
        private TimeSpan _time;

        readonly DateTime dt = System.DateTime.Now;

        private ObservableCollection<Event> _events = new ObservableCollection<Event>();
       

        public EventViewModel()
        {
            EventCatalog = EventCatalogSingleton.Instance;
            EventHandler = new Handler.EventHandler(this);

            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            CreateEventCommand = new RelayCommand(EventHandler.CreateEvent);
            SelectedEvent= new Event();
            DeleteEventCommand= new RelayCommand(EventHandler.DeleteEvent);

        }

        public Handler.EventHandler EventHandler { get; set; }
        public ICommand CreateEventCommand { get; set; }
        public ICommand DeleteEventCommand { get; set; }
        public Event SelectedEvent { get; set; }

        public int Id
        {
            get { return _id;}
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        public string Description {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        public string Name {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string Place {
            get { return _place; }
            set
            {
                _place = value;
                OnPropertyChanged();
            }
        }
        public DateTimeOffset Date {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }
        public TimeSpan Time {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }


        public EventCatalogSingleton EventCatalog { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
