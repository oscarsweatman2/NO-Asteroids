using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD : MonoBehaviour {

	public float horizontalCushion;
	public float verticalCushion;
	public float size = 3.0f;

	public enum anchorCorner { TopLeft, TopRight, BottomLeft, BottomRight };
	public anchorCorner anchorLocation;

	public List<Texture> matLives;
	public int currentMatLives;

	private Texture currentTexture;

	private Vector3 screenPoint;

	// Use this for initialization
	void Start () {
		if (anchorLocation == anchorCorner.TopLeft)
		{
			screenPoint = new Vector3((Camera.main.pixelWidth * (horizontalCushion/100)), (Camera.main.pixelHeight * (-verticalCushion/100)) + Camera.main.pixelHeight, 0.0f);
		}
		else if (anchorLocation == anchorCorner.TopRight)
		{
			screenPoint = new Vector3((Camera.main.pixelWidth * (-horizontalCushion/100)) + Camera.main.pixelWidth, (Camera.main.pixelHeight * (-verticalCushion/100)) + Camera.main.pixelHeight, 0.0f);
		}
		else if (anchorLocation == anchorCorner.BottomLeft)
		{
			screenPoint = new Vector3((Camera.main.pixelWidth * (horizontalCushion/100)), (Camera.main.pixelHeight * (verticalCushion/100)), 0.0f);
		}
		else if (anchorLocation == anchorCorner.BottomRight)
		{
			screenPoint = new Vector3((Camera.main.pixelWidth * (-horizontalCushion/100)) + Camera.main.pixelWidth, (Camera.main.pixelHeight * (verticalCushion/100)), 0.0f);
			
		}
		
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPoint);
		transform.position = new Vector3(worldPos.x, worldPos.y, -1.0f);
		transform.localScale = new Vector3(size, size, size);

		currentMatLives = 3;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void AdjustNumLives(int livesChange)
	{
		currentMatLives += livesChange;
		renderer.material.SetTexture(0, matLives[currentMatLives]);
	}
}
