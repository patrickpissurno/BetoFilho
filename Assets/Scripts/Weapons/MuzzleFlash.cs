using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {

	public void Flash()
	{
		StartCoroutine(lFlash ());
	}
	
	IEnumerator lFlash()
	{
		GetComponent<Light>().enabled=true;
		GetComponent<ParticleEmitter>().Emit();
		yield  return new WaitForSeconds(0.05f);
		GetComponent<Light>().enabled=false;
	}
}
