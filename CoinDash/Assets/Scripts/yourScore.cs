using UnityEngine;
using System.Collections;

public class yourScore : MonoBehaviour {
	
	void FixedUpdate()
	{
		if (this.name == "EndScore") {
			
				
		UILabel lbl = GetComponent<UILabel>();

		lbl.text =SphereScript.points.ToString();

		}
		else if (this.name == "YourScore" ) 
		{
		
			UILabel lbl = GetComponent<UILabel>();

			lbl.text =": " + SphereScript.points.ToString();

		}
	}
}
