using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EncyclopediaUI : MonoBehaviour {

	public List<EncyclopediaItems> Items;

	public Image GemPlace;

	[SerializeField]
	private Color32 color;

	[SerializeField]
	private TextMeshProUGUI ItemNameUI;

	[SerializeField]
	private TextMeshProUGUI ItemDescriptionUI;

	[SerializeField]
	private TextMeshProUGUI ItemLocationUI;

	[SerializeField]
	private List<Image> images;

	void Start()
	{
		foreach (EncyclopediaItems i in Items)
		{
			i.IsDiscovered = false;
		}
	}

	public void DisplayUI(int index)
	{
		ItemNameUI.text = Items [index].ItemName;
		ItemDescriptionUI.text = Items [index].Description;
		ItemLocationUI.text = Items [index].Location;
		if(FindObjectOfType<AudioManager>() != null)
			FindObjectOfType<AudioManager> ().Play (MusicStrings.SoundFx_Hover);
	}

	public void UnlockGemContent(int index)
	{
		images [index].sprite = Items [index].GemImageDefault;
		images [index].color = color;
	}
}
