using UnityEngine;
using System.Collections;

public class SkyboxRotation : MonoBehaviour {

	public float skyboxSpeed;
	private MainGame CONFIG;
	// Use this for initialization
	void Start () {
		CONFIG = GameObject.Find("CONFIG").GetComponent<MainGame>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(CONFIG!=null && CONFIG.actCamera!=null)
		{
			GetComponent<Camera>().fieldOfView = CONFIG.actCamera.GetComponent<Camera>().fieldOfView;
			Quaternion normalizing = Quaternion.Lerp(transform.localRotation, CONFIG.actCamera.transform.rotation, 0.5f);
			float yp = normalizing.eulerAngles.y;
			transform.localRotation = Quaternion.Euler(CONFIG.actCamera.transform.rotation.eulerAngles.x,yp,CONFIG.actCamera.transform.rotation.eulerAngles.z);
		}
		transform.parent.Rotate (new Vector3(0,skyboxSpeed*Time.deltaTime,0));
	}
}
