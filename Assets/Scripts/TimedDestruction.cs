using UnityEngine;
using System.Collections;

public class TimedDestruction : MonoBehaviour {

	public float TimeToDestruct;
	// Use this for initialization
	void Start () {
		StartCoroutine(selfdestroy());
	}
	
	IEnumerator selfdestroy()
	{
		yield return new WaitForSeconds(TimeToDestruct);
		Destroy(gameObject);
	}
}
