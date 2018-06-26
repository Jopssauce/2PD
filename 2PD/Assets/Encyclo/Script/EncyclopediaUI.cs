using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EncyclopediaUI : MonoBehaviour {

	public List<EncyclopediaItems> Items;

	public Image GemPlace;

	[SerializeField]
	private TextMeshProUGUI ItemNameUI;

	[SerializeField]
	private TextMeshProUGUI ItemDescriptionUI;

	[SerializeField]
	private TextMeshProUGUI ItemLocationUI;

	[SerializeField]
	private List<TextMeshProUGUI> ButtonText;

	void Start()
	{
		for (int i = 0; i < Items.Count; i++) 
		{
			ButtonText [i].text = Items [i].ItemName;
		}
	}
	// Use this for initialization

	public void DisplayUI(int index)
	{
		if (Items [index].IsDiscovered) 
		{
			ItemNameUI.text = Items [index].ItemName;
			ItemDescriptionUI.text = Items [index].Description;
			ItemLocationUI.text = Items [index].Location;
			GemPlace.sprite = Items [index].GemImage;
		}
		FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Select);
	}
}
