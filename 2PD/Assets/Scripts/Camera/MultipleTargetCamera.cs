using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleTargetCamera : MonoBehaviour 
{
	GameManager gameManager;
	public bool isEnabled = true;
	public List<PlayerController> players;
	public Bounds playerBounds; 
	public float minZoom, maxZoom;
	public float cameraSpeed = 4f;
	public Vector3 offset;
	Vector3 velocity;
	public float smooth = 0.5f;
	public float maxWidth = 20f;
	public float test;

	float zoom;
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
		if(!isEnabled) return;
		GetPlayerBounds();
		if(gameManager.playerList.Count == 0) return;

		Vector3 newPos = playerBounds.center + offset;

		transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smooth);
		Zoom();
	}

	void Zoom()
	{
		zoom = Mathf.Lerp(minZoom, maxZoom, playerBounds.size.magnitude / maxWidth);
		Camera.main.orthographicSize =  Mathf.Lerp(Camera.main.orthographicSize, zoom, Time.deltaTime);
		//transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, -zoom, Time.deltaTime));
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
