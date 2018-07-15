using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using XInputDotNetPure;

public class PlayerController : MonoBehaviour 
{
    public int ID;
	[SerializeField]
    public PlayerIndex playerIndex;

    public float playerSpeed;
	public bool canMove = true;
	public bool canInteract = true;
    public bool canCombat = true;
	public bool isMoving = false;
    public Vector3 direction;
	public Vector3 lastPos;
	public int lastDirection;
	public List<GameObject> directions;

  

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

	public UnityEvent EventOnDialogue;
	public class eventOnInteract : UnityEvent<GameObject>
    {

    }
    public eventOnInteract EventOnInteract = new eventOnInteract();
	public UnityEvent EventOnInteractInput;
    public UnityEvent EventOnHoldInteract;
    //[SyncEvent]
    public  UnityEvent EventOnAttack;

    public GameObject projectilePrefab;
	public GameObject projectileSpawnPoint;
   

    public virtual void Start()
    {
        EventOnLeft.AddListener (MoveLeft);
        EventOnRight.AddListener (MoveRight);
        EventOnUp.AddListener (MoveUp);
		EventOnDown.AddListener (MoveDown);
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
			direction = -transform.right;
			lastDirection = 2;
            //transform.eulerAngles = transform.forward * 90;
			GetComponent<SpriteRenderer> ().flipX = false;
		}
	}
	public virtual void MoveRight()
	{
		{
			transform.position += new Vector3 ( 1 * playerSpeed * Time.deltaTime , 0, 0);
			direction = transform.right;
			lastDirection = 3;
			GetComponent<SpriteRenderer> ().flipX = true;
            //transform.eulerAngles = -transform.forward * 90;
		}
	}
    public virtual void MoveUp()
	{
		{
			transform.position += new Vector3 ( 0, 1 * playerSpeed * Time.deltaTime, 0);
			direction = transform.up;
			lastDirection = 0;
            //transform.eulerAngles = transform.forward * 0;
		}
	}
	public virtual void MoveDown()
	{
		{
			transform.position += new Vector3 ( 0, -1 * playerSpeed * Time.deltaTime, 0);
			direction = -transform.up;
			lastDirection = 1;
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
