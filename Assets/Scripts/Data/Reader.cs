using System.IO;
using Data.Model;
using UnityEngine;
using System.Linq;
using CsvHelper;

namespace Data
{
    public class Reader
    {
        public void read() {
            using (var reader = new StreamReader("Assets/Data/items.csv")) {
                using (var csv = new CsvReader(reader)) {
                    var records = csv.GetRecords<Item>();
                    records.ToList().ForEach(r => Debug.Log(r));
//                    Debug.Log(string.Join("\n", records));
                }
            }
        }
    }
}