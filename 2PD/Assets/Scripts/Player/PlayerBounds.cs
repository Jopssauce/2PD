using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour 
{
	public int offset;
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

		if(worldToScreenPoint.x >= cameraPixel.x - offset)
		{
			pos.x = main.ScreenToWorldPoint(new Vector2(cameraPixel.x  - offset, worldToScreenPoint.y) ).x;
		}
		if(worldToScreenPoint.x <= offset)
		{
			pos.x = main.ScreenToWorldPoint(new Vector2(offset, worldToScreenPoint.y) ).x;
		}

		if(worldToScreenPoint.y >= cameraPixel.y - offset)
		{
			pos.y = main.ScreenToWorldPoint(new Vector2(worldToScreenPoint.x, cameraPixel.y - offset) ).y;
		}
		if(worldToScreenPoint.y <= offset)
		{
			pos.y = main.ScreenToWorldPoint(new Vector2(worldToScreenPoint.x, offset) ).y;
		}
		transform.position = pos;
	}
	
}
