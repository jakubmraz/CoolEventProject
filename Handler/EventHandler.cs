using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CoolEventProject.Converter;
using CoolEventProject.Model;
using CoolEventProject.ViewModel;

namespace CoolEventProject.Handler
{
    class EventHandler 
    {
        public EventViewModel EventViewModel { get; set; }
        public EventHandler(EventViewModel evm)
        {
            EventViewModel = evm;
        }

        public void CreateEvent()
        {
            DateTime date = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(EventViewModel.Date, EventViewModel.Time);
            Event e = new Event(EventViewModel.Id, EventViewModel.Name, EventViewModel.Description, EventViewModel.Place,date);
            EventCatalogSingleton.Instance.AddEvent(e);
        }
    }
}
