using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour {
	GameManager gameManager;
	public Animator anim;
	
	public UnityEvent EventSettingCheckPoint;
	public UnityEvent EventCheckpointSet;
	void Start () 
	{
		anim = GetComponent<Animator>();
		gameManager = GameManager.instance;
		EventSettingCheckPoint.AddListener(SetCheckpoint);
	}
	
	public void SetCheckpoint()
	{
		gameManager.checkpoint = this.gameObject;
		anim.SetBool("IsActivated", true);
		EventCheckpointSet.Invoke();
	}
}
