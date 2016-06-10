using UnityEngine;
using System.Collections;

public class CharacterMotorN : MonoBehaviour {

	public float aceleration = 40;
	public float speed = 10;
	public float jumpForce = 2;
	public bool canControl = true;
	private bool canJump = true;
	private bool grounded;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(canControl && GetComponent<newPlayer>().enabled)
		{
			
			grounded = Physics.Raycast(transform.position, -Vector3.up,(float)(GetComponent<Collider>().bounds.extents.y + 0.1));
			
			if(Input.GetKeyDown (KeyCode.Space))
			{
				StartCoroutine(doJump());
			}
			
			if(!grounded)
				GetComponent<Rigidbody>().drag = 0;
			else
			{
				GetComponent<Rigidbody>().drag = 2;
				if(transform.rotation.eulerAngles.x != 0 || transform.rotation.eulerAngles.z != 0)
					transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
			}
			
			if(Input.GetKey (KeyCode.W))
			{
				Vector3 test = transform.TransformDirection (new Vector3 (0, 0, speed*aceleration*50* Time.deltaTime));
				if(Mathf.Abs (GetComponent<Rigidbody>().velocity.z)<speed && Mathf.Abs (GetComponent<Rigidbody>().velocity.x)<speed)
				{
					if(canJump)
						GetComponent<Rigidbody>().AddForce(test);
					else
						GetComponent<Rigidbody>().AddForce(test/8);
				}
			}
			else if(Input.GetKey (KeyCode.S))
			{
				Vector3 test = transform.TransformDirection (new Vector3 (0, 0, -speed*aceleration*50* Time.deltaTime));
				if(Mathf.Abs (GetComponent<Rigidbody>().velocity.z)<speed && Mathf.Abs (GetComponent<Rigidbody>().velocity.x)<speed)
					GetComponent<Rigidbody>().AddForce(test);
			}
			
			if(Input.GetKey (KeyCode.A))
			{
				Vector3 test = transform.TransformDirection (new Vector3 (-speed*aceleration*50* Time.deltaTime, 0, 0));
				if(Mathf.Abs (GetComponent<Rigidbody>().velocity.z)<speed && Mathf.Abs (GetComponent<Rigidbody>().velocity.x)<speed)
					GetComponent<Rigidbody>().AddForce(test);
			}
			else if(Input.GetKey (KeyCode.D))
			{
				Vector3 test = transform.TransformDirection (new Vector3 (speed*aceleration*50* Time.deltaTime, 0, 0));
				if(Mathf.Abs (GetComponent<Rigidbody>().velocity.z)<speed && Mathf.Abs (GetComponent<Rigidbody>().velocity.x)<speed)
				{
					if(canJump)
						GetComponent<Rigidbody>().AddForce(test);
					else
						GetComponent<Rigidbody>().AddForce(test/8);
				}
			}
			
		}
		
		Vector3 speedF = transform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
		if(Mathf.Abs (speedF.z)>6)
		{
			double az = Mathf.Abs (speedF.z)-6;
			if(speedF.z>0)
				GetComponent<Rigidbody>().AddForce(transform.TransformDirection(new Vector3(0,0,(float)az)));
			else
				GetComponent<Rigidbody>().AddForce(transform.TransformDirection(new Vector3(0,0,-(float)az)));
		}
	}
	
	IEnumerator doJump() {
	
		if(grounded && canJump)
		{
			Vector3 test =  new Vector3 (0, jumpForce, 0);
			
			//print(speedF);
			//if(speedF < 6)
			{
				
				GetComponent<Rigidbody>().AddForce(test);
				canJump=false;
				yield return new WaitForSeconds(0.5f);
				canJump=true;
			}
		}
		
	}
}
