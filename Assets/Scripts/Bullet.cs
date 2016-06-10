using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public AudioSource self;
	public AudioClip ShellDrop1;
	public AudioClip ShellDrop2;
	public AudioClip ShellDrop3;
	
	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name=="Terrain" && col.relativeVelocity.magnitude > 3)
		{
			float snd = Mathf.Floor(Random.Range (0,2));
			if(snd == 0 && ShellDrop1!=null)
				self.PlayOneShot(ShellDrop1, 0.6F);
			else if(snd == 1 && ShellDrop2!=null)
				self.PlayOneShot(ShellDrop2, 0.6F);
			else if(snd == 2 && ShellDrop3!=null)
				self.PlayOneShot(ShellDrop3, 0.6F);
		}
	}
}
