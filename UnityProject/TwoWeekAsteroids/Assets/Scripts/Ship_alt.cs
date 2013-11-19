using UnityEngine;
using System.Collections;

public class Ship_alt : MonoBehaviour 
{
	public GameObject BulletType = null;
	public Cursor Cursor = null;

	public float Speed = 5.0f;
	public float FireTime = 0.5f;

	float m_fireTimer = 0.0f;
	
	// Use this for initialization
	void Start () 
	{
		m_fireTimer = FireTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(transform.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Space.World);
		transform.Translate(transform.up * Input.GetAxis("Vertical") * Speed * Time.deltaTime, Space.World);
		
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

		Vector3 pos = transform.position;
		Vector3 target = Cursor.transform.position;
		Vector3 fwd = target - pos;
		fwd.z = 0.0f;
		fwd.Normalize();
		Vector3 rht = new Vector3(fwd.y, -fwd.x, 0.0f);
		transform.up = fwd;
		//transform.right = rht;
		//transform.forward = new Vector3(0.0f, 0.0f, 1.0f);

		//transform.LookAt(Cursor.transform.position);

		m_fireTimer -= Time.deltaTime;
		if (m_fireTimer <= 0.0f)
		{
			if (Input.GetButton("Fire1"))
			{
				if (BulletType != null)
				{
					m_fireTimer = FireTime;
					Bullet bullet = (Instantiate(BulletType) as GameObject).GetComponent<Bullet>();
					bullet.transform.position = transform.position;
					bullet.Velocity = transform.up * 10.0f;
				}
			}
		}
	}
}
