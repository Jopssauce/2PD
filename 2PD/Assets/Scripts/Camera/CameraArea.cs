using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraArea : MonoBehaviour {

	GameManager gameManager;
	public bool isEnabled = true;
	public bool isTransitioning;
	public bool activateOnTriggerEnter = true;
	public float transitionInterval = 1f;
	public float minZoom, maxZoom;
	public float smooth = 0.5f;
	public float maxWidth = 20f;
	float zoom;
	int index = 0;
	Vector3 velocity;
	Vector3 newPos;
	public UnityEvent EventActivated;
	public UnityEvent EventDeactivated;

	public List<CameraDestination> destinations;

	IEnumerator transition;

	void LateUpdate()
	{
		if(!isTransitioning) return;

		Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, newPos, ref velocity, smooth);
		Zoom();
	}

	void Zoom()
	{
		//zoom = Mathf.Lerp(minZoom, maxZoom, playerBounds.size.magnitude / maxWidth);
		Camera.main.orthographicSize =  Mathf.Lerp(Camera.main.orthographicSize, zoom, Time.deltaTime);
		//transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, -zoom, Time.deltaTime));
	}

	public IEnumerator StartTransition()
	{	
		isTransitioning = true;	
		Camera.main.GetComponent<MultipleTargetCamera>().isEnabled = false;
		while (isTransitioning && destinations.Count > 0 && index != destinations.Count)
		{
			newPos = destinations[index].transform.position;
			zoom = destinations[index].zoom;
			Debug.Log(index);
			yield return new WaitForSeconds(transitionInterval);
			index++;
		}
		isTransitioning = false;
		Deactivate();
	}

	public void Activate()
	{
		if(isTransitioning) return;
		transition = StartTransition();
		StartCoroutine(transition);
		EventActivated.Invoke();
	}

	public void Deactivate()
	{
		isTransitioning = false;
		Debug.Log("Deactivate");
		Camera.main.GetComponent<MultipleTargetCamera>().isEnabled = true;
		index = 0;
		StopAllCoroutines();
		EventDeactivated.Invoke();
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(!activateOnTriggerEnter) return;
		if(!col.gameObject.CompareTag("Player")) return;
		if(isTransitioning) return;
		Activate();
	}
}
