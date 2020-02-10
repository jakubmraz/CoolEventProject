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
    class PersistencyService
    {
        private const string Filename = "Save.Json";
        //private static object EventsCollection => EventCatalogSingleton.Instance.EventCollection;
        //private static CreationCollisionOption _options;
        private static readonly StorageFolder StorageFolder = ApplicationData.Current.LocalFolder;

        public PersistencyService()
        {
            //_options = CreationCollisionOption.OpenIfExists;
        }

        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> collection)
        {
            //var dataFile = await _folder.CreateFileAsync(Filename, CreationCollisionOption.ReplaceExisting);
            //string dataJson = JsonConvert.SerializeObject(collection);
            //await FileIO.WriteTextAsync(dataFile, dataJson);
            string json = JsonConvert.SerializeObject(collection);
            await FileIO.WriteTextAsync(await StorageFolder.CreateFileAsync(Filename, CreationCollisionOption.ReplaceExisting), json);
        }

        public static async Task LoadEventsFromJsonAsync()
        {
            //StorageFile dataFile = await _folder.GetFileAsync(Filename);
            //  string dataJson = await FileIO.ReadTextAsync(dataFile);
            //return (ObservableCollection<Event>)(JsonConvert.DeserializeObject(Filename, typeof(ObservableCollection<Event>)));
            string loadedEvents = await FileIO.ReadTextAsync(await StorageFolder.CreateFileAsync(Filename, CreationCollisionOption.OpenIfExists));
            //Only loads the contents of the file if it isn't empty, otherwise it would set the collection as null and break the program
            if (loadedEvents != "")
            {
                EventCatalogSingleton.Instance.EventCollection = JsonConvert.DeserializeObject<ObservableCollection<Event>>(loadedEvents);
            }

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

