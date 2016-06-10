using UnityEngine;
using System.Collections;

public class ParticleFX_Main : MonoBehaviour {

	public float scale = 1f;
	
	public ParticleEmitter[] sons;
	
	// Use this for initialization
	void Start () {
		foreach(ParticleEmitter son in sons)
		{
			son.minSize*=scale;
			son.maxSize*=scale;
			son.minEnergy*=scale;
			son.maxEnergy*=scale;
			son.minEmission*=scale;
			son.maxEmission*=scale;
			son.worldVelocity*=scale;
			son.localVelocity*=scale;
			son.rndVelocity*=scale;
		}
	}
}
