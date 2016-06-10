using UnityEngine;
using System.Collections;

public class Helicopter_Main : MonoBehaviour {
	
	public lifeObject lifeSystem;
	public double rotorTorque = 300;
	private GameObject model;
	private Helicopter_MainRotor mainRotorScript;
	private Helicopter_SteerRotor steerRotorScript;
	public bool playerIn = false;
	public Light laser;
	
	public GameObject missile;
	public bool missileEnabled = true;
	private bool canMissile = true;
	public float missileFPS = 1;
	private bool lastMissileWasLeft=false;
	
	public GameObject bullet;
	public bool bulletEnabled=true;
	private bool canBullet=true;
	public float bulletFPS = 5;
	
	public float rotateDivider = 2;
	public float maxRotateSpeed = 1;
	private float rotateSpeed = 0;
	
	public float maxVRotateSpeed = 1;
	private float vRotateSpeed = 0;
	
	// Use this for initialization
	void Start () {
		model = transform.FindChild("model").gameObject;
		mainRotorScript = model.transform.FindChild("mainRotor").gameObject.GetComponent<Helicopter_MainRotor>();
		steerRotorScript = model.transform.FindChild("steerRotor").gameObject.GetComponent<Helicopter_SteerRotor>();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(rotateSpeed>0)
			rotateSpeed-=maxRotateSpeed*Time.deltaTime/rotateDivider;
		else if(rotateSpeed<0)
			rotateSpeed+=maxRotateSpeed*Time.deltaTime/rotateDivider;
		else
			rotateSpeed=0;
		
		if(vRotateSpeed>0)
			vRotateSpeed-=maxVRotateSpeed*Time.deltaTime/rotateDivider;
		else if(vRotateSpeed<0)
			vRotateSpeed+=maxVRotateSpeed*Time.deltaTime/rotateDivider;
		else
			vRotateSpeed=0;
		
		if(playerIn)
		{
			if(!mainRotorScript.powered)
				mainRotorScript.powered=true;
			/*if(!laser.enabled)
				laser.enabled=true;*/
				
			/*if(Input.GetKey(KeyCode.Q))
			{
				transform.Rotate(new Vector3(0,25*Time.deltaTime,0));
			}
			else if(Input.GetKey(KeyCode.E))
			{
				transform.Rotate(new Vector3(0,-25*Time.deltaTime,0));
			}*/
			
			if(Input.GetKey(KeyCode.D))
			{
				//transform.Rotate(new Vector3(0,0,-25*Time.deltaTime));
				if(rotateSpeed>-maxRotateSpeed)
					rotateSpeed-=maxRotateSpeed*Time.deltaTime*1.1f/rotateDivider;
				else
					rotateSpeed=-maxRotateSpeed;

			}
			else if(Input.GetKey(KeyCode.A))
			{
				//transform.Rotate(new Vector3(0,0,25*Time.deltaTime));
				if(rotateSpeed<maxRotateSpeed)
					rotateSpeed+=maxRotateSpeed*Time.deltaTime*1.1f/rotateDivider;
				else
					rotateSpeed=maxRotateSpeed;
			}
			
			if(Input.GetKey(KeyCode.W))
			{
				//transform.Rotate(new Vector3(+25*Time.deltaTime,0,0));
				if(vRotateSpeed<maxVRotateSpeed)
					vRotateSpeed+=maxVRotateSpeed*Time.deltaTime*1.1f/rotateDivider;
				else
					vRotateSpeed=maxVRotateSpeed;
			}
			else if(Input.GetKey(KeyCode.S))
			{
				//transform.Rotate(new Vector3(-25*Time.deltaTime,0,0));
				if(vRotateSpeed>-maxVRotateSpeed)
					vRotateSpeed-=maxVRotateSpeed*Time.deltaTime*1.1f/rotateDivider;
				else
					vRotateSpeed=-maxVRotateSpeed;
			}
			
			if(missileEnabled && Input.GetButton("Fire2"))
			{
				StartCoroutine(shootMissile());
			}
			
			if(bulletEnabled && Input.GetButton("Fire1"))
			{
				StartCoroutine(shootBullet());
			}

		}
		else
		{
			if(mainRotorScript.powered)
				mainRotorScript.powered=false;
			/*if(laser.enabled)
				laser.enabled=false;*/
		}
		

		GetComponent<Rigidbody>().AddForce(transform.TransformDirection(0,(float)rotorTorque*Time.deltaTime*30*(float)mainRotorScript.rotateSpeed,0));
		//transform.Rotate(new Vector3(0,0,rotateSpeed*25*Time.deltaTime));
		//transform.Rotate(new Vector3(0,(float)-steerRotorScript.speed*Time.deltaTime,0));
		transform.Rotate(new Vector3(vRotateSpeed*25*Time.deltaTime,(float)-steerRotorScript.speed*Time.deltaTime,rotateSpeed*25*Time.deltaTime));
	}
	
	IEnumerator shootMissile()
	{
		if(canMissile)
		{
			canMissile=false;
			if(!lastMissileWasLeft)
			{
				GameObject loko = Instantiate(missile, transform.position+transform.forward*13+transform.right*-5+transform.up*-2,transform.rotation) as GameObject;
				loko.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
				
				lastMissileWasLeft=true;
			}
			else
			{
				GameObject loko = Instantiate(missile, transform.position+transform.forward*13+transform.right*5+transform.up*-2,transform.rotation) as GameObject;
				loko.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
				lastMissileWasLeft=false;
			}
			float wait = 1f/(float)missileFPS;
			yield return new WaitForSeconds(wait);
			//yield return new WaitForSeconds(Time.deltaTime*(60/missileFPS));
			canMissile=true;
		}
	}
	
	IEnumerator shootBullet()
	{
		if(canBullet)
		{
			canBullet=false;
			GameObject loko = Instantiate(bullet, transform.position+transform.forward*19+transform.up*-1,transform.rotation) as GameObject;
			loko.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
			float wait = 1f/(float)bulletFPS;
			yield return new WaitForSeconds(wait);
			//yield return new WaitForSeconds(Time.deltaTime*(60/bulletFPS));
			canBullet=true;
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(lifeSystem!=null)
		{
			if(col.gameObject.name=="shoot(Clone)" && col.relativeVelocity.magnitude > 10)
			{
				lifeSystem.hp-=10;
			}
			else if(col.gameObject.name=="Missile(Clone)" && col.relativeVelocity.magnitude > 10)
			{
				lifeSystem.hp=0;
			}
		}
	}
}
