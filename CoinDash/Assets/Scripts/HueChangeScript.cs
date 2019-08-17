using UnityEngine;
using System.Collections;

public class HueChangeScript : MonoBehaviour {

	void Start()
	{
		var bgclr = this.gameObject.GetComponent<SpriteRenderer>();
		bgclr.color = Color.black;
	}
	void Update () {
		var bgclr = this.gameObject.GetComponent<SpriteRenderer>();

		bgclr.color = Color.Lerp(bgclr.color, Color.white, 0.05f * Time.deltaTime);

	}
}
