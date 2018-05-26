using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour 
{
	GameManager gameManager;
	public List<PlayerController> players;
	public Bounds playerBounds; 
	public float minZoom, maxZoom;
	public float cameraSpeed = 4f;
	public Vector3 offset;
	Vector3 velocity;
	public float smooth = 0.5f;
	public float maxWidth = 20f;
	public float test;
	// Use this for initialization
	void Start () 
	{
		gameManager = GameManager.instance;
		foreach (var item in gameManager.playerList)
		{
			players.Add(item);
		}
	}

	
	void LateUpdate()
	{
		GetPlayerBounds();
		if(gameManager.playerList.Count == 0) return;

		Vector3 newPos = playerBounds.center + offset;

		transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smooth);
		Zoom();
	}

	void Zoom()
	{
		//Debug.Log( playerBounds.size.x + "  "  + playerBounds.size.x / maxWidth );
		float zoom = Mathf.Lerp(minZoom, maxZoom, playerBounds.size.x - playerBounds.size.y / maxWidth);
		Camera.main.fieldOfView =  Mathf.Lerp(Camera.main.fieldOfView, zoom, Time.deltaTime);
	}

	public void GetPlayerBounds()
	{
		playerBounds = new Bounds(players[0].transform.position, Vector3.zero);
		foreach (var item in players)
		{
			playerBounds.Encapsulate(item.transform.position);
		}
	}
	
	
}
