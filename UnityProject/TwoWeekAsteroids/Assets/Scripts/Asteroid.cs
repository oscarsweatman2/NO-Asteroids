using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour 
{
	public Vector3 Velocity = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
	
	}

	void OnCollisionEnter(Collision c)
	{
		Bullet b = c.gameObject.GetComponent<Bullet>();
		if (b != null)
		{
			Debug.Log ("Asteroid Hit!");
			// We hit a bullet
			for (int i = 0; i < 4; i++)
			{
				Asteroid a = (Instantiate(this.gameObject) as GameObject).GetComponent<Asteroid>();
				a.transform.position = transform.position;
				a.Velocity = Random.onUnitSphere;
				a.Velocity.z = 0.0f;
				a.Velocity = a.Velocity.normalized * (Velocity.magnitude * 0.5f);
				a.transform.localScale = transform.localScale * 0.5f;
			}
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Velocity * Time.deltaTime);
		
		if (transform.position.x < World.Left ||
		    transform.position.x > World.Right ||
		    transform.position.y < World.Bottom ||
		    transform.position.y > World.Top)
			Destroy(this.gameObject);
	}

	void OnDrawGizmos()
	{
		Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.1f);
		Gizmos.DrawCube(this.collider.transform.position, (this.collider as BoxCollider).size);
	}
}
