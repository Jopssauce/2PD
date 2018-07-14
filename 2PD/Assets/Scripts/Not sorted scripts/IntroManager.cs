using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {
	public List<PlayerController> players;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var player in players)
		{
			player.EventOnDown.Invoke();
			player.EventOnMove.Invoke();
		}
	}
}
