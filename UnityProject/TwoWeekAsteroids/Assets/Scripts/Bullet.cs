using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public Vector3 Velocity = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
	
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
}
