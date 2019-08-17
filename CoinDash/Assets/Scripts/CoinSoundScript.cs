using UnityEngine;
using System.Collections;

public class CoinSoundScript : MonoBehaviour {
	public AudioClip coinsound;
	
	public void playCoin()
	{

		AudioSource.PlayClipAtPoint(coinsound, Vector3.zero, 0.5f);

	}
	

	public static void CoinPitch(float ptch)
	{

	}

	public static void CoinPitchReset(float ptch)
	{

	}

}
