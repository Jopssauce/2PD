using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchAnimation : MonoBehaviour {

	[SerializeField]
	private GameObject LightSource;

	private Animator am;

	// Use this for initialization
	void Start () 
	{
		am = GetComponent<Animator> ();
	}

	public void TorchActivated()
	{
		am.SetBool ("TorchOn", true);
		LightSource.SetActive (true);
	}
}
