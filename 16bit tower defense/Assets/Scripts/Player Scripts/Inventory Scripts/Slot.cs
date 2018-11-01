using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler {

	public Item item;
	private Image itemImage;


	void Start () {
		itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
	}

	void Update () {

		if (item != null)
		{
			itemImage.enabled = true;
			itemImage.sprite = item.itemIcon;
		}
		else
		{
			itemImage.enabled = false;
		}

	}

	public void OnPointerDown(PointerEventData data)
	{
		Debug.Log(transform.name);
	}

	public void OnPointerEnter(PointerEventData data)
	{
		Debug.Log("MouseOverDown");
	}
}
