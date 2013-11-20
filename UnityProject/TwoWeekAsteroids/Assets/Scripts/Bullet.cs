using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public Vector3 Velocity = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
	
	}

	void OnCollisionEnter(Collision c)
	{
		Asteroid a = c.gameObject.GetComponent<Asteroid>();
		if (a != null)
		{
			// We hit an asteroid
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
