using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using EventMaker.Model;
using System.Collections.ObjectModel;
using EventMaker.ViewModel;
using Windows.Storage;
using Windows.UI.Popups;
using Newtonsoft.Json;

namespace EventMaker.Persistency
{
    public class PersistencyService
    {
        public static async void SaveEventAsJsonAsync(string fileName, ObservableCollection<Event> save)
        {

            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string JsonData = JsonConvert.SerializeObject(save);
            await FileIO.WriteTextAsync(localFile, JsonData);

        }

        public static async Task<ObservableCollection<Event>> LoadEventsFromJsonAsync(string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            string jsonData = await FileIO.ReadTextAsync(localFile);
            return JsonConvert.DeserializeObject<ObservableCollection<Event>>(jsonData);
        }


    }
}
