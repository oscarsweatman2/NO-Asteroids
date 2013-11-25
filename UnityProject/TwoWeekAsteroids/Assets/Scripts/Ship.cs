using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour 
{
	public GameObject BulletType = null;
	public Cursor Cursor = null;

	public float Speed = 5.0f;
	public float FireTime = 0.5f;

	public float BulletSpeed = 10.0f;

	public bool alternateControl = false;

	float m_fireTimer = 0.0f;

	// Variables regarding death and respawn
	private Vector3 origin;
	private float respawnCounter = 0.0f;
	public float respawnInvincibilityTime = 5.0f;
	public GameObject shield;
	public GameObject explosion;
	public GameObject lifeHUDref;

	// Use this for initialization
	void Start () 
	{
		m_fireTimer = FireTime;
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (alternateControl)
		{
			transform.Translate(transform.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime, Space.World);
			transform.Translate(transform.up * Input.GetAxis("Vertical") * Speed * Time.deltaTime, Space.World);
		}
		else
		{
			transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * Speed * Time.deltaTime, Space.World);
		}
		
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
		transform.up = fwd;

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
					bullet.Velocity = transform.up * BulletSpeed;
				}
			}
		}

		if (respawnCounter > 0.0f && collider.enabled == false)
		{
			respawnCounter -= Time.deltaTime;
		}
		else if (respawnCounter <= 0.0f && collider.enabled == false)
		{
			collider.enabled = true;
		}
	}

	void OnTriggerEnter(Collider c)
	{
		DieAndRespawn();
	}

	void DieAndRespawn()
	{
		GameObject shipExplode = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
		Destroy (shipExplode, 2.0f);

		HUD lifeHUD = lifeHUDref.GetComponent<HUD>();
		if (lifeHUD.currentMatLives > 0)
		{
			lifeHUD.AdjustNumLives(-1);
			transform.position = origin;
			respawnCounter = respawnInvincibilityTime;
			collider.enabled = false;
			GameObject newShield = Instantiate(shield, origin, Quaternion.identity) as GameObject;
			newShield.transform.parent = transform;
			Destroy (newShield, respawnInvincibilityTime);
		}
		else
		{
			Destroy (gameObject);
		}

	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.1f);
		Gizmos.DrawCube(this.collider.transform.position, (this.collider as BoxCollider).size);
	}
}
