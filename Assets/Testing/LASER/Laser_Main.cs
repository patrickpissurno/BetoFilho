using UnityEngine;
using System.Collections;

public class Laser_Main : MonoBehaviour {

	public Transform LStart;
	public LineRenderer line;
	public Light point;
	public bool senabled=false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		if(senabled)
		{
			if(!line.enabled)
				line.enabled=true;
			RaycastHit hit;
			Physics.Raycast (LStart.position, transform.parent.forward, out hit, Mathf.Infinity);
			
			
			if(hit.transform==null)
			{
				//Debug.DrawRay(LStart.position,transform.parent.forward*100,Color.green);
				line.SetPosition(0,LStart.position);
				line.SetPosition(1,LStart.position+(transform.parent.forward*100));
				point.enabled=false;
			}
			else
			{
				//Debug.DrawRay(LStart.position,transform.parent.forward*hit.distance,Color.green);
				line.SetPosition(0,LStart.position);
				line.SetPosition(1,LStart.position+(transform.parent.forward*hit.distance));
				point.transform.position=hit.point;
				point.enabled=true;
			}
		}
		else
		{
			if(line.enabled)
				line.enabled=false;
			if(point.enabled)
				point.enabled=false;
		}
	}
}
