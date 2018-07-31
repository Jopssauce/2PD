using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Linq;

[System.Serializable]
public class SceneEvents : UnityEvent<Scene> { }

public class SceneLoader : MonoBehaviour {

	public static SceneLoader instance;
    public Canvas loadingScreen;
    string seenToActive;
    public SceneEvents EventSceneLoaded;
    public AsyncOperation sceneAsync;
    // Use this for initialization
    void Awake()
    {
        instance = this;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneLoaded += ReturnLoadedScene;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {

            for (int i = 0; i < GetSceneAmount("Floor 1") - 1; i++)
            {
                SceneManager.UnloadSceneAsync("Floor 1");
            }
            if (isSceneOpen("UI Scene")) SceneManager.UnloadSceneAsync("UI Scene");
            StartChangeScene("Floor 1");


        }
        if (Input.GetKeyDown(KeyCode.F6))
        {

            if (isSceneOpen("UI Scene")) SceneManager.UnloadSceneAsync("UI Scene");
            StartChangeScene("Floor 2");


        }
    }

    public void StartChangeScene(string scene)
    {
        AsyncOperation asnyc = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        sceneAsync = asnyc;
        StartCoroutine(ChangeScene(asnyc, scene));
    }

    public bool isSceneOpen(string SceneName)
    {
        Scene scene = SceneManager.GetSceneByName(SceneName);
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i) == scene)
            {

                return true;
            }
        }
        return false;
    }

    public int GetSceneAmount(string sceneName)
    {
        int amt = 0;
        //return SceneManager.GetAllScenes().Count(scene => scene.name == sceneName);
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == sceneName) amt++;
        }
        return amt;
    }

    public IEnumerator ChangeScene(AsyncOperation asnyc, string scene)
    {
        seenToActive = scene;
        loadingScreen.gameObject.SetActive(true);
        yield return asnyc.isDone;
        Debug.Log("Test");
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (!SceneManager.GetSceneByName(seenToActive).isLoaded) return;
        StartCoroutine(SetSceneToActive());

    }

    IEnumerator SetSceneToActive()
    {
        yield return new WaitForSeconds(1);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(seenToActive));
        loadingScreen.gameObject.SetActive(false);
    }

    void ReturnLoadedScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        EventSceneLoaded.Invoke(scene);
    }
}
