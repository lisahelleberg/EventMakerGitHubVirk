using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Converter;

namespace EventMaker.Model
{
    public class Event
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Place { get; set; }

        public DateTime Datetime { get; set; }

        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }


        public Event()
        {

        }


        public override string ToString()
        {
            return "navn " + Name + "Spiller den: " + Datetime;
        }


    }
}
