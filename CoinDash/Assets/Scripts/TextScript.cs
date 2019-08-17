using UnityEngine;
using System.Collections;

public class TextScript : MonoBehaviour {
	Vector3 camOrigPos;
	float speed = 2f;
	public static float globaltimescale = 1.0f;
	public static float globalOrthoSize = 6.0f;
	float scale = 0.5f;
	float height;
	void Start()
	{

		Camera.main.orthographicSize = 0.1f;
		camOrigPos = Camera.main.transform.position;

	}

	void FixedUpdate () {

		height = 0.1f;

		UILabel lbl = GetComponent<UILabel>();
		if (CoinSpawnScript.coinsOn < 80) {
//			Camera.main.GetComponent<AudioSource>().pitch = 1.0f;
			if (Camera.main.orthographicSize != globalOrthoSize) 
			{
				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize,globalOrthoSize,Time.deltaTime * 1.1f);
			}

			Camera.main.transform.position = camOrigPos;

			Time.timeScale = globaltimescale;
			lbl.text =CoinSpawnScript.coinsOn.ToString();
			lbl.color = Color.white;
				}

		else if (CoinSpawnScript.coinsOn < 110) {
//			Camera.main.GetComponent<AudioSource>().pitch = 1.0f;

				Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize,globalOrthoSize,Time.deltaTime * speed);



			Camera.main.transform.position = camOrigPos;
			Time.timeScale = globaltimescale;
			lbl.color = Color.yellow;
			lbl.text = CoinSpawnScript.coinsOn.ToString();
				}

		else if (CoinSpawnScript.coinsOn <= 128) {

//			Camera.main.GetComponent<AudioSource>().pitch = 0.86f;
//			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize,4.6f,Time.deltaTime * speed * 2);
			Camera.main.transform.position = new Vector3( 
			(height * Mathf.PerlinNoise(Time.time+(Camera.main.transform.position.x * scale),20 * Time.deltaTime + (transform.position.x * scale) ) )-height,
			(height * Mathf.PerlinNoise(Time.time+(Camera.main.transform.position.y * scale),20 * Time.deltaTime + (transform.position.y * scale) ) )-height,
			camOrigPos.z);
			lbl.color = Color.red;
			lbl.text =(128 - CoinSpawnScript.coinsOn).ToString()+ " TIL' GAMEOVER";
			globaltimescale = 1f;
			Time.timeScale = globaltimescale;
		}
	}	
}
