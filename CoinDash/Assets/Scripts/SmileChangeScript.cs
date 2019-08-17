using UnityEngine;
using System.Collections;

public class SmileChangeScript : MonoBehaviour {

	public GameObject happyFace;
	public GameObject sadFace;

	IEnumerator OnCollisionEnter2D (Collision2D col)
	{
		CoinScript.frei = false;
		if(happyFace.activeSelf)
		{
			happyFace.SetActive(false);
			sadFace.SetActive(true);
			yield return new WaitForSeconds(0.5f);
			happyFace.SetActive(true);
			sadFace.SetActive(false);
		}
		else
			yield return null ;

	}
}
