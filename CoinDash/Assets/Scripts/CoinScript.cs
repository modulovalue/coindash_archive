using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour{

	public GameObject csound;
	public static bool frei = true;
	public static float bonus = 0f;
	public static float multiplier = 1f;
	public static float punkte = 1f ;
	public Mesh mshc;

	void Start()
	{
//		if (this.GetComponent<MeshFilter>().mesh != mshc) {
//			this.GetComponent<MeshFilter>().mesh = mshc;
//				}
	}
	public void spieleSound()
	{
		csound.gameObject.GetComponent<CoinSoundScript>().playCoin();	
	}

	void OnTriggerEnter2D (Collider2D col)
	{	
		Destoy();
		spieleSound();
		if (frei == true) 
		{
			bonus++;
			
			
		}
		else if(frei == false) {
			bonus = 0;
			multiplier = 1;
			bonus++;
			frei = true;
		}

		punkte = 1 * multiplier;
		
		if (!frei) {
			bonus = 0;
			multiplier = 1;
		}



	}

	public void Destoy()
	{
		this.collider2D.enabled = false;
		SphereScript.points += punkte;
		CoinSpawnScript.coinsComplete++;
		CoinSpawnScript.coinsOn--;
		float tempCM = PlayerPrefs.GetFloat("coinMoney");
		tempCM++;
		PlayerPrefs.SetFloat("coinMoney", tempCM );
//		StartCoroutine(FadeTo(0.0f, 0.35f));
//		StartCoroutine(ToMove(3.0f, 0.5f));
		CoinSpawnScript.PutCoinBack(this.gameObject);

	}

		IEnumerator FadeTo(float aValue, float aTime)
		{	
		Color col = transform.renderer.material.color;
			float alpha = transform.renderer.material.color.a;
			for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
			{
				Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
				transform.renderer.material.color = newColor;

				yield return null;
			}

		transform.renderer.material.color = col;


		}


			IEnumerator ToMove(float aValue, float aTime)
		{
			float now = transform.position.y;
			for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
			{
			float plus = now + Mathf.Lerp(0f,aValue,t);
			transform.position = new Vector3(this.transform.position.x, plus, this.transform.position.z);

			yield return null;
			}

		}

}
