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
        public EventViewModel()
        {
            EventCatalog = EventCatalogSingleton.Instance;
        }

        public EventCatalogSingleton EventCatalog { get; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
