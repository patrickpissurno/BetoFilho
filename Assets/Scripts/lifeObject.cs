using UnityEngine;
using System.Collections;

public class lifeObject : MonoBehaviour {
	
	public bool senabled=true;
	public double hp;
	private double maxHp;
	public GameObject self;
	public GameObject smoke;
	public GameObject flame;
	public GameObject explosion;
	private GameObject smokeInstance;
	private GameObject flameInstance;
	private GameObject explosionInstance;
	public AudioSource soundSource;
	public AudioClip explosionSound;
	public AudioClip smokeSound;
	public AudioClip flameSound;
	private bool canBurn=true;
	private float size;
	public Transform effectSpawn;

	// Use this for initialization
	void Start () {
		if(senabled)
			maxHp=hp;
		Vector3 v = self.GetComponent<Collider>().bounds.size;
		size = (float)(v.magnitude/9.151196f);
		if(size<0f)
			size=0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(senabled)
		{
			if(smokeInstance!=null)
			{
				smokeInstance.transform.position = effectSpawn.position;//transform.position+self.collider.bounds.extents.y*transform.up+transform.forward*self.collider.bounds.extents.z*0.5f;
				smokeInstance.transform.rotation = transform.rotation;
			}
			if(flameInstance!=null)
			{
				flameInstance.transform.position = effectSpawn.position;//transform.position+self.collider.bounds.extents.y*transform.up+transform.forward*self.collider.bounds.extents.z*0.5f;
				flameInstance.transform.rotation = transform.rotation;
				StartCoroutine(burnDamage());
			}
			if(hp>maxHp/4 && hp<=maxHp/2 && smokeInstance==null)
			{
				smokeInstance = Instantiate(smoke,transform.position,transform.rotation) as GameObject;
				smokeInstance.GetComponent<ParticleFX_Main>().scale=size;
				if(soundSource!=null)
				{
					soundSource.loop=true;
					soundSource.clip=smokeSound;
					soundSource.Play();
				}
			}
			else if(hp>0 && hp<=maxHp/4 && flameInstance==null)
			{
				if(smokeInstance!=null)
				{
					TimedDestruction SmokeTimer = smokeInstance.AddComponent<TimedDestruction>();
					SmokeTimer.TimeToDestruct = 10f;
					SetEmission(smokeInstance,false);
					smokeInstance = null;
				}
				if(soundSource!=null)
				{
					soundSource.Stop ();
					soundSource.loop=true;
					soundSource.clip=flameSound;
					soundSource.Play();
				}

				flameInstance = Instantiate(flame,transform.position,transform.rotation) as GameObject;
				flameInstance.GetComponent<ParticleFX_Main>().scale=size;
			}
			else if(hp<=0 && explosionInstance==null)
			{
				if(flameInstance!=null)
				{
					TimedDestruction FlameTimer = flameInstance.AddComponent<TimedDestruction>();
					FlameTimer.TimeToDestruct = 5f;
					SetEmission(flameInstance,false);
					flameInstance = null;
				}
				explosionInstance = Instantiate(explosion,effectSpawn.position/*transform.position+transform.up*self.collider.bounds.extents.y*/,transform.rotation) as GameObject;
				explosionInstance.GetComponent<ParticleFX_Main>().scale=size;
				if(explosionSound!=null)
				{	
					AudioSource explosionAudio = explosionInstance.AddComponent<AudioSource>();
					explosionAudio.minDistance=10f;
					explosionAudio.spread=3f;
					explosionAudio.PlayOneShot(explosionSound, 1F);
				}
				Destroy(gameObject);
			}
		}
	}
	
	void SetEmission(GameObject obj, bool bl)
	{
		if(obj!=null)
		{
			ParticleEmitter[] rs = obj.GetComponentsInChildren<ParticleEmitter>();
			foreach (ParticleEmitter r in rs)
			{
				r.emit = bl;
			}
		}
	}
	
	IEnumerator burnDamage()
	{
		if(canBurn)
		{
			hp--;
			canBurn=false;
			yield return new WaitForSeconds(1);
			canBurn=true;
		}
	}
}
