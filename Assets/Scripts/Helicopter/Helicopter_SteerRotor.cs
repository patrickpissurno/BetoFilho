using UnityEngine;
using System.Collections;

public class Helicopter_SteerRotor : MonoBehaviour {

	private Helicopter_Main main;
	public double speed = 0;
	// Use this for initialization
	void Start () {
		main = transform.parent.gameObject.transform.parent.gameObject.GetComponent<Helicopter_Main>();
	}
	
	// Update is called once per frame
	void Update () {
			
		if(main.playerIn)
		{
			if(Input.GetKey(KeyCode.Q))
			{
				if(speed<25)
					speed+=0.3*Time.deltaTime*50;
				else
					speed=25;
			}
			else if(Input.GetKey(KeyCode.E))
			{
				if(speed>-25)
					speed-=0.3*Time.deltaTime*50;
				else
					speed=-25;
			}
			else
			{
				restoreSpeed();
			}
		}
		else
		{
			restoreSpeed();
		}
		
		transform.Rotate (new Vector3((float)speed,0,0));
	}
	
	void restoreSpeed (){
		if(speed>0)
			speed-=0.3*Time.deltaTime*50;
		else if(speed<0)
			speed+=0.3*Time.deltaTime*50;
		else
			speed=0;
	}
}
