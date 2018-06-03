using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaCanvas : MonoBehaviour {

	[SerializeField]
	private Canvas encyclopediaCanvas;
	private bool isShowing;
	void Start () 
	{
		encyclopediaCanvas.gameObject.SetActive (true);
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.B))
		{
			//isShowing = !isShowing;
			Debug.Log (isShowing);
			if (isShowing) 
			{
				encyclopediaCanvas.gameObject.SetActive (true);
				isShowing = false;
			}

			else
			{
				encyclopediaCanvas.gameObject.SetActive (false);
				isShowing = true;
			}
		}
	}
}
