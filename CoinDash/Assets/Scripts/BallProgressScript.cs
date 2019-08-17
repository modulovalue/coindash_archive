using UnityEngine;
using System.Collections;

public class BallProgressScript : MonoBehaviour {

	public GameObject clr;
	float dif;
	
	void FixedUpdate () {
		
		UIProgressBar uiballprog = this.gameObject.GetComponent<UIProgressBar>();
		uiballprog.value = 1-  (( NewBallScript.moneyArray[NewBallScript.zaehl] - SphereScript.points ) / dif) ;
		UIWidget clrslider = clr.GetComponent<UIWidget>();	
		clrslider.color = Color.Lerp(clrslider.color, Color.green, uiballprog.value);

		if(uiballprog.value == 0f)
		{	

			dif =  NewBallScript.moneyArray[NewBallScript.zaehl] - SphereScript.points;
		}
	}
}
