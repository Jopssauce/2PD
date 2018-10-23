using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour 
{
	Vector3 worldToScreenPoint;
	Vector3 screenToWorldPoint;
	Vector2 cameraPixel;
	Camera main;
	Vector3 pos;

	void Start()
	{
		main = Camera.main;
	}

	void Update()
	{
		pos = transform.position;
		cameraPixel = new Vector2(main.scaledPixelWidth, main.scaledPixelHeight);
		worldToScreenPoint = main.WorldToScreenPoint(this.transform.position);
		screenToWorldPoint = main.ScreenToWorldPoint(this.transform.position);

		if(worldToScreenPoint.x >= cameraPixel.x)
		{
			pos.x = main.ScreenToWorldPoint(new Vector2(cameraPixel.x, worldToScreenPoint.y) ).x;
		}
		if(worldToScreenPoint.x <= 0)
		{
			pos.x = main.ScreenToWorldPoint(new Vector2(0, worldToScreenPoint.y) ).x;
		}

		if(worldToScreenPoint.y >= cameraPixel.y)
		{
			pos.y = main.ScreenToWorldPoint(new Vector2(worldToScreenPoint.x, cameraPixel.y) ).y;
		}
		if(worldToScreenPoint.y <= 0)
		{
			pos.y = main.ScreenToWorldPoint(new Vector2(worldToScreenPoint.x, 0) ).y;
		}
		transform.position = pos;
	}
	
}
