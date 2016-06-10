﻿using UnityEngine;
using System.Collections;

public class Headbobbing : MonoBehaviour {

	public float BobbingForce=1f;
	private float timer = 0.0f;
	float bobbingSpeed = 0.18f;
	float bobbingAmount = 0.05f;
	float midpoint = 1.0f;
	
	void Update () {
		float waveslice = 0.0f;
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		
		Vector3 cSharpConversion = transform.localPosition; 
		
		if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) {
			timer = 0.0f;
		}
		else {
			waveslice = Mathf.Sin(timer);
			timer = timer + bobbingSpeed *Time.deltaTime*60;
			if (timer > Mathf.PI * 2) {
				timer = timer - (Mathf.PI * 2);
			}
		}
		if (waveslice != 0) {
			float translateChange = waveslice * bobbingAmount * BobbingForce;
			float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
			totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f);
			translateChange = totalAxes * translateChange;
			cSharpConversion.y = midpoint + translateChange;
		}
		else {
			cSharpConversion.y = midpoint;
		}
		
		transform.localPosition = cSharpConversion;
	}
	
	
}