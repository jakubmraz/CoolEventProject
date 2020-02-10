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
            EventCollection = new ObservableCollection<Event>();
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
        }
    }
}
