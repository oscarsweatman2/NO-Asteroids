using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public Vector3 Velocity = Vector3.zero;
	public GameObject particleTrail;

	public float pulseRate = 2.0f;
	public float pulseRange = 15.0f;
	public float pulseMinSize = 1.0f;

	private float sinCounter = 0.0f;

	// Use this for initialization
	void Start () 
	{

		GameObject m_trail = Instantiate(particleTrail, transform.position, Quaternion.identity) as GameObject;
		m_trail.transform.parent = transform;
	}

	void OnTriggerEnter(Collider c)
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

		float sinValue = (Mathf.Sin(sinCounter / pulseRate)/pulseRange) + pulseMinSize;
		transform.localScale = new Vector3(sinValue, sinValue, 1);
		sinCounter++;

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
