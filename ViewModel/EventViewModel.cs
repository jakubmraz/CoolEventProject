using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CoolEventProject.Annotations;
using CoolEventProject.Model;

namespace CoolEventProject.ViewModel 
{
    class EventViewModel: INotifyPropertyChanged
    {

        readonly DateTime dt = System.DateTime.Now;
       /* public EventViewModel(int id, string name, string description, string place, DateTimeOffset date,
            TimeSpan time)
        {
            Id = id;
            Name = name;
            Description = description;
            Place = place;
           
        }*/

        
        public EventViewModel()
        {
            EventCatalog = EventCatalogSingleton.Instance;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

        }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTimeOffset Date { get; set; }

        public TimeSpan Time { get; set; }
        public EventCatalogSingleton EventCatalog { get; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
