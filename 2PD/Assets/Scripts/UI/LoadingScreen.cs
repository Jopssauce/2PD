using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {
	PersistentDataManager dataManager;	
	public Text progress;
	void Start () {
		dataManager = PersistentDataManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		if(dataManager.sceneAsync == null) dataManager = PersistentDataManager.instance;
		progress.text = dataManager.sceneAsync.progress * 100 + "%";
	}
}
