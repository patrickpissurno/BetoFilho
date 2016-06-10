using UnityEngine;
using System.Collections;

public class GUISonEnable : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(GetComponent<GUI_BASIC_SCREEN>().enabled)
			SetVisibility(gameObject,true);
		else
			SetVisibility(gameObject,false);
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
