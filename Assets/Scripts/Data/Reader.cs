using Data.Model;
using UnityEngine;
using FileHelpers;

namespace Data
{
    public class Reader
    {
        public void read() {
            var engine = new FileHelperEngine<Item>();
    
            // To Read Use:
            var result = engine.ReadFile("Assets/Data/items.csv");
            // result is now an array of Items
            Debug.Log(string.Join("\n", (object[]) result));
        }
    }
}