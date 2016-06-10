using UnityEngine;
using System.Collections;

public class SelfLooker : MonoBehaviour {

	public Quaternion rotation;
	public Quaternion lRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lRotation = rotation;
		rotation = Quaternion.Euler (transform.rotation.eulerAngles.x,transform.parent.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
	}
}
