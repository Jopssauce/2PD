using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

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

		for (int i = 0; i < Items.Count; i++)
			images [i].sprite = Items [i].GemImageDefault;
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
		images [index].color = color;
	}
}
