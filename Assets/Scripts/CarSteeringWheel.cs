using UnityEngine;
using System.Collections;

public class CarSteeringWheel : MonoBehaviour {
	
	private CarSystem carro;
	
	// Use this for initialization
	void Start () {
		carro = transform.parent.gameObject.transform.parent.gameObject.GetComponent<CarSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.A) && carro.playerIn)
			transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 339);
		else if(Input.GetKey (KeyCode.D) && carro.playerIn)
			transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 69);
		else
			transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, transform.localRotation.eulerAngles.y, 24);
	}
}
