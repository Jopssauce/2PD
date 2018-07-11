using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

	public TextMeshProUGUI dialogue;

	[HideInInspector]
	public bool isGamePaused = false;

	[SerializeField]
	private GameObject firstSelectedButton;



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

	public IEnumerator HideDialogue()
	{
		float timer = 5.0f;
		yield return new WaitForSeconds(timer);
		dialogueBox.SetActive (false);
		Debug.Log ("Seconds Done");
	}

	public void OpenEnycloepdia()
	{
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
