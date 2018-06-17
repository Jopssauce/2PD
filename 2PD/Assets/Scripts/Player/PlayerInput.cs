using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
public class PlayerInput : MonoBehaviour {
	PlayerController player;

	GamePadState state;
	GamePadState prevState;

	public KeyCode attack;
	public KeyCode interact;
	public KeyCode switchSkill = KeyCode.Z;


	 public virtual void Start()
    {
		player = GetComponent<PlayerController>();
    }
	void Update()
	{
		prevState = state;
        state = GamePad.GetState(player.playerIndex);
		if (Input.GetKeyDown(interact) || prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed && player.canInteract == true) 
		{
			player.EventOnInteract.Invoke(player);
		}
		if (Input.GetKeyDown(attack) || prevState.Buttons.B == ButtonState.Released && state.Buttons.B == ButtonState.Pressed && player.canCombat == true) 
		{
			player.EventOnAttack.Invoke();
		}
		if ((Input.GetKeyDown(switchSkill)))
		{
			GetComponent<SkillActor>().EventOnSwitchSkill.Invoke();
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
		if (player.canMove == true && player.playerID == 0) 
		{
			if (state.ThumbSticks.Left.X < 0 || Input.GetAxisRaw("KeyboardX1") < 0) 
			{
				//Debug.Log ("Horizontal");
				player.EventOnLeft.Invoke();
                player.EventOnMove.Invoke();
			}
			if (state.ThumbSticks.Left.X > 0 || Input.GetAxisRaw("KeyboardX1") > 0) 
			{
				//Debug.Log ("Horizontal");
				player.EventOnRight.Invoke();
                player.EventOnMove.Invoke();
			}
            if (state.ThumbSticks.Left.Y < 0 || Input.GetAxisRaw("KeyboardY1") < 0) 
			{
				//Debug.Log ("Vertical");
				player.EventOnDown.Invoke();
                player.EventOnMove.Invoke();
			}
			if (state.ThumbSticks.Left.Y > 0 || Input.GetAxisRaw("KeyboardY1") > 0) 
			{
				//Debug.Log ("Vertical");
				player.EventOnUp.Invoke();
                player.EventOnMove.Invoke();
			}
		}
		if (player.canMove == true && player.playerID == 1) 
		{
			if (state.ThumbSticks.Left.X < 0 || Input.GetAxisRaw("KeyboardX2") < 0) 
			{
				//Debug.Log ("Horizontal2");
				player.EventOnLeft.Invoke();
                player.EventOnMove.Invoke();
			}
			if (state.ThumbSticks.Left.X > 0 || Input.GetAxisRaw("KeyboardX2") > 0) 
			{
				//Debug.Log ("Horizontal2");
				player.EventOnRight.Invoke();
                player.EventOnMove.Invoke();
			}
            if (state.ThumbSticks.Left.Y < 0 || Input.GetAxisRaw("KeyboardY2") < 0) 
			{
				//Debug.Log ("Vertical2");
				player.EventOnDown.Invoke();
                player.EventOnMove.Invoke();
			}
			if (state.ThumbSticks.Left.Y > 0 || Input.GetAxisRaw("KeyboardY2") > 0) 
			{
				//Debug.Log ("Vertical2");
				player.EventOnUp.Invoke();
                player.EventOnMove.Invoke();
			}
		}
	
	
	}
}
