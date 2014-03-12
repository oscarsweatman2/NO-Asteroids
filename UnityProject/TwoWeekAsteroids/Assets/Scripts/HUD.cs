using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUD : MonoBehaviour {

	public enum HUDcontent { Lives,Score };
	public HUDcontent HUDtype;

	public float horizontalCushion;
	public float verticalCushion;
	public float size = 3.0f;

	public enum anchorCorner { TopLeft, TopRight, BottomLeft, BottomRight };
	public anchorCorner anchorLocation;

	public List<Texture> matLives;
	public int currentMatLives;
	public int currentScore;
	private Color scoreColor;
	public Font HUDfont;

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

		// ----- LIVES behavior -----
		currentMatLives = 3;

		// ----- SCORE behavior -----

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AdjustScore(int scoreChange)
	{
		currentScore += scoreChange;
	}

	public void AdjustNumLives(int livesChange)
	{
		if (currentMatLives >= 0)
		{
			currentMatLives += livesChange;
			renderer.material.SetTexture(0, matLives[currentMatLives]);
		}
		else
		{

		}
	}

	void OnGUI()
	{
		if (HUDtype == HUDcontent.Score)
		{
			//GUI.color = scoreColor;
			GUI.skin.font = HUDfont;
			GUI.Label (new Rect(screenPoint.x - 80, Camera.main.pixelHeight - screenPoint.y -10, 200, 20), "" + currentScore);
		}
	}
}
