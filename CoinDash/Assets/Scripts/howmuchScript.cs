using UnityEngine;
using System.Collections;

public class howmuchScript : MonoBehaviour {

	void FixedUpdate()
	{
		UILabel lbl = GetComponent<UILabel>();
		lbl.text = NewBallScript.nochballz.ToString()+"x";
	}
}
