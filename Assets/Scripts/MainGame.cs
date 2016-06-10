using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {
	
	public GameObject FirstPersonCamera;
	public GameObject ThirdPersonCamera;
	public GameObject GUICamera;
	public string actualCamera = "third";
	public GameObject actCamera;
	public string lastCamera = "first";
	public bool cameraCanChange = true;
	public bool showCrosshair = true;
	public Texture2D Crosshair;
	public MeshRenderer jogadorMesh;
	public GameObject jogador;
	public bool GUIOpen=false;
	public string GUIScreen = "none";
	private newPlayer jogadorMAIN;
	
	// Use this for initialization
	void Start () {
		Cursor.visible = false; 
		jogadorMAIN = jogador.GetComponent<newPlayer>();
		//changeCamera();
	}
	
	// Update is called once per frame
	void Update () {
		switch(actualCamera)
		{
			case "first":
				if(actCamera!=FirstPersonCamera)
					actCamera=FirstPersonCamera;
				break;
			case "third":
				if(actCamera!=ThirdPersonCamera)
					actCamera=ThirdPersonCamera;
				break;
			default:
				actCamera = null;
				break;
		}
	
		if (Input.GetKeyDown (KeyCode.Return)) {  
			Application.LoadLevel (0);  
		}
		
		if(Input.GetKeyDown(KeyCode.V) && !GUIOpen)
		{
			changeCamera();
		}
		
		if(Input.GetKeyDown(KeyCode.M) && !GUIOpen)
		{
			GUIOpen=true;
			GUIScreen="Spawn";
		}
		
		if(GUIOpen && actualCamera!="none")
		{
			if(actualCamera=="third")
			{
				ThirdPersonCamera.GetComponent<Camera>().enabled=false;
				jogadorMesh.enabled=false;
			}
			else if(actualCamera=="first")
			{
				FirstPersonCamera.GetComponent<Camera>().enabled=false;
				jogadorMesh.enabled=true;
			}
			lastCamera=actualCamera;
			actualCamera="none";
			GUICamera.GetComponent<Camera>().enabled=true;
			jogadorMAIN.enabled=false;
		}
		else if(!GUIOpen && actualCamera=="none")
		{
			GUICamera.GetComponent<Camera>().enabled=false;
			jogadorMAIN.enabled=true;
			if(lastCamera=="first")
			{
				actualCamera="third";
				changeCamera();
			}
			else if(lastCamera=="third")
			{
				actualCamera="first";
				changeCamera();
			}
		}
	}
	public void changeCamera()
	{
		if(cameraCanChange)
		{
			if(actualCamera=="first")
			{
				lastCamera=actualCamera;
				actualCamera="third";
				FirstPersonCamera.GetComponent<Camera>().enabled=false;
				ThirdPersonCamera.GetComponent<Camera>().enabled=true;
				jogadorMesh.enabled=true;
			}
			else if(actualCamera=="third")
			{
				lastCamera=actualCamera;
				actualCamera="first";
				FirstPersonCamera.GetComponent<Camera>().enabled=true;
				ThirdPersonCamera.GetComponent<Camera>().enabled=false;
				jogadorMesh.enabled=false;
			}
		}
	}
	void OnGUI() {
		//if(showCrosshair && !GUIOpen)
			//GUI.Label(new Rect(Screen.width/2-Crosshair.width/2+3, Screen.height/2-Crosshair.height/2+0.5f, Crosshair.width, Crosshair.height), Crosshair);
	}
}
