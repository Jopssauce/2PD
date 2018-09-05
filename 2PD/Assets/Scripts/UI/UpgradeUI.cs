using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour 
{
	public Text health1;
	public Text damage1;
	public PlayerController player1;
	
	// Update is called once per frame
	void Update () {
		health1.text = player1.GetComponent<Health>().maxHealth.ToString();
		damage1.text = player1.GetComponent<PlayerCombat>().damage.ToString();
	}
}
