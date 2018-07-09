using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class PlayerInput : MonoBehaviour {
	PlayerController player;
	UIManager uiManager;

	GamePadState state;
	GamePadState prevState;

	public KeyCode attack;
	public KeyCode interact;
	public KeyCode skillForward = KeyCode.X;
	public KeyCode skillBackward = KeyCode.Z;


	 public virtual void Start()
    {
		player = GetComponent<PlayerController>();
    }
	void LateUpdate()
	{
		if(uiManager == null) uiManager = UIManager.instance;
	}
	void Update()
	{
		prevState = state;
        state = GamePad.GetState(player.playerIndex);
		if (Input.GetKeyDown(interact) || prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && player.canInteract == true) 
		{
			player.EventOnInteract.Invoke(player.gameObject);
		}
		if (Input.GetKeyDown(attack) || prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed && player.canCombat == true) 
		{
			player.EventOnAttack.Invoke();
		}
		if ((Input.GetKeyDown(skillForward)) || prevState.Buttons.RightShoulder == ButtonState.Released && state.Buttons.RightShoulder == ButtonState.Pressed)
		{
			GetComponent<SkillActor>().EventOnSkillForward.Invoke();
		}
		if ((Input.GetKeyDown(skillBackward)) || prevState.Buttons.LeftShoulder == ButtonState.Released && state.Buttons.LeftShoulder == ButtonState.Pressed)
		{
			GetComponent<SkillActor>().EventOnSkillBackward.Invoke();
		}
		if (prevState.Buttons.Y == ButtonState.Released && state.Buttons.Y == ButtonState.Pressed)
		{
			uiManager.CanvasUI.OpenEnycloepdia();
		}
	}
	public virtual void FixedUpdate()
	{
		
		Vector3 curPos = transform.position;
		if(curPos == player.lastPos)
		{
			player.isMoving = false;
		}
		else
		{
			player.isMoving = true;
		}
		player.lastPos = curPos;

        //if (!isLocalPlayer) return;
		if (player.canMove == true && player.ID == 0) 
		{
			if (state.ThumbSticks.Left.X < 0 || state.DPad.Left == ButtonState.Pressed || Input.GetAxisRaw("KeyboardX1") < 0) 
			{
				//Debug.Log ("Horizontal");
				player.EventOnLeft.Invoke();
                player.EventOnMove.Invoke();
			}
			if (state.ThumbSticks.Left.X > 0 || state.DPad.Right == ButtonState.Pressed || Input.GetAxisRaw("KeyboardX1") > 0) 
			{
				//Debug.Log ("Horizontal");
				player.EventOnRight.Invoke();
                player.EventOnMove.Invoke();
			}
            if (state.ThumbSticks.Left.Y < 0 || state.DPad.Down == ButtonState.Pressed || Input.GetAxisRaw("KeyboardY1") < 0) 
			{
				//Debug.Log ("Vertical");
				player.EventOnDown.Invoke();
                player.EventOnMove.Invoke();
			}
			if (state.ThumbSticks.Left.Y > 0 || state.DPad.Up == ButtonState.Pressed || Input.GetAxisRaw("KeyboardY1") > 0) 
			{
				//Debug.Log ("Vertical");
				player.EventOnUp.Invoke();
                player.EventOnMove.Invoke();
			}
		}
		if (player.canMove == true && player.ID == 1) 
		{
			if (state.ThumbSticks.Left.X < 0 || state.DPad.Left == ButtonState.Pressed || Input.GetAxisRaw("KeyboardX2") < 0) 
			{
				//Debug.Log ("Horizontal2");
				player.EventOnLeft.Invoke();
                player.EventOnMove.Invoke();
			}
			if (state.ThumbSticks.Left.X > 0 || state.DPad.Right == ButtonState.Pressed || Input.GetAxisRaw("KeyboardX2") > 0) 
			{
				//Debug.Log ("Horizontal2");
				player.EventOnRight.Invoke();
                player.EventOnMove.Invoke();
			}
            if (state.ThumbSticks.Left.Y < 0 || state.DPad.Down == ButtonState.Pressed || Input.GetAxisRaw("KeyboardY2") < 0) 
			{
				//Debug.Log ("Vertical2");
				player.EventOnDown.Invoke();
                player.EventOnMove.Invoke();
			}
			if (state.ThumbSticks.Left.Y > 0 || state.DPad.Up == ButtonState.Pressed || Input.GetAxisRaw("KeyboardY2") > 0) 
			{
				//Debug.Log ("Vertical2");
				player.EventOnUp.Invoke();
                player.EventOnMove.Invoke();
			}
		}
	
	
	}
}
