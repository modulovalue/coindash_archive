using UnityEngine;
using System.Collections;

public class MultiplierLogik : MonoBehaviour {
	
	void FixedUpdate () 
	{
		UILabel lbl = gameObject.GetComponent<UILabel>();
		lbl.text = "x"+ CoinScript.multiplier;

			if (CoinScript.bonus >= 10) {
				CoinScript.multiplier = 1.5f;
				if (CoinScript.bonus >= 40) {
					CoinScript.multiplier = 2.0f;
					
			}
		}
	}
}
