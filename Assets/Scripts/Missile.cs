using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
	private double speed = 0;
	public double maxSpeed = 20;
	public double speedMultiplier = 5;
	public bool destroyOnCollision = true;
	private bool start = true;
	public GameObject smokeObject;
	private ParticleEmitter smokeEmitter;
	public GameObject explosionFx;

	// Use this for initialization
	void Start () {
		smokeEmitter = smokeObject.GetComponent<ParticleEmitter>();
	}
	
	// Update is called once per frame
	void Update () {
		if(start)
		{
			if(speed<maxSpeed)
				speed+=0.5;
			else
				speed=maxSpeed;
		}
		GetComponent<Rigidbody>().AddForce(transform.forward*(float)speed*Time.deltaTime*(float)speedMultiplier);
	}
	
	void OnCollisionEnter(Collision col)
	{
		//if(col.gameObject.name!="Terrain")
		{
			speed=0;
			start=false;
			if(destroyOnCollision)
			{
				Destroy(gameObject);
				if(explosionFx!=null)
					Instantiate(explosionFx,transform.position, Quaternion.Euler(0,0,0));
			}
			smokeEmitter.emit=false;
		}
	}
}
