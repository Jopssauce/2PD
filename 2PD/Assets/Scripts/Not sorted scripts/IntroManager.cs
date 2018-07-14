using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {
	public List<PlayerController> players;
	public GameObject grid;
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

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.GetComponent<PlayerController>())
		{
			 grid.transform.position = this.transform.position; 
			 this.transform.position += -Vector3.up * 2f;
		}
	}
}
