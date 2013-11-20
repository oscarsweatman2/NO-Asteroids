using UnityEngine;
using System.Collections;

public class World : MonoBehaviour 
{
	public static World Inst = null;

	public float m_width = 10.0f;
	public float m_height = 10.0f;
	public GameObject m_Asteroid = null;
	public float m_asteroidRate = 1.0f;
	public float m_asteroidSpeed = 2.0f;

	public static GameObject Asteroid { get { return Inst.m_Asteroid; } }

	public static float Width { get { return Inst.m_width; } }
	public static float Height { get { return Inst.m_height; } }

	public static float Left { get { return Width * -0.5f; } }
	public static float Right { get { return Width * 0.5f; } }
	public static float Top { get { return Height * 0.5f; } }
	public static float Bottom { get { return Height * -0.5f; } }

	// Use this for initialization
	void Start () 
	{
		Inst = this;
		m_asteroidTimer = m_asteroidRate;
	}

	// Update is called once per frame
	float m_asteroidTimer = 0.0f;
	void Update () 
	{
		float ortho = Camera.main.orthographicSize;
		m_height = ortho * 2.0f;
		m_width = m_height * Camera.main.aspect;

		m_asteroidTimer -= Time.deltaTime;
		if (m_asteroidTimer <= 0.0f)
		{
			if (Asteroid != null)
			{
				m_asteroidTimer = m_asteroidRate;

				Asteroid asteroid = (Instantiate(Asteroid) as GameObject).GetComponent<Asteroid>();
				if (Random.value > 0.5f)
				{
					// Top/Bottom
					asteroid.transform.position = new Vector3(
						Left + Random.value * Width,
						Bottom + Mathf.Round(Random.value) * Height,
						0.0f);
				}
				else
				{
					// Sides
					asteroid.transform.position = new Vector3(
						Left + Mathf.Round(Random.value) * Width,
						Bottom + Random.value * Height,
						0.0f);
				}
				asteroid.Velocity = -asteroid.transform.position.normalized * m_asteroidSpeed;
			}
		}
	}
	
	void OnDrawGizmos()
	{
		float l = m_width * -0.5f;
		float r = m_width * 0.5f;
		float t = m_height * 0.5f;
		float b = m_height * -0.5f;

		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(new Vector3(l, t, 0.0f), new Vector3(r, t, 0.0f));
		Gizmos.DrawLine(new Vector3(r, t, 0.0f), new Vector3(r, b, 0.0f));
		Gizmos.DrawLine(new Vector3(r, b, 0.0f), new Vector3(l, b, 0.0f));
		Gizmos.DrawLine(new Vector3(l, b, 0.0f), new Vector3(l, t, 0.0f));
	}
}
