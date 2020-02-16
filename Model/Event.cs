using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;

namespace CoolEventProject.Model
{
    class Event
    {

        public Event(int id, string name, string description, string place, DateTime dateTime)
        {
            Id = id;
            Name = name;
            Description = description;
            Place = place;
            DateTime = dateTime;
        }
        public Event() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime DateTime { get; set; }

       /* public override string ToString()
        {
            return $"Event Name: {Name}; Event ID: {Id}; Description: {Description}; Place: {Place}; Scheduled Date: {DateTime}";
        }*/

    }
}
