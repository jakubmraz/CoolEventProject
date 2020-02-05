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
            EventsCollection = new ObservableCollection<Event>();
            EventsCollection.Add(new Event(01, "Test Event", "This event is purely hypothetical.", "Virtual", DateTime.Today));
            EventsCollection.Add(new Event(02, "Test Event #2", "Because one test was not enough.", "Virtual", DateTime.Today));
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


        public void AddEvent(Event e)
        {
            EventsCollection.Add(e);
        }
    }
}
