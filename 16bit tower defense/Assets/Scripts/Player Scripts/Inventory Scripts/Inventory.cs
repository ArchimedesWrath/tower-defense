using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public List<GameObject> Slots = new List<GameObject>();
	public List<Item> Items = new List<Item>();
	public GameObject slots;
	ItemDatabase database;
	private int posx = -105;
	private int posy = 125;

	void Start () {

		database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

		for (int x = 0; x < 7; x++)
		{
			for (int y = 0; y < 6; y++)
			{
				GameObject slot = (GameObject)Instantiate(slots);
				Slots.Add(slot);
				Items.Add(new Item());
				slot.transform.SetParent(this.gameObject.transform);
				slot.name = "Slot" + x + "," + y;
				slot.GetComponent<RectTransform>().localPosition = new Vector3(posx, posy, 0);
				posx = posx + 41;
				if (y == 5) {
					posx = -105;
					posy = posy - 41;
				}
			}
		}
	}

	void addItem(int id )
	{
		for(int i = 0; i <)
	}
}
