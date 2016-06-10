using UnityEngine;
using System.Collections;

public class Helicopter_MainRotor : MonoBehaviour {

	public double maxRotateSpeed = 40;
	public double rotateSpeed = 0;
	public bool powered = false;
	private bool speedNormal = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(powered)
		{
			if(!speedNormal)
			{
				if(rotateSpeed<maxRotateSpeed/2)
					rotateSpeed+=0.05*Time.deltaTime*50;
				else
				{
					rotateSpeed=maxRotateSpeed/2;
					speedNormal=true;
				}
			}
			else
			{
				if(Input.GetKey(KeyCode.Z))
				{
					if(rotateSpeed>0)
						rotateSpeed-=0.05*Time.deltaTime*50;
					else
						rotateSpeed=0;
				}
				else if(Input.GetKey(KeyCode.X))
				{
					if(rotateSpeed<maxRotateSpeed)
						rotateSpeed+=0.05*Time.deltaTime*50;
					else
						rotateSpeed=maxRotateSpeed;
				}
				
			}
		}
		else
		{
			speedNormal=false;
			if(rotateSpeed>0)
				rotateSpeed-=0.05*Time.deltaTime*50;
			else
				rotateSpeed=0;
		}
		transform.Rotate((new Vector3(0,(float)rotateSpeed,0)));
	}
}
