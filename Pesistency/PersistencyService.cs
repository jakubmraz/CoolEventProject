using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.AI.MachineLearning;
using Windows.Storage;
using CoolEventProject.Model;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace CoolEventProject.Pesistency
{
    class PersistencyService<T> where T : class
    {
        private const string Filename = "Save.json";
        private static readonly object EventsCollection;
        private static CreationCollisionOption _options;
        private static StorageFolder _folder;

        public PersistencyService()
        {
            _options = CreationCollisionOption.OpenIfExists;
            _folder = ApplicationData.Current.LocalFolder;
        }

        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> EventsCollection)
        {
            var dataFile = await _folder.CreateFileAsync(Filename, _options);
            string dataJson = JsonConvert.SerializeObject(EventsCollection);
            await FileIO.WriteTextAsync(dataFile, dataJson);
        }

        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            StorageFile dataFile = await _folder.GetFileAsync(Filename);
                string dataJson = await FileIO.ReadTextAsync(dataFile);
                return (List<Event>)(JsonConvert.DeserializeObject(Filename, typeof(List<Event>)));

        }



        /* public static async void SerializeEventsFileAsync(string EventsCollection, string fileName)
         {
             string json = JsonConvert.SerializeObject(PersistencyService<T>.EventsCollection);
             await FileIO.WriteTextAsync(
                 await _folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting));
         }

        public static string DeSerializeEventsFile(String fileName)
        {
            return (fileName);
        }
        */
    }
}

