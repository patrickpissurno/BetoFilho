using UnityEngine;
using System.Collections;

public class FPSCamera : MonoBehaviour {

public Transform target;
/*private Vector3 p1;
private Vector3 p2;
private Vector3 p3;*/

void Update()
{	
	//transform.rotation = transform.parent.Find("SelfLook").rotation;
	/*Transform ps = target.parent;
	
	target.parent = transform.parent;
	//target.rotation = transform.parent.Find("SelfLook").rotation;
	transform.localPosition = target.localPosition;
	target.parent = ps;
	transform.rotation = transform.parent.Find("SelfLook").rotation;*/
	
		transform.rotation = transform.parent.Find("SelfLook").rotation;
		transform.localPosition = target.localPosition;
	
}

}
/*
	public GameObject target;
	public GameObject targetR;
	// Use this for initialization
	void Start () {
	}
	
	void Update()
	{
		if(target!=null && transform.parent!=target.transform)
		{
			CameraPoint comP = target.GetComponent<CameraPoint>();
			comP.currentCameraP = GetComponent<FPSCamera>();
			//transform.parent=target.transform;
			//transform.localPosition = Vector3.zero;
			//transform.rotation = transform.parent.rotation;
			
		}
		if(targetR!=null)
		{
			CameraPoint comR = targetR.GetComponent<CameraPoint>();
			comR.currentCameraR = GetComponent<FPSCamera>();
		}
		
		if(target!=null)
		{
			Vector3 unormalized = target.transform.position;
			Vector3 normalized = new Vector3(Mathf.Floor(unormalized.x*100f)/100,Mathf.Floor(unormalized.y*100f)/100,Mathf.Floor(unormalized.z*100)/100);
			//transform.position = normalized;
			
			Vector3 movOffset = Vector3.MoveTowards(transform.position, normalized, Vector3.Distance(transform.position,normalized)*500* Time.deltaTime);
			//if(Mathf.Abs(movOffset.y-transform.position.y)!=0.003924f)
			transform.position = movOffset;
			
			//transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,targetR.transform.rotation.eulerAngles.y,targetR.transform.rotation.eulerAngles.z);
			target.GetComponent<CameraPoint>().UpdateMe();
		}
	}
	
	/*void FixedUpdate () {
			
	}*/
	
	/*public void UpdateRot()
	{
		CameraPoint comR = targetR.GetComponent<CameraPoint>();
		Quaternion unormalized = comR.rotation;
		Quaternion normalized = Quaternion.Euler (unormalized.eulerAngles.x,Mathf.Floor(unormalized.eulerAngles.y*10f)/10,unormalized.eulerAngles.z);
		transform.rotation = normalized;//Quaternion.Euler(transform.rotation.eulerAngles.x,targetR.transform.rotation.eulerAngles.y,targetR.transform.rotation.eulerAngles.z);
	}
}*/
