using UnityEngine;
using System.Collections;

public class UnderWater : MonoBehaviour {

	//public float waterLevel;
	public GameObject jogador;
	private bool isUnderwater;
	private Color normalColor;
	public Color underwaterColor;
	private float normalDensity;
	private FogMode normalFogMode;
	
	// Use this for initialization
	void Start () {
		normalColor = RenderSettings.fogColor;
		normalDensity = RenderSettings.fogDensity;
		underwaterColor = new Color(0.22f,0.65f,0.77f,0.5f);
		normalFogMode = RenderSettings.fogMode;
	}
	
	// Update is called once per frame
	void Update () {
		/*if((transform.position.y<waterLevel)!=isUnderwater)
		{
			isUnderwater = transform.position.y < waterLevel;*/
			if(isUnderwater) SetUnderwater();
			if(!isUnderwater) SetNormal();
		//}
	}
	
	void SetNormal()
	{
		RenderSettings.fogColor = normalColor;
		RenderSettings.fogDensity = normalDensity;
		RenderSettings.fogMode = normalFogMode;
	}
	
	void SetUnderwater()
	{
		RenderSettings.fogColor = underwaterColor;
		RenderSettings.fogDensity = 0.08f;
		RenderSettings.fogMode = FogMode.Exponential;
	}
	
	void OnTriggerStay(Collider col)
	{
		if(col.gameObject.name == jogador.gameObject.name)
		{
			//print ("Jogador colidiu");
			/*if(jogador.rigidbody.velocity.y>0)
			{
				isUnderwater=false;
			}
			else if(jogador.rigidbody.velocity.y<0)
			{*/
			if(!isUnderwater)
				isUnderwater=true;
			//}
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.name == jogador.gameObject.name)
			isUnderwater=false;
	}
}
