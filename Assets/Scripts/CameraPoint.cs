using UnityEngine;
using System.Collections;

public class CameraPoint : MonoBehaviour {

	public FPSCamera currentCameraP;
	public FPSCamera currentCameraR;
	public Quaternion rotation;
	// Use this for initialization
	void Start () {
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	// Update is called once per frame
	/*public void UpdateMe () {
		//if(transform.parent.Find("SelfLook")!=null)
			//rotation = transform.parent.Find("SelfLook").gameObject.GetComponent<SelfLooker>().rotation;
		if(transform.parent.Find("SelfLook")!=null && transform.parent.Find("SelfLook").GetComponent<SelfLooker>()!=null)
		{
			transform.parent.Find("SelfLook").GetComponent<SelfLooker>().UpdateMe();
			rotation = transform.parent.Find("SelfLook").GetComponent<SelfLooker>().lRotation;
		}
		
		if(transform.parent.Find("SelfLook")!=null && transform.parent.Find("SelfLook").GetComponent<SelfLooker>()!=null)
			rotation = transform.parent.Find("SelfLook").GetComponent<SelfLooker>().UpdateMe();
		
		if(currentCameraR!=null)
		{
			if(currentCameraR.targetR == gameObject)
				currentCameraR.UpdateRot();
			else
				currentCameraR=null;
		}
		
	}*/
	
	/*void LateUpdate()
	{
		if(currentCameraP!=null)
		{
			if(currentCameraP.target == gameObject)
				currentCameraP.UpdatePos();
			else
				currentCameraP=null;
		}
	}*/
	
	/*public Quaternion UpdateMe()
	{
		if(transform.parent.Find("SelfLook")!=null && transform.parent.Find("SelfLook").GetComponent<SelfLooker>()!=null)
			rotation = transform.parent.Find("SelfLook").GetComponent<SelfLooker>().UpdateMe();
		return rotation;
	}*/
}
