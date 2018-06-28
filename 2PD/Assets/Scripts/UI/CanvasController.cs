using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasController : MonoBehaviour {

	GameManager gameManager;

	public TextMeshProUGUI player1Health;
	public TextMeshProUGUI player2Health;
	public Image player1HpBar;
	public Image player2HpBar;

	public TextMeshProUGUI sharedGold;

	public GameObject encyclopedia;

	public GameObject dialogueBox;

	public TextMeshProUGUI dialogue;



	// Use this for initialization
	void Start () 
	{
		gameManager = UIManager.instance.gameManager;
		foreach (var player in gameManager.playerList)
		{
			player.GetComponent<Health>().EventOnHealthChange.AddListener(UpdateUIText);
		}
		UpdateUIText();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			encyclopedia.GetComponent<Animator>().SetTrigger("Open");
		}
	}

	
	void UpdateUIText()
	{
		player1Health.text = gameManager.playerList[0].GetComponent<Health>().health.ToString();
		sharedGold.text = gameManager.sharedInventory.GetComponent<Currency>().gold.ToString();
		player2Health.text = gameManager.playerList[1].GetComponent<Health>().health.ToString();


		
		player1HpBar.fillAmount = gameManager.playerList[0].GetComponent<Health>().health / gameManager.playerList[0].GetComponent<Health>().maxHealth;
		player2HpBar.fillAmount = gameManager.playerList[1].GetComponent<Health>().health / gameManager.playerList[1].GetComponent<Health>().maxHealth;
	}
}
