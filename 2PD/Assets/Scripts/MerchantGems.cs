using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GemItems", menuName = "Gems")]
public class MerchantGems : ScriptableObject
{
	public string Name;
	public float BuyingPrice;
	public float SellingPrice;
}
