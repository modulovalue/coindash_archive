using UnityEngine;
using System.Collections;


public class NewBallScript : MonoBehaviour {

	public GameObject ball;
	public GameObject newball;
	public static int nochballz = 7;
	public static float money;
	public static int zaehl = 0;
	public bool aufDemPlatz = true;

	void Start()
	{
		this.GetComponent<BoxCollider>().enabled = true;
		nochballz = 6;
		zaehl = 0;
	}
	public static int[] moneyArray = new int[] 
	{
		1000,
		3500,
		7500,
		15000,
		30000,
		51000,
		55000,
	};

	void FixedUpdate()
	{
		if (nochballz == 0) {
			this.gameObject.SetActive(false);
			this.collider2D.enabled = false;
			
		}

		if(SphereScript.points >= money) 
		{
			this.gameObject.SetActive(true);
			UIWidget btn = this.GetComponent<UIWidget>();
			btn.color = Color.white;
			her();
		}
		else
		{
			this.gameObject.SetActive(true);
			UIWidget btn = this.GetComponent<UIWidget>();
			btn.color = Color.red;

		}
		money = moneyArray[zaehl];


	}

	void OnClick()
	{


		if (SphereScript.points >= money ) {


				nochballz--;
				zaehl++;
				GameObject ballz = (GameObject)Instantiate(ball,Vector3.zero, Quaternion.identity);
				audio.Play();

				ballz.name = zaehl.ToString();

				Instantiate(newball,Vector3.zero, Quaternion.identity);

		}
		else
		{	
			weg();
		}
	}

	public void weg()
		{


			UIWidget btn = this.GetComponent<UIWidget>();
			
			if(btn.color == Color.red)
			{
			AchievementScript.AchieveBallzAway();
				this.gameObject.GetComponent<TweenPosition>().PlayReverse();
			}

		aufDemPlatz = false; 
		}
	public void her()
	{
			UIWidget btn = this.GetComponent<UIWidget>();
			
			if(btn.color == Color.white && !aufDemPlatz)
			{
				this.gameObject.GetComponent<TweenPosition>().PlayForward();
			}
		aufDemPlatz = true; 

	}
}
