
using UnityEngine;

public class Cursor : MonoBehaviour
{
	public float Depth = 0.0f;
	[HideInInspector]
	public bool isVisible = true;

	void LateUpdate()
	{
		Vector3 mp = Input.mousePosition;
		mp.z = 1.0f;
		Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		wp.z = Depth;

		transform.position = wp;
		

//		Debug.Log (wp.x + ", " + wp.y + ", " + wp.z);
//		Debug.Log (mp.x + ", " + mp.y + ", " + mp.z);
	}

	void Update()
	{
		if (isVisible) {	renderer.enabled = true;	} else {	renderer.enabled = false;	}
	}
}
