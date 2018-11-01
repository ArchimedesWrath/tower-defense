using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	void Start()
	{
			items.Add(new Item("dew_drop", 0, "basic dew drop tower", 10, 10, 1, Item.ItemType.Tower));
			items.Add(new Item("pebble", 1, "basic pebble tower", 10, 10, 1, Item.ItemType.Tower));
	}

}
