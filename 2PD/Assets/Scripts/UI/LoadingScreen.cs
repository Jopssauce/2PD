using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {
	SceneLoader sceneLoader;	
	public Text progress;
	void Start () {
		sceneLoader = SceneLoader.instance;
	}
	
	// Update is called once per frame
	void Update () {
		if(sceneLoader.sceneAsync == null) sceneLoader = SceneLoader.instance;
		progress.text = sceneLoader.sceneAsync.progress * 100 + "%";
	}
}
