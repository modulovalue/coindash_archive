using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {

	public static float points;
	public GameObject expl;
	public float zeit = 0f;
	public AudioClip colsound;

	void Awake()
	{
		this.gameObject.SetActive(true);
	}

	void Start()
	{
		this.gameObject.GetComponent<CircleCollider2D>().enabled = true;
		zeit = Time.time;
	}

	void OnCollisionEnter2D( Collision2D col)
	{

		if(col.gameObject.CompareTag("Player") ) {

			if (this.zeit < col.gameObject.GetComponent<SphereScript>().zeit)
			{

			AudioSource.PlayClipAtPoint(colsound, Vector3.zero, 0.65f);
				
//				ContactPoint2D contact = col.contacts[0];
//				Instantiate(expl,contact.point, Quaternion.identity);
			}
		}

	}


}
