using UnityEngine;
using System.Collections;

public class GUICameraS : MonoBehaviour {

	public GameObject CONFIG;
	private MainGame MGame;
	private GameObject MENUS;
	private GameObject SPAWN;
	// Use this for initialization
	void Start () {
		MGame = CONFIG.GetComponent<MainGame>();
		MENUS = transform.Find("MENUS").gameObject;
		if(MENUS!=null)
			SPAWN = MENUS.transform.Find ("SPAWN").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		//RESETS STUFF
		if(GetComponent<Camera>().enabled && RenderSettings.fog)
		{
			RenderSettings.fog=false;
			Cursor.visible = true;
		}
		else if(!GetComponent<Camera>().enabled && !RenderSettings.fog)
		{
			RenderSettings.fog=true;
			Cursor.visible = false;
		}
		
		//GUIs
		if(GetComponent<Camera>().enabled)
		{
			switch(MGame.GUIScreen)
			{
				case "Spawn":
					disableAllExcept("Spawn");
					spawnLocation();
					
					if(!SPAWN.GetComponent<GUI_BASIC_SCREEN>().enabled)
						SPAWN.GetComponent<GUI_BASIC_SCREEN>().enabled=true;
					break;
			}
		}
		else
		{
			disableAllExcept("");
		}
		
	}
	
	//GUI FUNCTIONS
	void closeActualMenu()
	{
		MGame.GUIOpen=false;
		MGame.GUIScreen="none";
	}
	void disableAllExcept(string except)
	{
		if(except!="Spawn")
			SPAWN.GetComponent<GUI_BASIC_SCREEN>().enabled=false;
	}
	
	//SCREENS/MENUS
	void spawnLocation()
	{
		//BUTTONS
		if (Input.GetButtonDown("Fire1")) {
			Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit))
			{
				switch(hit.transform.gameObject.name)
				{
					case "GUI_Spawn_BTN_A":
						MGame.jogador.transform.position = CONFIG.transform.Find("SpawnPoints").gameObject.transform.Find("Bootcamp").gameObject.transform.position;
						closeActualMenu();
						break;
					case "GUI_Spawn_BTN_B":
						MGame.jogador.transform.position = CONFIG.transform.Find("SpawnPoints").gameObject.transform.Find("Desert").gameObject.transform.position;
						closeActualMenu();
						break;
					case "GUI_Spawn_BTN_C":
						MGame.jogador.transform.position = CONFIG.transform.Find("SpawnPoints").gameObject.transform.Find("Forest").gameObject.transform.position;
						closeActualMenu();
						break;
					case "GUI_Spawn_BTN_D":
						MGame.jogador.transform.position = CONFIG.transform.Find("SpawnPoints").gameObject.transform.Find("City").gameObject.transform.position;
						closeActualMenu();
						break;
				}
			}
			
		}
	}
}
