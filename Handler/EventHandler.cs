using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Model;
using EventMaker.ViewModel;
using EventMaker.Converter;
using System.ComponentModel;

namespace EventMaker.Handler
{
    public class MyEventHandler
    {
        public EventViewModel EVM { get; set; }

        public MyEventHandler(EventViewModel evm)
        {
            this.EVM = evm;
        }



        public void CreateEvent()
        {
            Event TempEvent = new Event();
            TempEvent.Description = EVM.Events.Description;
            TempEvent.ID = EVM.Events.ID;
            TempEvent.Name = EVM.Events.Name;
            TempEvent.Place = EVM.Events.Place;
            TempEvent.Datetime = DateTimeConverter.DatetimeOffsetAndTimeSetToDateTime(EVM.Events.Date, EVM.Events.Time);
            EventCatalogSingleton.Instance.AddEvent(TempEvent);
        }

        public void DeleteEvent()
        {
            EventCatalogSingleton.Instance.RemoveEvent(EVM.SelectedEvent);
        }

    }
}
