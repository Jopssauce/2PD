using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CanvasController : MonoBehaviour {

	GameManager gameManager;

	public TextMeshProUGUI player1Health;
	public TextMeshProUGUI player2Health;
	public TextMeshProUGUI youDied;
	public Image player1HpBar;
	public Image player2HpBar;
    public Image player1SkillGem;
    public Image player2SkillGem;

    public TextMeshProUGUI sharedGold;

	public GameObject encyclopedia;

	public GameObject dialogueBox;

	public GameObject pauseMenu;

	public TextMeshProUGUI dialogue;

	public CheckpointAnim checkpointAnim;

	[HideInInspector]
	public bool isGamePaused = false;

	[SerializeField]
	private GameObject firstSelectedButtonEncyclopedia;

	[SerializeField]
	private GameObject firstSelectedButtonPause;

	[SerializeField]
	private GameObject firstSelectedDialogueButton;

	[SerializeField]
	private EventSystem eventSystem;



	// Use this for initialization
	void Start () 
	{
		gameManager = UIManager.instance.gameManager;
		foreach (var player in gameManager.playerList)
		{
            player.GetComponent<Health>().EventOnHealthChange.AddListener(UpdateUIText);
            player.GetComponent<SkillActor>().EventOnSkillBackward.AddListener(UpdateUIText);
            player.GetComponent<SkillActor>().EventOnSkillForward.AddListener(UpdateUIText);
        }
		UpdateUIText();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			//encyclopedia.GetComponent<Animator>().SetTrigger("Open");
			if (!isGamePaused)
			{
				Pause (encyclopedia);
			}
			else
			{
				Resume (encyclopedia);
			}
		}
	}

	
	void UpdateUIText()
	{
		player1Health.text = gameManager.playerList[0].GetComponent<Health>().health.ToString();
		sharedGold.text = gameManager.sharedInventory.GetComponent<Currency>().gold.ToString();
		player2Health.text = gameManager.playerList[1].GetComponent<Health>().health.ToString();

		
		player1HpBar.fillAmount = gameManager.playerList[0].GetComponent<Health>().health / gameManager.playerList[0].GetComponent<Health>().maxHealth;
		player2HpBar.fillAmount = gameManager.playerList[1].GetComponent<Health>().health / gameManager.playerList[1].GetComponent<Health>().maxHealth;

        player1SkillGem.sprite = gameManager.playerList[0].GetComponent<SkillActor>().currentSkill.sprite;
        player2SkillGem.sprite = gameManager.playerList[1].GetComponent<SkillActor>().currentSkill.sprite;
	}

	public void Resume(GameObject UIElement)
	{
		encyclopedia.GetComponent<InventoryActor>().interactable = null;
		UIElement.SetActive (false);
		Time.timeScale = 1.0f;
		isGamePaused = false;
	}

	public void Pause(GameObject UiElement)
	{
		UiElement.SetActive (true);
		Time.timeScale = 0.0f;
		isGamePaused = true;
	}

	public void HideDialogue()
	{
		Time.timeScale = 1.0f;
		dialogueBox.SetActive (false);
		isGamePaused = false;
	}

	public IEnumerator HideCheckpointNotif()
	{
		float timer = 3.0f;
		yield return new WaitForSecondsRealtime(timer);
		checkpointAnim.ChangeAnimState (false);
	}

	public void OpenEnycloepdia()
	{
		eventSystem.SetSelectedGameObject (firstSelectedButtonEncyclopedia);
		if (!isGamePaused)
			{
				Pause (encyclopedia);
			}
			else
			{
				
				Resume (encyclopedia);
			}
	}

	public void OpenPauseMenu()
	{
		eventSystem.SetSelectedGameObject (firstSelectedButtonPause);
		Pause (pauseMenu);
	}

	public void TimeScaleControl(float timer)
	{
		Time.timeScale = timer;
	}

	public void CheckPointAnimation(bool state)
	{
		checkpointAnim.ChangeAnimState (state);
	}

	public void DialogueCanvas(string dialogueParam)
	{
		eventSystem.SetSelectedGameObject (firstSelectedDialogueButton);
		dialogueBox.SetActive (true);
		dialogue.text = dialogueParam;
		Time.timeScale = 0.0f;
		isGamePaused = true;
	}
}
