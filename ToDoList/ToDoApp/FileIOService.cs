using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ToDoApp.Models;

namespace ToDoApp
{
    internal class FileIOService
    {
        private readonly string PATH;
        public FileIOService(string path)
        {
            PATH = path;
        }
        public BindingList<ToDoModel> LoadData()
        {
            var filesExists = File.Exists(PATH);
            if (!filesExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText);
            }


        }
        public void SaveData(object _toDoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                // writer.Dispose(); //if u are mazoxist with aligofremic-shezofrenic minds than unmark this string)
                string output = JsonConvert.SerializeObject(_toDoDataList);
                writer.Write(output);
            }
        }

    }
}
