using UnityEngine;
using System.Collections;

public class Aircraft_MAIN : MonoBehaviour {

	public float torque=150;
	public bool playerIn=false;
	private bool grounded;
	public GameObject rotor;
	public lifeObject lifeSystem;
	
	public float maxSpeed=10;
	private float speed=0;
	
	public float maxRotateSpeed=4;
	private float rotateSpeed=0;
	public float rotateDivider=0.1f;
	
	public float maxVRotateSpeed = 1;
	private float vRotateSpeed = 0;
	private float speedZ;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
			
		//INPUT
		if(playerIn)
		{
			if(speed<maxSpeed)
				speed+=maxSpeed/10f*Time.deltaTime;
			else
				speed=maxSpeed;
				
			if(Input.GetKey(KeyCode.D)&&!grounded)
			{
				if(rotateSpeed>-maxRotateSpeed)
					rotateSpeed-=maxRotateSpeed*Time.deltaTime*1.1f/rotateDivider;
				else
					rotateSpeed=-maxRotateSpeed;
				
			}
			else if(Input.GetKey(KeyCode.A)&&!grounded)
			{
				if(rotateSpeed<maxRotateSpeed)
					rotateSpeed+=maxRotateSpeed*Time.deltaTime*1.1f/rotateDivider;
				else
					rotateSpeed=maxRotateSpeed;
			}
			
			speedZ = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity).z;
			if(Input.GetKey(KeyCode.W)&&!grounded)
			{
					if(vRotateSpeed<maxVRotateSpeed)
						vRotateSpeed+=maxVRotateSpeed*Time.deltaTime*1.1f/rotateDivider;
					else
						vRotateSpeed=maxVRotateSpeed;
			}
			else if(Input.GetKey(KeyCode.S) && ((speedZ>40 && grounded)||!grounded))
			{
				if(vRotateSpeed>-maxVRotateSpeed)
					vRotateSpeed-=maxVRotateSpeed*Time.deltaTime*1.1f/rotateDivider;
				else
					vRotateSpeed=-maxVRotateSpeed;
			}
			
			//SPEED NORMALIZER ADD FORCE
			if(speed<0)
				speed=0;
				
			//ADDFORCE
			GetComponent<Rigidbody>().AddForce(transform.TransformDirection(0,0,(float)torque*Time.deltaTime*30*(float)speed));
			
			//ROTATE RESET
			if(rotateSpeed>0)
				rotateSpeed-=maxRotateSpeed*Time.deltaTime/rotateDivider;
			else if(rotateSpeed<0)
				rotateSpeed+=maxRotateSpeed*Time.deltaTime/rotateDivider;
			else
				rotateSpeed=0;
			//VROTATE
			if(vRotateSpeed>0)
				vRotateSpeed-=maxVRotateSpeed*Time.deltaTime/rotateDivider;
			else if(vRotateSpeed<0)
				vRotateSpeed+=maxVRotateSpeed*Time.deltaTime/rotateDivider;
			else
				vRotateSpeed=0;
			
			//ROTATE ROTOR
			if(rotor!=null)
				rotor.transform.Rotate (new Vector3(0,0,-(speedZ*Time.deltaTime*40)));
		}
		
		if(!playerIn)
		{
			GetComponent<Rigidbody>().drag=0;
			if(speed>0)
				speed-=maxSpeed*Time.deltaTime/10;
			else
				speed=0;
			rotateSpeed=0;
			vRotateSpeed=0;
		}
		else if(playerIn)
		{
			GetComponent<Rigidbody>().drag=20;
		}
			
		
		//ROTATE PLANE
		transform.Rotate(new Vector3((vRotateSpeed*25*Time.deltaTime)*(speedZ/50f),0,rotateSpeed*25*Time.deltaTime)*(speedZ/50f));
		
	}
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name=="Terrain")
			grounded=true;
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
	
	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.name=="Terrain")
			grounded=false;
	}
}
