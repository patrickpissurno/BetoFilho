using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public bool senabled=true;
	private newPlayer nPlayer;
	public GameObject currentWeapon;
	public Transform weaponPos;
	private MainGame mGame;
	public Weapon_Main wscript;
	public bool canShoot=true;
	public bool laserEnabled=true;
	
	// Use this for initialization
	void Start () {
		nPlayer = GetComponent<newPlayer>();
		mGame = GameObject.Find("CONFIG").GetComponent<MainGame>();
	}
	
	// Update is called once per frame
	void Update () {
		if(weaponPos!=null)
		{
			if(currentWeapon!=null)
			{
				
				currentWeapon.GetComponent<Rigidbody>().velocity=Vector3.zero;
				
				//if((transform.Find("SelfLook").rotation.eulerAngles.x<360 && transform.Find("SelfLook").rotation.eulerAngles.x>310)||
				   //(transform.Find("SelfLook").rotation.eulerAngles.x<30 && transform.Find("SelfLook").rotation.eulerAngles.x>0))
					currentWeapon.transform.rotation = transform.Find("SelfLook").rotation;
			}
			if(senabled)
			{
				if(wscript!=null)
					wscript.senabled=true;
				//WEAPON DROP
				if(Input.GetKeyDown(KeyCode.G))
					dropWeapon();
				//WEAPON PICK
				if(Input.GetKeyDown (KeyCode.E))
					pickWeapon();
				//CHANGE AIM
				if(Input.GetButtonDown("Fire2"))
					changeAim();
			}
			else
			{
				if(wscript!=null)
					wscript.senabled=false;
			}
		}
	}
	void LateUpdate()
	{
		if(weaponPos!=null)
		{
			if(currentWeapon!=null)
			{
				switch(wscript.weaponClass)
				{
				case "Launcher":
					//currentWeapon.rigidbody.velocity=Vector3.zero;
					currentWeapon.transform.position = weaponPos.position;
					//currentWeapon.rigidbody.velocity=Vector3.zero;
					break;
				case "Sniper":
					//currentWeapon.rigidbody.velocity=Vector3.zero;
					currentWeapon.transform.position = weaponPos.position+Vector3.up*-0.15f;
					//currentWeapon.rigidbody.velocity=Vector3.zero;
					break;
				default:
					//currentWeapon.rigidbody.velocity=Vector3.zero;
					currentWeapon.transform.position = weaponPos.position;
					//currentWeapon.rigidbody.velocity=Vector3.zero;
					break;
				}
			}
		}
	}
	
	public void changeAim()
	{
		if(currentWeapon!=null)
		{
			if(currentWeapon.transform.Find("AimView")!=null)
			{
				MainGame CONFIG = GetComponent<newPlayer>().CONFIG;
				if(CONFIG.FirstPersonCamera.GetComponent<FPSCamera>().target==transform.Find("MainView2"))
				{
					CONFIG.FirstPersonCamera.GetComponent<FPSCamera>().target=transform.Find("MainView");
					if(wscript!=null)
						wscript.customSightEnabled=true;
				}
				else
				{
					CONFIG.FirstPersonCamera.GetComponent<FPSCamera>().target=transform.Find("MainView2");
					if(wscript!=null)
						wscript.customSightEnabled=false;
				}
			}
		}
	}
	
	void dropWeapon()
	{
		if(currentWeapon!=null)
		{
			//Weapon_Main script = currentWeapon.GetComponent<Weapon_Main>();
			wscript.playerIn=false;
			wscript.jogador=null;
			wscript.canShoot=true;
			wscript.senabled=true;
			wscript.transform.GetComponent<Rigidbody>().detectCollisions = true;
			wscript.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
			wscript=null;
			MainGame CONFIG = GetComponent<newPlayer>().CONFIG;
			if(CONFIG.FirstPersonCamera.GetComponent<FPSCamera>().target==transform.Find("MainView2"))
				changeAim();
			currentWeapon.transform.parent=null;
			currentWeapon=null;
		}
	}
	
	void pickWeapon()
	{
		if(currentWeapon==null)
		{
			RaycastHit[] hits;
			Vector3 dir = mGame.actCamera.transform.TransformDirection(0,0,10)+(mGame.actCamera.transform.position-transform.position);
			hits = Physics.SphereCastAll(transform.position,0.5f,dir, 2f);
			if(hits.Length>0)
			{
				foreach(RaycastHit hit in hits)
				{
					Weapon_Main hitScript = hit.transform.gameObject.GetComponent<Weapon_Main>();
					if(hitScript!=null)
					{
						currentWeapon = hit.transform.gameObject;
						
						hitScript.playerIn=true;
						hitScript.senabled=true;
						hitScript.jogador = gameObject;
						hitScript.canShoot=true;
						hitScript.transform.GetComponent<Rigidbody>().detectCollisions = false;
						wscript = hitScript;
						currentWeapon.transform.parent = transform;
						//laserEnabled=true;
						
						if(currentWeapon.transform.Find ("AimView")!=null && transform.Find ("MainView2")!=null)
						{
							Transform mv2 = transform.Find ("MainView2");
							Transform mv = transform.Find ("MainView");
							Transform target = currentWeapon.transform.Find ("AimView");
							
							Vector3 oldP = currentWeapon.transform.position;
							Quaternion oldR = currentWeapon.transform.rotation;
							
							currentWeapon.transform.position = (mv.position + transform.position)/2;
							currentWeapon.transform.rotation = Quaternion.Euler ((mv.rotation.eulerAngles.x+transform.rotation.eulerAngles.x)/2,(mv.rotation.eulerAngles.y+transform.rotation.eulerAngles.y)/2,(mv.rotation.eulerAngles.z+transform.rotation.eulerAngles.z)/2);
							
							Transform ps = target.parent;
							target.parent = transform;
							mv2.transform.localPosition = target.localPosition;
							mv2.transform.localRotation = target.localRotation;
							target.parent = ps;
							
							
							currentWeapon.transform.position = oldP;
							currentWeapon.transform.rotation = oldR;
						}
						
						break;
					}
				}
			}
		}
	}

	
}