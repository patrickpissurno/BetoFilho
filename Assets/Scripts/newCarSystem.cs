using UnityEngine;
using System.Collections;

public class newCarSystem : MonoBehaviour {

	public bool playerIn=false;
	public Car cscript;

	void Update()
	{
		if(playerIn && cscript!=null)
			cscript.enabled=true;
		else if(!playerIn && cscript !=null)
			cscript.enabled=false;
			
	}

	
}
