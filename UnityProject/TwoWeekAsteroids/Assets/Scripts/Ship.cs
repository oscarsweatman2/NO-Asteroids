using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
	public float WorldWidth = 10.0f;
	public float WorldHeight = 10.0f;
	
	public float Speed = 5.0f;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * Speed * Time.deltaTime);
		
		Vector3 p = transform.position;
		
		float halfWidth = WorldWidth * 0.5f;
		float halfHeight = WorldHeight * 0.5f;
		
		if (p.x > halfWidth)
			p.x -= WorldWidth;
		else if (p.x < -halfWidth)
			p.x += WorldWidth;
		
		if (p.y > halfHeight)
			p.y -= WorldHeight;
		else if (p.y < -halfHeight)
			p.y += WorldHeight;
		
		transform.position = p;
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		
		float l = WorldWidth * -0.5f;
		float r = -l;
		float t = WorldHeight * 0.5f;
		float b = -t;
		
		Gizmos.DrawLine(new Vector3(l, t, 0.0f), new Vector3(r, t, 0.0f));
		Gizmos.DrawLine(new Vector3(r, t, 0.0f), new Vector3(r, b, 0.0f));
		Gizmos.DrawLine(new Vector3(r, b, 0.0f), new Vector3(l, b, 0.0f));
		Gizmos.DrawLine(new Vector3(l, b, 0.0f), new Vector3(l, t, 0.0f));
	}
}
