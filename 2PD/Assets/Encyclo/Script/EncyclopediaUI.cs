using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EncyclopediaUI : MonoBehaviour {

	public List<EncyclopediaItems> Items;

	public Image GemPlace;

	public List<Button> Buttons;

	[SerializeField]
	private TextMeshProUGUI ItemNameUI;

	[SerializeField]
	private TextMeshProUGUI ItemDescriptionUI;

	[SerializeField]
	private TextMeshProUGUI ItemLocationUI;



	public void DisplayUI(int index)
	{
		ItemNameUI.text = Items [index].ItemName;
		ItemDescriptionUI.text = Items [index].Description;
		ItemLocationUI.text = Items [index].Location;

		if (Items [index].IsDiscovered) 
		{
		}
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Hover);
	}
}
