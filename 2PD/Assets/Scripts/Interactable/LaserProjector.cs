using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjector : MonoBehaviour {
	LineRenderer lr;
	public float range = 3;
	public bool isOn = true;
	Vector3 laserTargetPos;
	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer>();
		lr.startWidth = .07f;
		lr.endWidth = .07f;
	}
	
 	void FixedUpdate() 
	 {
		if(isOn == false) 
		{
			lr.SetPosition(1, this.transform.position);
			return;
		}
		lr.SetPosition(0, this.transform.position);
		lr.SetPosition(1, laserTargetPos);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
		Debug.Log(hit.collider);
        if (hit.collider != null && hit.collider.name != "Walls") 
		{
			if (Vector2.Distance(this.transform.position, hit.collider.transform.position) < range )
			{
				laserTargetPos = new Vector3( this.transform.position.x, ( hit.transform.position.y), this.transform.position.z);
			}
        }
		else
		{
			laserTargetPos = transform.position + Vector3.up * range;
		}
		
    }


	 void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.up) * range;
        Gizmos.DrawRay(transform.position, direction);
    }
}
