using UnityEngine;
using System.Collections;

public class CarSystem : MonoBehaviour {

	public float maxspeed = 10;
	public bool playerIn=false;
	private bool grounded;
	private float distToGround;
	public lifeObject lifeSystem;
	public bool ignoreAll = false;

	// Use this for initialization
	void Start () {
		distToGround = GetComponent<Collider>().bounds.extents.y;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!ignoreAll)
		{
			grounded = Physics.Raycast(transform.position, -Vector3.up*3, distToGround + 0.1f);
			
			if(playerIn)
			{
				Vector3 vel;
				if(GetComponent<Rigidbody>()!=null)
					vel = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
				else
					vel = new Vector3(0,0,0);
				if(Input.GetKey (KeyCode.W))
				{
					Vector3 test = transform.TransformDirection (new Vector3 (0, 0, maxspeed*50000* Time.deltaTime));
					if(GetComponent<Rigidbody>()!=null)
						GetComponent<Rigidbody>().AddForce(test);
				}
				else if(Input.GetKey (KeyCode.S))
				{
					Vector3 test = transform.TransformDirection (new Vector3 (0, 0, -maxspeed*40000* Time.deltaTime));
					if(GetComponent<Rigidbody>()!=null)
						GetComponent<Rigidbody>().AddForce(test);
				}
				
				double finalV = vel.z;
				if(Mathf.Abs (vel.z)>5.5)
				{
					if(vel.z>0)
						finalV = 5.5;
					else
						finalV = -5.5;
				}
				if(Input.GetKey (KeyCode.A))
				{
					transform.Rotate(Vector3.down*(float)(finalV/10)* Time.deltaTime * 50);
				}
				if(Input.GetKey (KeyCode.D))
				{
					transform.Rotate(Vector3.up*(float)(finalV/10)* Time.deltaTime * 50);
				}
			}
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
