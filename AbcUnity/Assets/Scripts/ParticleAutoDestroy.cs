using UnityEngine;
using Jalomieli.Extensions;

public class ParticleAutoDestroy : MonoBehaviour 
{
	private ParticleSystem particleSys;	
	public void Start() 
	{
		particleSys = this.gameObject.DemandComponent<ParticleSystem>();
	}
	public void Update() 
	{
		if (particleSys)
		{
			if (!particleSys.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}
