using UnityEngine;
using System.Collections;

public class ProgressBarScript : MonoBehaviour {

	int i = 0;
	float dif;
	public GameObject foreground;

	// Use this for initialization
	void Start () {

		dif = CoinSpawnScript.nextlvl[i];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		UIProgressBar uipb = this.gameObject.GetComponent<UIProgressBar>();

		uipb.value = 1 - (( CoinSpawnScript.nextlvl[i] - CoinSpawnScript.coinsComplete ) / dif ) ;

		UIWidget clr = foreground.GetComponent<UIWidget>();
		clr.color = Color.Lerp(Color.cyan, Color.magenta, uipb.value);

		if(uipb.value == 1f)
		{	
			i++;
			dif = CoinSpawnScript.nextlvl[i] - CoinSpawnScript.coinsComplete;
		}

	}
}
