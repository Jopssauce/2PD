using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaUI : MonoBehaviour {

	public List<EncyclopediaItems> Items;

	[SerializeField]
	private Text ItemNameUI;

	[SerializeField]
	private Text ItemDescriptionUI;

	[SerializeField]
	private Text ItemLocationUI;

	// Use this for initialization

	public void DisplayUI(int index)
	{
		if (Items [index].IsDiscovered) 
		{
			ItemNameUI.text = Items [index].ItemName;
			ItemDescriptionUI.text = Items [index].Description;
			ItemLocationUI.text = Items [index].Location;
		}
	}
}
