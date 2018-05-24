using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour {

	GameManager gameManager;

	public TextMeshProUGUI player1Health;
	public TextMeshProUGUI player2Health;

	public TextMeshProUGUI player1Gold;
	public TextMeshProUGUI player2Gold;

	// Use this for initialization
	void Start () 
	{
		gameManager = UIManager.instance.gameManager;
		foreach (var player in gameManager.playerList)
		{
			player.GetComponent<PlayerStats>().EventOnStatChanged.AddListener(UpdateUIText);
		}
		UpdateUIText();
	}

	
	void UpdateUIText()
	{
		player1Health.text = gameManager.playerList[0].GetComponent<PlayerStats>().hp.ToString();
		player1Gold.text = gameManager.playerList[0].GetComponent<PlayerStats>().gold.ToString();
	}
}
