using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour 
{
	public Vector3 Velocity = Vector3.zero;
	public int numAsteroidChunks = 4;			// Number of pieces an asteroid breaks into in a single hit
	public int numAsteroidDivisions = 2;		// Number of times an asteroid divides before it just disappears

	public GameObject asteroidExplosion;
	private GameObject scoreHUDref;
	private HUD scoreHUD;

	private int numTimesSplit = 0;

	// Use this for initialization
	void Start () 
	{
		scoreHUDref = GameObject.Find("HUD outline SCORE");
		scoreHUD = scoreHUDref.GetComponent<HUD>();
	}

	void OnTriggerEnter(Collider c)
	{
		Bullet b = c.gameObject.GetComponent<Bullet>();
		if (b != null)
		{
			Debug.Log ("Asteroid Hit!");
			// We hit a bullet
			if (numTimesSplit < numAsteroidDivisions)
			{
				for (int i = 0; i < numAsteroidChunks; i++)
				{
					Asteroid a = (Instantiate(this.gameObject) as GameObject).GetComponent<Asteroid>();
					a.transform.position = transform.position;
					a.Velocity = Random.onUnitSphere;
					a.Velocity.z = 0.0f;
					a.Velocity = a.Velocity.normalized * (Velocity.magnitude * 1.5f);	// Asteroids move more quickly after dividing
					a.transform.localScale = transform.localScale * 0.5f;
					a.numTimesSplit = numTimesSplit + 1;
				}
			}
			GameObject explosion = Instantiate(asteroidExplosion, new Vector3(transform.position.x, transform.position.y, -1.0f), Quaternion.Euler(0, 0, Random.Range(0, 360))) as GameObject;
			explosion.transform.localScale = new Vector3(transform.localScale.x * 1.5f, transform.localScale.y * 1.5f, explosion.transform.localScale.z);
			GameObject.Find("HUD outline SCORE").SendMessage("AdjustScore", 1);
			Destroy (this.gameObject);

		}
	}

	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Velocity * Time.deltaTime);

		// Asteroids wrap around edge of screen
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

	void OnDrawGizmos()
	{
		Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.1f);
		Gizmos.DrawCube(this.collider.transform.position, new Vector3((this.collider as SphereCollider).radius * 2, (this.collider as SphereCollider).radius * 2,(this.collider as SphereCollider).radius * 2));
	}
}
