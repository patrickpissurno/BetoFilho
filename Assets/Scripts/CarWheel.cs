using UnityEngine;
using System.Collections;

public class CarWheel : MonoBehaviour {
	
	public bool mirrored = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GameObject father = transform.parent.gameObject.transform.parent.gameObject;
		
		Vector3 vel = father.transform.InverseTransformDirection(father.GetComponent<Rigidbody>().velocity);
		if(mirrored)vel*=-1;
		transform.RotateAround(GetComponent<Renderer>().bounds.center, transform.TransformDirection(new Vector3(1, 0, 0)), (float)(vel.z));
	}
}
