using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Model;
using System.Windows.Input;
using EventMaker.Common;
using EventMaker.Handler;
using EventMaker.Persistency;
using System.ComponentModel;

namespace EventMaker.ViewModel
{
    public class EventViewModel: INotifyPropertyChanged
    {
        public EventCatalogSingleton Instance { get; set; }
        public MyEventHandler EventInstance { get; set; }
        public Event Events { get; set; }


        public ICommand CreateEventCommand { get; set; }
        public ICommand DeleteEventCommand { get; set; }
        public EventViewModel()
        {
            Instance = EventCatalogSingleton.Instance;
            EventInstance = new MyEventHandler(this);
            Events = new Event();


            DateTime dt = System.DateTime.Now;
            Events.Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0,new TimeSpan());

            Events.Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);


            CreateEventCommand = new RelayCommand(EventInstance.CreateEvent);
            DeleteEventCommand = new RelayCommand(EventInstance.DeleteEvent, TomListeCheck);

            

        }
        public bool TomListeCheck()
        {
            return EventCatalogSingleton.Instance.EventsList.Count() > 0;
        }

        private Event _selectedEvent;
        public Event SelectedEvent
        {
            get { return _selectedEvent; }
            set
            {
                _selectedEvent = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
