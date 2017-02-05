using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using EventMaker.Persistency;
using System.Diagnostics;
using System.ComponentModel;
using EventMaker.Handler;

namespace EventMaker.Model
{
    public sealed class EventCatalogSingleton
    {

        public ObservableCollection<Event> EventsList { get; set; }
        private static EventCatalogSingleton instance { get; set; } = new EventCatalogSingleton();
        const string FilNavn = "filNavn.json";
        public static EventCatalogSingleton Instance
        {
            get { return instance; }
        }

        public EventCatalogSingleton()
        {
            
            EventsList = new ObservableCollection<Event>();
            EventsList.Add(new Event() { Name = "Allahu Akbar", ID = 001, Description = "awesomeness", Place = "Palace" });
            EventsList.Add(new Event() { Name = "Allahu", ID = 002, Description = "awesomeness", Place = "Palace" });
            EventsList.Add(new Event() { Name = "Akbar", ID = 003, Description = "awesomeness", Place = "Palace" });
            EventsList.Add(new Event() { Name = "bar", ID = 004, Description = "awesomeness", Place = "Palace" });

            //LoadJson();
        }
        public void AddEvent(Event NewEvent)
        {
            EventsList.Add(NewEvent);
            PersistencyService.SaveEventAsJsonAsync(FilNavn,EventsList);
        }
        #region LoadMetode
        private async void LoadJson()
        {
            try
            {
                EventsList = await PersistencyService.LoadEventsFromJsonAsync(FilNavn);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        #endregion



        public void RemoveEvent(Event DeleteEvent)
        {
            EventsList.Remove(DeleteEvent);
            PersistencyService.SaveEventAsJsonAsync(FilNavn, EventsList);
        }

    }
}
