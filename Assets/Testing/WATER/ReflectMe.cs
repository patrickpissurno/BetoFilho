using UnityEngine;
using System.Collections;

public class ReflectMe : MonoBehaviour {
	public Cubemap CubeMap;
	public double updateRate;
	//public Material currentMaterial;
	private Transform renderFromPosition;
	private double minz = -1.0;

	// Use this for initialization
	void Start () {
		renderFromPosition = transform;
		RenderMe ();
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Time.time - updateRate > minz){
			minz = Time.time - Time.deltaTime;
			RenderMe();
			currentMaterial.SetTexture("_Cube",CubeMap);
			renderer.material = currentMaterial;
		}*/
	}
	
	void RenderMe()
	{
		//GameObject go = new GameObject("CubemapCamera"+Random.seed, typeof(Camera));
		
		//go.GetComponent<Camera>().backgroundColor = Color.black;
		//go.GetComponent<Camera>().cullingMask = ~(1<<8);
		//go.transform.position = renderFromPosition.position;
		//if(renderFromPosition.GetComponent<Renderer>())go.transform.position = renderFromPosition.GetComponent<Renderer>().bounds.center;
		//go.transform.rotation = Quaternion.identity;
		
		//go.GetComponent<Camera>().RenderToCubemap(CubeMap);
		
		//DestroyImmediate(go);
	}
	
}