using UnityEngine;
using System.Collections;

public class Weapon_Main : MonoBehaviour {

	public bool senabled=true;
	
	public string weaponClass;
	public GameObject customSight;
	public bool customSightEnabled=true;
	public float FPS;
	public GameObject projectile;
	public float shootForce = 20f;
	public float maxAmmo;
	public float currentAmmo;
	public bool canShoot=true;
	public Transform spawnPos;
	
	public bool playerIn=false;
	public GameObject jogador;
	
	public AudioSource soundPlayer;
	public AudioClip soundClip;
	public float soundVolume=1f;
	
	public GameObject MuzzleFlash;
	
	private string changedVisibility="none";
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		if(senabled)
		{
			if(playerIn)
			{
				GetComponent<Rigidbody>().velocity=Vector3.zero;
				if (Input.GetButton("Fire1") && canShoot)
				{
					StartCoroutine(shoot());
				}
				if (Input.GetKeyDown(KeyCode.R) && canShoot)
				{
					StartCoroutine(reload());
				}
				if(customSight!=null && customSight.GetComponent<Laser_Main>()!=null)
				{
					if(!customSight.GetComponent<Laser_Main>().senabled && customSightEnabled)
						customSight.GetComponent<Laser_Main>().senabled=true;
					else if(customSight.GetComponent<Laser_Main>().senabled && !customSightEnabled)
						customSight.GetComponent<Laser_Main>().senabled=false;
				}
			}
			else
			{
				if(customSight!=null && customSight.GetComponent<Laser_Main>()!=null && customSight.GetComponent<Laser_Main>().senabled)
					customSight.GetComponent<Laser_Main>().senabled=false;
			}
			
			if(changedVisibility!="um")
			{
				SetVisibility(gameObject,true);
				changedVisibility="um";
			}
		}
		else
		{
			if(changedVisibility!="dois")
			{
				SetVisibility(gameObject,false);
				changedVisibility="dois";
			}
		}
		
	}
	
	IEnumerator shoot() {
		if(currentAmmo>0)
		{
			canShoot=false;
			
			currentAmmo--;
			
			if(soundClip!=null && soundPlayer!=null)
			{
				soundPlayer.PlayOneShot(soundClip, soundVolume);
			}
			
			if(MuzzleFlash!=null)
			{
				MuzzleFlash.GetComponent<MuzzleFlash>().Flash ();
				//MuzzleFlash.particleEmitter.Emit();
				//MuzzleFlash.light.enabled=true;
			}
			
			if(spawnPos!=null && jogador!=null)
			{
				GameObject shot = Instantiate(projectile,spawnPos.position + (spawnPos.forward),spawnPos.rotation)as GameObject;
				
				if(shot.GetComponent<Rigidbody>()!=null)
					shot.GetComponent<Rigidbody>().velocity = jogador.GetComponent<Rigidbody>().velocity+spawnPos.TransformDirection(new Vector3(0, 0,shootForce));
			}
			
			float wait = 1f/(float)FPS;
			yield return new WaitForSeconds(wait);
			
			//MuzzleFlash.light.enabled=false;
			
			canShoot=true;
		}
		else if(currentAmmo<=0)
		{
			StartCoroutine(reload ());
		}
	}
	
	IEnumerator reload()
	{
		if(currentAmmo<maxAmmo)
		{
			//float need = maxAmmo-currentAmmo;
			canShoot=false;
			
			if(!customSightEnabled)
			{
				jogador.GetComponent<PlayerWeapon>().changeAim();
			}
			
			float wait = 4f;
			yield return new WaitForSeconds(wait);
			
			currentAmmo=maxAmmo;
			canShoot=true;
		}
	}
	
	void SetVisibility(GameObject obj, bool visibility)
	{
		if(obj!=null && visibility!=null)
		{
			Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
			foreach (Renderer r in renderers)
			{
				r.enabled = visibility;
			}
		}
	}
}
