using UnityEngine;
using System.Collections;

public class EyeScript : MonoBehaviour {

	public GameObject ball;
	public GameObject left;
	public GameObject right;
	public GameObject smi;
	Vector3 leftpos ;
	Vector3 rightpos ;
	float xneu;
	float yneu;
	public float radius = 0.35f;
	void Start () 
	{
		leftpos = left.transform.position;
		rightpos = right.transform.position;

		Invoke("AugenCheck", 10f);

	}
	
	void AugenCheck()
	{

		if(this.gameObject.name == "left")
		{

			this.transform.position =  Vector3.ClampMagnitude(ball.transform.position - leftpos , radius);
			this.transform.position += leftpos ;	
			
		}
		
		else if (this.gameObject.name == "right") 
		{

			this.transform.position =  Vector3.ClampMagnitude(ball.transform.position - rightpos , radius);
			this.transform.position += rightpos ;

		}

		Invoke("AugenCheck",0f);
	}
}
