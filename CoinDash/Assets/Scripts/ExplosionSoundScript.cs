using UnityEngine;
using System.Collections;

public class ExplosionSoundScript : MonoBehaviour {

	void OnEnable()
	{
		Destroy(this.gameObject, this.audio.clip.length);
	}
}
