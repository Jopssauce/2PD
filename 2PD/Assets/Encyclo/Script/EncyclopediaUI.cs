using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EncyclopediaUI : MonoBehaviour {

	public List<EncyclopediaItems> Items;

	[SerializeField]
	private TextMeshProUGUI ItemNameUI;

	[SerializeField]
	private TextMeshProUGUI ItemDescriptionUI;

	[SerializeField]
	private TextMeshProUGUI ItemLocationUI;

	[SerializeField]
	private List<Text> ButtonText;

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
