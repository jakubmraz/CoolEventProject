﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CoolEventProject.Model;

namespace CoolEventProject.ViewModel
{
    class EventViewModel
    {
        public EventViewModel()
        {
            EventCatalog = EventCatalogSingleton.Instance;
        }

        public EventCatalogSingleton EventCatalog { get; }
        
        
    }

}
