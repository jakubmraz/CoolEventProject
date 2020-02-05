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
        private static EventCatalogSingleton _instance;

        private EventCatalogSingleton()
        {
            AddEvent(01, "Test Event", "This event is purely hypothetical.", "Virtual", DateTime.Today);
            AddEvent(02, "Test Event #2", "Because one test was not enough.", "Virtual", DateTime.Today);
        }

        public static EventCatalogSingleton Instance
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

        public ObservableCollection<Event> EventsCollection = new ObservableCollection<Event>();
        public ObservableCollection<Event> EventCollection
        {
            get { return EventsCollection; }
        }


        public void AddEvent(int id, string name, string description, string place, DateTime dateTime)
        {
            EventsCollection.Add(new Event(id, name, description, place, dateTime));
        }
    }
}
