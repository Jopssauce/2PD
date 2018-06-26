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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        if (hit.collider != null && hit.collider.name != "Walls" && Vector2.Distance(this.transform.position, hit.collider.transform.position) < range ) 
		{
			Debug.Log(hit.collider);
			
			//laserTargetPos = new Vector3( this.transform.position.x, ( hit.transform.position.y), this.transform.position.z);
			laserTargetPos = hit.transform.position;
			
        }
		else
		{
			laserTargetPos = transform.position + transform.up * range;
		}
		
    }


	 void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Vector3 direction = transform.up * range;
        Gizmos.DrawRay(transform.position, direction);
    }
}
