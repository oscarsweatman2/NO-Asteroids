using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
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

		float w = World.Width;
		float h = World.Height;
		
		if (p.x > World.Right)
			p.x -= w;
		else if (p.x < World.Left)
			p.x += w;
		
		if (p.y > World.Top)
			p.y -= h;
		else if (p.y < World.Bottom)
			p.y += h;
		
		transform.position = p;
	}
}
