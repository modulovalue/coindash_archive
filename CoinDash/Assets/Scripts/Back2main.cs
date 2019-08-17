using UnityEngine;
using System.Collections;

public class Back2main : MonoBehaviour {
	
	void OnClick()
	{
		CoinSpawnScript.coinsOn = 0;
		SphereScript.points = 0;
		Application.LoadLevel(0);
	}
}
