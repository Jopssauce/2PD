using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Description", menuName = "Gem Description")]
public class EncyclopediaItems : ScriptableObject
{
	public Sprite GemImageDefault;
	
	public string ItemName;

	[TextArea]
	public string Description;

	[TextArea]
	public string Location;
}
