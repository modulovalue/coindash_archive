using UnityEngine;
using System.Collections;

public class XxlPowerup : MonoBehaviour {

//	public static XxlPowerup puManager;
	public GameObject puscript;
	public UISprite xxlpu;
	public static float xxlTime;	//hier	
	public GameObject XxlFx;
	public static float xxlBallSize; 		//hier
	public static float xxlDuration;  			//hier
	public AudioClip xxlsound;

	public UISprite dshpu;
	public static float dshTime; 		//hier
	public GameObject dshExpl;
	public static float dshSpeed; 	//hier
	public AudioClip speedup;
	
	public UISprite clrpu;
	public static float clrTime; 		//hier
	public GameObject clrExpl;
	public AudioClip clearsound;

	public GameObject oSph;
	float ia = 0;
	float ib = 0;
	float ic = 0;

	void Awake()
	{




		PowerUpScript puscri = puscript.GetComponent<PowerUpScript>();

		for (int i = 0; i < puscri.lblar.Length; i++) 
		{
			int btnnr = i;
			
			puscri.WhichVarUp(i, puscri.buttons[btnnr].name);
		}
//		if (puManager == null) 
//		{
//			DontDestroyOnLoad(gameObject);
//			puManager = this;
//		}
//		else if (puManager != null) 
//		{
//			Destroy(gameObject);
//		}


	}
	void Start()
	{

		xxlTime = PlayerPrefs.GetFloat("xxlTime");	
		xxlBallSize = PlayerPrefs.GetFloat("xxlSize");
		xxlDuration = PlayerPrefs.GetFloat("xxlDuration");  
		dshTime = PlayerPrefs.GetFloat("dshTime"); 	
		dshSpeed = PlayerPrefs.GetFloat("dshSpeed");
		clrTime = PlayerPrefs.GetFloat("clrTime"); 	

		StartCoroutine("Counterxxl");
		StartCoroutine("Counterclr");
		StartCoroutine("Counterdsh");
	}

	public void powerupxxl()
	{
		ia = 0;
		StartCoroutine("XxlPower");
		StartCoroutine("Counterxxl");

	}

	public void powerupclr()
	{
		ib = 0;
		StartCoroutine("ClrPower");
		StartCoroutine("Counterclr");
	
	}

	public void powerupdsh()
	{
		ic = 0;
		StartCoroutine("DshPower");
		StartCoroutine("Counterdsh");

	}


	public void coolDown(UISprite pu, float duration, float time)
	{
		pu.fillAmount = 1 - (( duration - time ) / duration);
		if (pu.fillAmount == 1) 
		{
			pu.alpha = 1f;
			pu.GetComponent<BoxCollider>().enabled = true;
		}
		else if (pu.fillAmount != 1) 
		{
			pu.alpha = 0.5f;
			pu.GetComponent<BoxCollider>().enabled = false;
		}
	}

	void FixedUpdate()
	{

		coolDown(xxlpu, xxlTime, ia);
		coolDown(clrpu, clrTime, ib);
		coolDown(dshpu, dshTime, ic);

	}

	public IEnumerator Counterclr()
	{
		ib++;
		if (ib < clrTime) 
		{
			yield return new WaitForSeconds(1.0f);
			StartCoroutine("Counterclr");
		}
	}

	public IEnumerator Counterxxl()
	{
		ia++;
		if (ia < xxlTime) 
		{
			yield return new WaitForSeconds(1.0f);
			StartCoroutine("Counterxxl");
		}
	}

	public IEnumerator Counterdsh()
	{
		ic++;
		if (ic < dshTime) 
		{
			yield return new WaitForSeconds(1.0f);
			StartCoroutine("Counterdsh");	
		}
	}

	public IEnumerator XxlPower()
	{
		AudioSource.PlayClipAtPoint(xxlsound, Vector3.zero, 0.7f);
		Vector3 altScale = oSph.transform.localScale;
		StartCoroutine(ChangeScale(oSph.transform.localScale, new Vector3(xxlBallSize,xxlBallSize,xxlBallSize)) );
		GameObject xxlpar = (GameObject) Instantiate(XxlFx);
		yield return new WaitForSeconds(xxlDuration);
		StartCoroutine(ChangeScale(oSph.transform.localScale, altScale) );
		Destroy(xxlpar);
	}


	private IEnumerator ChangeScale(Vector3 source, Vector3 target)
	{
		float overTime = 0.1f;
		float startTime = Time.time;
		while(Time.time < startTime + overTime)
		{
			oSph.transform.localScale = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
			yield return null;
		}
		oSph.transform.localScale = target;
	}

	
	public IEnumerator ClrPower()
	{	
		AudioSource.PlayClipAtPoint(clearsound, Vector3.zero, 0.7f);
		GameObject[] coins = GameObject.FindGameObjectsWithTag("coin");
		CoinSpawnScript.wait = true;

		coins[0].GetComponent<CoinScript>().csound.gameObject.GetComponent<CoinSoundScript>().playCoin();
		double temp = CoinSpawnScript.spawnRate;
		CoinSpawnScript.spawnRate = 100f;

		Object cExpl = Instantiate(clrExpl, Vector3.zero, Quaternion.identity);

		foreach (var c in coins) 
		{
			if(c.collider2D.enabled == true)
			{
			c.GetComponent<CoinScript>().Destoy();
			}
		}
		CoinSpawnScript.spawnRate = temp;
		CoinSpawnScript.wait = false;
		DestroyObject(cExpl, 2f);
		yield return null;	
	}

	public IEnumerator DshPower()
	{	
		Object dExpl = Instantiate(dshExpl, oSph.transform.position, Quaternion.identity);
		GameObject[] balls = GameObject.FindGameObjectsWithTag("Player");
		AudioSource.PlayClipAtPoint(speedup, Vector3.zero, 0.3f);
		foreach (var b in balls) 
		{

			b.rigidbody2D.velocity *= dshSpeed;

		}
		DestroyObject(dExpl, 2f);
		yield return null;
		
	}

}