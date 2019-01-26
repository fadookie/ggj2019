using UnityEngine;
using FileHelpers;

namespace Data
{
    public class Reader
    {
        public void read() {
            var engine = new FileHelperEngine<Customer>();
    
            // To Read Use:
            var result = engine.ReadFile("Assets/Data/test.csv");
            // result is now an array of Customer
            Debug.Log(string.Join("\n", (object[]) result));
        }
    }
}