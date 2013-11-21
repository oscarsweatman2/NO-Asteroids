using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public float horizontalCushion;
	public float verticalCushion;
	public float size = 3.0f;

	public enum anchorCorner { TopLeft, TopRight, BottomLeft, BottomRight };
	public anchorCorner anchorLocation;
	
	public Texture matLives0;
	public Texture matLives1;
	public Texture matLives2;
	public Texture matLives3;

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

	}
	
	// Update is called once per frame
	void Update () {

	}
}
