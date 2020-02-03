using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolEventProject.Model
{
    class EventCatalogSingleton
    {
        private EventCatalogSingleton _instance;

        private EventCatalogSingleton()
        {
            AddEvent(01, "Test Event", "This event is purely hypothetical.", "Virtual", DateTime.Today);
            AddEvent(02, "Test Event #2", "Because one test was not enough.", "Virtual", DateTime.Today);
        }

        public EventCatalogSingleton Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    return new EventCatalogSingleton();
                }
            }
        }

        private ObservableCollection<Event> _eventCollection = new ObservableCollection<Event>();

        public void AddEvent(int id, string name, string description, string place, DateTime dateTime)
        {
            _eventCollection.Add(new Event(id, name, description, place, dateTime));
        }
    }
}
