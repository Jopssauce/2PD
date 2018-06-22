using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour {

	private GameManager gameManager;

	[SerializeField]
	private GameObject MerchantMenu;

	void Awake () 
	{
		if (GameManager.instance != null)
			gameManager = GameManager.instance;
	}

	public void DeductCurrencyMerchant(int amount)
	{
		gameManager.sharedInventory.GetComponent<Currency> ().DeductCurrency (amount);
	}

	public void AddCurrencyMerchant(int amount)
	{
		gameManager.sharedInventory.GetComponent<Currency> ().AddCurrency(amount);
	}

	public void DeactivateSelf()
	{
		gameObject.SetActive (false);
	}

	public void ActivateUI(GameObject UI)
	{
		UI.gameObject.SetActive (true);
		MerchantMenu.SetActive (false);
	}

	public void BackToMerchantMenu(GameObject UI)
	{
		UI.gameObject.SetActive (false);
		MerchantMenu.SetActive (true);
	}
}
