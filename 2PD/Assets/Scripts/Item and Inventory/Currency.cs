using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {

	GameManager gameManager;
	public float gold;

	void Start()
	{
		gameManager = GameManager.instance;
	}

	void LateUpdate()
	{
		float goldtoAdd = 0;
		foreach (var item in gameManager.playerList)
		{
			goldtoAdd += item.GetComponent<PlayerStats>().gold;
		}
		gold = goldtoAdd;
	}
}

