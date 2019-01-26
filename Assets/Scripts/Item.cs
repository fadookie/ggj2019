using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
  public Sprite Icon { get; set; }
  public string Name { get; set; }
  public int Weight { get; set; }
  public int Value { get; set; }
  public Item(Sprite icon,string name, int weight, int value) {
    Icon = icon;
    Name = name;
    Weight = weight;
    Value = value;
  }
}
