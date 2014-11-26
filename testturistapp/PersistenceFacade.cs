using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using testturistapp.Model;
using testturistapp.Viewmodel;

namespace testturistapp
{
    class PersistenceFacade
    {
        private static string jsonFileName = "RatingAsJson.Dat";

        public static async void SavePersonsAsJsonAsync(ObservableCollection<Kategori> Kategorier)
        {
            string RatingJsonString = JsonConvert.SerializeObject(Kategorier);
            SerializeRatingsFileAsync(RatingJsonString, jsonFileName);
        }

        public static async Task<List<Kategori>> LoadPersonsFromJsonAsync()
        {
            string personsJsonString = await DeSerializeRatingsFileAsync(jsonFileName);
            return (List<Kategori>)JsonConvert.DeserializeObject(personsJsonString, typeof(List<Person>));
        }

        public static async void SerializeRatingsFileAsync(string PersonsString, string fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(localFile, PersonsString);
        }

        public static async Task<string> DeSerializeRatingsFileAsync(String fileName)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            return await FileIO.ReadTextAsync(localFile);
        }
    }
}
