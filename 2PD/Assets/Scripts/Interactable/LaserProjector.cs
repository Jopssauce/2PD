using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjector : MonoBehaviour {
	LineRenderer lr;
	public float range = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}


	 void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 direction = transform.TransformDirection(Vector3.up) * range;
        Gizmos.DrawRay(transform.position, direction);
    }
}
