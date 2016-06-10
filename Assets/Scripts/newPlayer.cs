using UnityEngine;
using System.Collections;

public class newPlayer : MonoBehaviour {
    public MainGame CONFIG;

    private GameObject vehicle;
    private CapsuleCollider selfCollider;
    private VEHICLE_TYPE vehicleType = VEHICLE_TYPE.None;
    private SmoothFollowScript followCamera;
    private PlayerWeapon playerWeapon;
    private GameObject render;

	// Use this for initialization
	void Start () {
        selfCollider = GetComponent<CapsuleCollider>();
        followCamera = CONFIG.ThirdPersonCamera.GetComponent<SmoothFollowScript>();
        playerWeapon = GetComponent<PlayerWeapon>();
        render = transform.Find("Graphics").gameObject;
    }
	
	// Update is called once per frame
    void Update()
    {
        if (vehicle != null)
        {
            switch(vehicleType)
            {
                case VEHICLE_TYPE.Car:
                    transform.position = vehicle.transform.position + Vector3.up;
                    break;
                case VEHICLE_TYPE.Helicopter:
                    transform.position = vehicle.transform.position + Vector3.up * 2;
                    break;
                case VEHICLE_TYPE.Aircraft:
                    transform.position = vehicle.transform.position + Vector3.up * 1.2f;
                    break;
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CarSystem c = vehicle.GetComponent<CarSystem>();
                if (c != null)
                    c.playerIn = false;
                Helicopter_Main h = vehicle.GetComponent<Helicopter_Main>();
                if (h != null)
                    h.playerIn = false;
                Aircraft_MAIN a = vehicle.GetComponent<Aircraft_MAIN>();
                if (a != null)
                    a.playerIn = false;
                CONFIG.ThirdPersonCamera.GetComponent<SmoothFollowScript>().target = transform;
                vehicle = null;
                selfCollider.enabled = true;
                GetComponent<CharacterMotorN>().canControl = true;
                GetComponent<CharacterController>().enabled = true;
                playerWeapon.canShoot = true;
                render.SetActive(true);
            }
        }
    }
	void OnCollisionStay(Collision col)
    {
        if (Input.GetKeyDown(KeyCode.E) && vehicle == null)
        {
            CarSystem car = col.gameObject.GetComponent<CarSystem>();
            if (car != null)
            {
                car.playerIn = true;
                followCamera.target = car.gameObject.transform;
                followCamera.distance = 6;
                followCamera.height = 3;
                vehicle = car.gameObject;
                selfCollider.enabled = false;
                GetComponent<CharacterMotorN>().canControl = false;
                GetComponent<CharacterController>().enabled = false;
                vehicleType = VEHICLE_TYPE.Car;
                playerWeapon.canShoot = false;
                render.SetActive(false);
                return;
            }
            Helicopter_Main helicopter = col.gameObject.GetComponent<Helicopter_Main>();
            if(helicopter != null)
            {
                helicopter.playerIn = true;
                followCamera.target = helicopter.gameObject.transform;
                followCamera.distance = 30;
                followCamera.height = 10;
                vehicle = helicopter.gameObject;
                selfCollider.enabled = false;
                GetComponent<CharacterMotorN>().canControl = false;
                GetComponent<CharacterController>().enabled = false;
                vehicleType = VEHICLE_TYPE.Helicopter;
                playerWeapon.canShoot = false;
                render.SetActive(false);
                return;
            }
            Aircraft_MAIN aircraft = col.gameObject.GetComponent<Aircraft_MAIN>();
            if (aircraft != null)
            {
                aircraft.playerIn = true;
                followCamera.target = aircraft.gameObject.transform;
                followCamera.distance = 10;
                followCamera.height = 5;
                vehicle = aircraft.gameObject;
                selfCollider.enabled = false;
                GetComponent<CharacterMotorN>().canControl = false;
                GetComponent<CharacterController>().enabled = false;
                vehicleType = VEHICLE_TYPE.Aircraft;
                playerWeapon.canShoot = false;
                render.SetActive(false);
                return;
            }
        }
    }
}

public enum VEHICLE_TYPE
{
    None,
    Car,
    Helicopter,
    Aircraft
}