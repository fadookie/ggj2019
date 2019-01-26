using System.Collections.Generic;
using System.IO;
using Data.Model;
using UnityEngine;
using System.Linq;
using CsvHelper;

namespace Data
{
    public class Reader
    {
        public List<Item> read() {
            using (var reader = new StreamReader("Assets/Data/items.csv")) {
                using (var csv = new CsvReader(reader)) {
                    var records = csv.GetRecords<Item>();
                    var items = records.ToList();
                    items.ForEach(r => Debug.Log(r));
                    return items;
                }
            }
        }
    }
}