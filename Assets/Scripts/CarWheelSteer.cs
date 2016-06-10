using UnityEngine;
using System.Collections;

public class CarWheelSteer : MonoBehaviour {

	/*private double steerSpeed=0;
	private string steerDir = "center";
	private bool steerIdle = true;
	private string steerPos = "center";*/
	private CarSystem carro;
	
	// Use this for initialization
	void Start () {
		carro = transform.parent.gameObject.GetComponent<CarSystem>();
	}
	
	// Update is called once per frame
	void Update () {
			/*switch(steerDir)
			{
			case "center":
				if(steerSpeed<0 && !steerIdle)
					steerSpeed+=0.05;
				else if(steerSpeed>0 && !steerIdle)
					steerSpeed-=0.05;
				if(steerSpeed==0 && !steerIdle)
				{
					steerIdle=true;
					steerPos="center";
				}
				break;
			case "left":
				if(steerSpeed<0 && !steerIdle)
					steerSpeed+=0.05;
				else
				{
					steerIdle=true;
					steerPos="left";
				}
				break;
			case "right":
				if(steerSpeed>0 && !steerIdle)
					steerSpeed-=0.05;
				else
				{
					steerIdle=true;
					steerPos="right";
				}
				break;
			}
			*/
			if(Input.GetKey (KeyCode.A) && carro.playerIn)
			{
				/*if(steerDir!="left")
				{
					steerSpeed=-2;
					steerDir="left";
					steerIdle=false;
				}*/
				transform.localRotation = Quaternion.Euler(0, 315, 0);
			}
			else if(Input.GetKey (KeyCode.D) && carro.playerIn)
			{
				/*if(steerDir!="right")
				{
					steerSpeed=2;
					steerDir="right";
					steerIdle=false;
				}*/
				//transform.TransformDirection(new Vector3(0,90,0));
				transform.localRotation = Quaternion.Euler(0, 45, 0);
			}
			else
			{
				//transform.TransformDirection(new Vector3(0,0,0));
				transform.localRotation = Quaternion.Euler(0, 0, 0);
			}
			/*if(!Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A))
			{
				if(steerDir!="center" && steerPos != "center" && steerIdle)
				{
					if(steerPos == "left")
						steerSpeed=2;
					else if(steerPos == "right")
						steerSpeed=-2;
					steerDir="center";
					steerIdle=false;
				}
			}*/
			//transform.Rotate(new Vector3(0,(float)steerSpeed,0));
	}
}
