using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class PlayerController : MonoBehaviour 
{
    public int playerID;
    public float playerSpeed;
	public bool canMove = true;
	public bool canInteract = true;
    public bool canCombat = true;
    public Vector3 direction;
	public int lastDirection;
	public List<GameObject> directions;

    public KeyCode attack = KeyCode.Joystick1Button1;
	public KeyCode interact = KeyCode.Joystick1Button0;

	public KeyCode attackController = KeyCode.Joystick1Button1;
	public KeyCode interactController = KeyCode.Joystick1Button0;

    public delegate void MovementDelegate();
    //[SyncEvent]
	public UnityEvent EventOnLeft;
    //[SyncEvent]
	public UnityEvent EventOnRight;
    //[SyncEvent]
    public UnityEvent EventOnUp;
    //[SyncEvent]
	public UnityEvent EventOnDown;
    //[SyncEvent]
    public UnityEvent EventOnMove;
	public class eventOnInteract : UnityEvent<PlayerController>
    {

    }
    public eventOnInteract EventOnInteract = new eventOnInteract();
    public UnityEvent EventOnHoldInteract;
    //[SyncEvent]
    public  UnityEvent EventOnAttack;

    public GameObject projectilePrefab;
	public GameObject projectileSpawnPoint;
   

    public virtual void Start()
    {
       foreach (var item in Input.GetJoystickNames())
       {
           Debug.Log(item);
       }
            EventOnLeft.AddListener (MoveLeft);
            EventOnRight.AddListener (MoveRight);
            EventOnUp.AddListener (MoveUp);
            EventOnDown.AddListener (MoveDown);
    }

	public virtual void FixedUpdate()
	{
      
        //if (!isLocalPlayer) return;
		if (canMove == true && playerID == 0) 
		{
			if (Input.GetAxisRaw("Horizontal3") < 0 || Input.GetAxisRaw("KeyboardX1") < 0) 
			{
				Debug.Log ("Horizontal");
				EventOnLeft.Invoke();
                EventOnMove.Invoke();
			}
			if (Input.GetAxisRaw("Horizontal3") > 0 || Input.GetAxisRaw("KeyboardX1") > 0) 
			{
				Debug.Log ("Horizontal");
				EventOnRight.Invoke();
                EventOnMove.Invoke();
			}
            if (Input.GetAxisRaw("Vertical3") < 0 || Input.GetAxisRaw("KeyboardY1") < 0) 
			{
				Debug.Log ("Vertical");
				EventOnDown.Invoke();
                EventOnMove.Invoke();
			}
			if (Input.GetAxisRaw("Vertical3") > 0 || Input.GetAxisRaw("KeyboardY1") > 0) 
			{
				Debug.Log ("Vertical");
				EventOnUp.Invoke();
                EventOnMove.Invoke();
			}
		}
		if (canMove == true && playerID == 1) 
		{
			if (Input.GetAxisRaw("Horizontal4") < 0 || Input.GetAxisRaw("KeyboardX2") < 0) 
			{
				Debug.Log ("Horizontal2");
				EventOnLeft.Invoke();
                EventOnMove.Invoke();
			}
			if (Input.GetAxisRaw("Horizontal4") > 0 || Input.GetAxisRaw("KeyboardX2") > 0) 
			{
				Debug.Log ("Horizontal2");
				EventOnRight.Invoke();
                EventOnMove.Invoke();
			}
            if (Input.GetAxisRaw("Vertical4") < 0 || Input.GetAxisRaw("KeyboardY2") < 0) 
			{
				Debug.Log ("Vertical2");
				EventOnDown.Invoke();
                EventOnMove.Invoke();
			}
			if (Input.GetAxisRaw("Vertical4") > 0 || Input.GetAxisRaw("KeyboardY2") > 0) 
			{
				Debug.Log ("Vertical2");
				EventOnUp.Invoke();
                EventOnMove.Invoke();
			}
		}
		if (Input.GetKeyDown(interact) || Input.GetKeyDown(interactController) && canInteract == true) 
		{
			EventOnInteract.Invoke(this);
		}
		if (Input.GetKeyDown(attack) || Input.GetKeyDown(attackController) && canCombat == true) 
		{
			EventOnAttack.Invoke();
		}
	
	}
	


    //public override void OnStartLocalPlayer()
   // {
   //     GetComponent<Renderer>().material.color = Color.yellow;
   // }
     /* 
    [Command]
    void CmdMoveLeft()
	{
		if (Input.GetAxisRaw("Horizontal") < 0) 
		{
			transform.position += new Vector3 ( Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime , 0, 0);
            transform.eulerAngles = transform.forward * 90;
		}
	}
    [Command]
	void CmdMoveRight()
	{
		if (Input.GetAxisRaw("Horizontal") > 0) 
		{
			transform.position += new Vector3 ( Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime , 0, 0);
            transform.eulerAngles = -transform.forward * 90;
		}
	}
    [Command]
    void CmdMoveUp()
	{
		if (Input.GetAxisRaw("Vertical") > 0) 
		{
			transform.position += new Vector3 ( 0, Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime, 0);
            transform.eulerAngles = transform.forward * 0;
		}
	}
    [Command]
	void CmdMoveDown()
	{
		if (Input.GetAxisRaw("Vertical") < 0) 
		{
			transform.position += new Vector3 ( 0, Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime, 0);
            transform.eulerAngles = transform.forward * 180;
		}
	}*/
	
    /*
    [ClientRpc]
    void RpcMoveLeft()
	{
		if (Input.GetAxisRaw("Horizontal") < 0) 
		{
			transform.position += new Vector3 ( Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime , 0, 0);
            transform.eulerAngles = transform.forward * 90;
		}
	}
    [ClientRpc]
	void RpcMoveRight()
	{
		if (Input.GetAxisRaw("Horizontal") > 0) 
		{
			transform.position += new Vector3 ( Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime , 0, 0);
            transform.eulerAngles = -transform.forward * 90;
		}
	}
    [ClientRpc]
    void RpcMoveUp()
	{
		if (Input.GetAxisRaw("Vertical") > 0) 
		{
			transform.position += new Vector3 ( 0, Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime, 0);
            transform.eulerAngles = transform.forward * 0;
		}
	}
    [ClientRpc]
	void RpcMoveDown()
	{
		if (Input.GetAxisRaw("Vertical") < 0) 
		{
			transform.position += new Vector3 ( 0, Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime, 0);
            transform.eulerAngles = transform.forward * 180;
		}
	}*/

    

    public virtual void MoveLeft()
	{
		{
			transform.position += new Vector3 ( -1 * playerSpeed * Time.deltaTime , 0, 0);
			lastDirection = 2;
			direction.x = -1;
        	direction.y = 0;
            //transform.eulerAngles = transform.forward * 90;
			GetComponent<SpriteRenderer> ().flipX = false;
		}
	}
	public virtual void MoveRight()
	{
		{
			transform.position += new Vector3 ( 1 * playerSpeed * Time.deltaTime , 0, 0);
			lastDirection = 3;
			direction.x = 1;
        	direction.y = 0;
			GetComponent<SpriteRenderer> ().flipX = true;
            //transform.eulerAngles = -transform.forward * 90;
		}
	}
    public virtual void MoveUp()
	{
		{
			transform.position += new Vector3 ( 0, 1 * playerSpeed * Time.deltaTime, 0);
			lastDirection = 0;
			direction.x = 0;
        	direction.y = 1;
            //transform.eulerAngles = transform.forward * 0;
		}
	}
	public virtual void MoveDown()
	{
		{
			transform.position += new Vector3 ( 0, -1 * playerSpeed * Time.deltaTime, 0);
			lastDirection = 1;
			direction.x = 0;
        	direction.y = -1;
            //transform.eulerAngles = transform.forward * 180;
		}
	}

    public void OnCollisionEnter2D(Collision2D col)
	{
		direction = Vector3.zero;
	}
    public void OnCollisionExit2D(Collision2D col)
	{
    
	}
}
