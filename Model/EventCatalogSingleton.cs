using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolEventProject.Pesistency;

namespace CoolEventProject.Model
{
    class EventCatalogSingleton
    {

        private static EventCatalogSingleton _instance;

        private EventCatalogSingleton()
        {
            EventCollection = new ObservableCollection<Event>();
            EventCollection.Add(new Event(01, "Test Event", "This event is purely hypothetical.", "Virtual", DateTime.Today));
            EventCollection.Add(new Event(02, "Test Event #2", "Because one test was not enough.", "Virtual", DateTime.Today));
        }

        public static EventCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    return _instance = new EventCatalogSingleton();
                }
                else
                {
                    return _instance;
                }
            }
        }

        public ObservableCollection<Event> EventCollection { get; set; }

        public void AddEvent(Event e)
        {
            EventCollection.Add(e);
            PersistencyService.SaveEventsAsJsonAsync(EventCollection);
        }

        public void RemoveEvent(Event ev)
        {
            EventCollection.Remove(ev);
            PersistencyService.SaveEventsAsJsonAsync(EventCollection);
        }
    }
}
