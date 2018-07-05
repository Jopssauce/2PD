using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour {
	GameManager gameManager;
	
	public UnityEvent EventSettingCheckPoint;
	public UnityEvent EventCheckpointSet;
	void Start () 
	{
		gameManager = GameManager.instance;
		EventSettingCheckPoint.AddListener(SetCheckpoint);
	}
	
	public void SetCheckpoint()
	{
		gameManager.checkpoint = this.gameObject;
		EventCheckpointSet.Invoke();
	}
}
