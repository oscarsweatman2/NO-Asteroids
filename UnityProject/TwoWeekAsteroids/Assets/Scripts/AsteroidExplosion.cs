using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidExplosion : MonoBehaviour {

	public List<Material> asteroidExplosions;
	public float explosionDuration = 0.1f;

	// Use this for initialization
	void Start () {
		if (Random.Range (0,2) == 0)
		{
			renderer.material = asteroidExplosions[0];
		}
		else
		{
			renderer.material = asteroidExplosions[1];
		}

	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, explosionDuration);	
	}
}
