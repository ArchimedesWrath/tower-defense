using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	public string itemName;
	public int itemID;
	public string itemDescription;
	public Sprite itemIcon;
	public GameObject itemModel;
	public int itemPower;
	public int itemSpeed;
	public int itemValue;
	public ItemType itemType;

	public enum ItemType
	{
			Tower,
			Material
	}

	public Item(string name, int id, string desc, int power, int speed, int value, ItemType type)
	{
		itemName = name;
		itemID = id;
		itemDescription = desc;
		itemPower = power;
		itemSpeed = speed;
		itemValue = value;
		itemType = type;
		itemIcon = Resources.Load<Sprite>("" + name);
	}

	public Item()
	{

	}
}
