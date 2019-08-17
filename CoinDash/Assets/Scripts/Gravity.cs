using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public static float g = 10;
	public static Vector2 unten = new Vector2(0f,-g);
	public static Vector2 rechts = new Vector2(g, 0f);
	public static Vector2 oben = new Vector2(0f,g);
	public static Vector2 links = new Vector2(-g, 0f);
	public Color colorNew;
	public Color colorEnd;




	
	public float minMovement = 20.0f;
	public bool sendUpMessage = true;
	public bool sendDownMessage = true;
	public bool sendLeftMessage = true;
	public bool sendRightMessage = true;
	public GameObject MessageTarget = null;
	bool overmittelt1 = false;
	bool overmittelt2 = false;
	bool overmittelt3 = false;
	private Vector2 StartPos;
	private int SwipeID = -1;


	void Awake()
	{

		overmittelt1 = false;
		overmittelt2 = false;
		overmittelt3 = false;

		transform.position = new Vector3(0f, 0f, -10f);
		colorNew = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f) ) ;
		colorEnd = Camera.main.backgroundColor;
		PhysicOben();
		StartCoroutine("Farbe");



		if (MessageTarget == null)
			MessageTarget = gameObject;
	}

	IEnumerator Farbe()
	{
		
		colorEnd = Camera.main.backgroundColor;
		colorNew = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f) ) ;
		yield return new WaitForSeconds(0.5f);
		StartCoroutine("Farbe");
	}

	public static void PhysicUnten()
	{

		Physics2D.gravity = unten;
	}

	public static void PhysicRechts()
	{

		Physics2D.gravity = rechts;
	}

	public static void PhysicOben()
	{

		Physics2D.gravity = oben;
	}

	public static void PhysicLinks()
	{

		Physics2D.gravity = links;
	}



	void FixedUpdate ()
	{
		 
		if (PlayerPrefs.GetFloat("highscore") >= 5000 && PlayerPrefs.GetFloat("highscore") < 10000  && !overmittelt1)
		{
			AchievementScript.Achieve5k();
			overmittelt1 = true;
		}
		else if (PlayerPrefs.GetFloat("highscore") >= 10000 && PlayerPrefs.GetFloat("highscore") < 20000  && !overmittelt2)
		{
			AchievementScript.Achieve10k();
			overmittelt2 = true;
		}
		else if (PlayerPrefs.GetFloat("highscore") >= 20000 && !overmittelt3 )
		{
			AchievementScript.Achieve20k();
			overmittelt3 = true;
		}


		Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, colorNew, Time.deltaTime * 0.1f);






		foreach (var T in Input.touches)
		{
			var P = T.position;
			if ((T.phase == TouchPhase.Moved) && SwipeID == -1)
			{
				SwipeID = T.fingerId;
				StartPos = P;
			}
			else if (T.fingerId == SwipeID)
			{
				var delta = P - StartPos;
				if (T.phase == TouchPhase.Moved && delta.magnitude > minMovement)
				{
					SwipeID = -1;
					if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
					{
						if (sendRightMessage && delta.x > 0)
							MessageTarget.SendMessage("OnSwipeRight", SendMessageOptions.DontRequireReceiver);
						else if (sendLeftMessage && delta.x < 0)
							MessageTarget.SendMessage("OnSwipeLeft", SendMessageOptions.DontRequireReceiver);
					}
					else
					{
						if (sendUpMessage && delta.y > 0)
							MessageTarget.SendMessage("OnSwipeUp", SendMessageOptions.DontRequireReceiver);
						else if (sendDownMessage && delta.y < 0)
							MessageTarget.SendMessage("OnSwipeDown", SendMessageOptions.DontRequireReceiver);
					}
				}
				else if (T.phase == TouchPhase.Canceled || T.phase == TouchPhase.Ended)
				{
					SwipeID = -1;
					MessageTarget.SendMessage("OnTap", SendMessageOptions.DontRequireReceiver);
				}
			}
		}

	} 

	void OnSwipeRight()
	{
		PhysicRechts();
	}

	void OnSwipeLeft()
	{
		PhysicLinks();
	}

	void OnSwipeUp()
	{
		PhysicOben();
	}

	void OnSwipeDown()
	{
		PhysicUnten();
	}
}
