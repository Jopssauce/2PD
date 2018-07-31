using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIManager uiManager;
    public PersistentDataManager persistentData;
    public SceneLoader sceneLoader;
    public bool isRespawning = false;
    public List<PlayerController> playerList;
    public Inventory sharedInventory;
    public GameObject checkpoint;
    public UnityEvent OnStart;
    public UnityEvent EventLoadingCheckpoint;
    public UnityEvent EventLoadedCheckpoint;
    public GameObject debugSpawn;
    IEnumerator respawn;
    IEnumerator disablePlayers;
    void Awake()
    {
        instance = this;
        int id = 0;
        foreach (var player in playerList)
        {
            player.ID = id;
            id++;
        }
        if (!isPersistentOpen()) SceneManager.LoadSceneAsync("Persistent Scene", LoadSceneMode.Additive);
        if (sceneLoader.isSceneOpen("UI Scene")) SceneManager.LoadSceneAsync("UI Scene", LoadSceneMode.Additive);
    }

    // Use this for initialization
    void Start()
    {
        if (persistentData == null)
        {
            persistentData = PersistentDataManager.instance;
            sharedInventory.itemInventory = persistentData.sharedInventory.itemInventory.ToList();
        }
        OnStart.Invoke();
    }

    void LateUpdate()
    {
        if (uiManager == null) uiManager = UIManager.instance;
        if (persistentData == null) persistentData = PersistentDataManager.instance;
        if (sceneLoader == null) sceneLoader = SceneLoader.instance;
        if (playerList.Any(player => player.GetComponent<Health>().health <= 0) && !isRespawning)
        {
            isRespawning = true;
            respawn = RespawnPlayers();
            StartCoroutine(respawn);
        }
        if (Input.GetKeyDown(KeyCode.F2) && isRespawning == false)
        {
            if (debugSpawn == null) return;
            foreach (var player in playerList)
            {
                player.transform.position = debugSpawn.transform.position;
            }
        }

    }


    bool isPersistentOpen()
    {
        Scene UIscene = SceneManager.GetSceneByName("Persistent Scene");
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i) == UIscene)
            {

                return true;
            }
        }
        return false;
    }



    public IEnumerator RespawnPlayers()
    {
		disablePlayers = DisablePlayers();
		StartCoroutine(disablePlayers);
        EventLoadingCheckpoint.Invoke();
        yield return new WaitForSeconds(5);
		StopCoroutine(disablePlayers);
        if (checkpoint == null)
        {
            SceneManager.UnloadSceneAsync("UI Scene");
            sceneLoader.StartChangeScene("Game Over Scene");
            yield break;
        }
        foreach (var player in playerList)
        {
            player.GetComponent<Health>().AddHp(player.GetComponent<Health>().maxHealth);
            player.transform.position = checkpoint.transform.position;
            player.canMove = true;
            player.canCombat = true;
            player.canInteract = true;
        }
        isRespawning = false;
        uiManager.CanvasUI.youDied.gameObject.SetActive(false);
        EventLoadedCheckpoint.Invoke();
    }

    public IEnumerator DisablePlayers()
    {
        while (true)
        {
            foreach (var player in playerList)
            {
                player.canMove = false;
                player.canCombat = false;
                player.canInteract = false;
                uiManager.CanvasUI.youDied.gameObject.SetActive(true);
            }
            yield return new WaitForSecondsRealtime(0.2f);
        }
    }
}
