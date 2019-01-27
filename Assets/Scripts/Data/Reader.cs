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
            var textFile = Resources.Load<TextAsset>("Data/items");
            using (var reader = new StringReader(textFile.text)) {
                using (var csv = new CsvReader(reader)) {
                    var records = csv.GetRecords<Item>();
                    var items = records.ToList();
                    return items;
                }
            }
        }
    }
}
