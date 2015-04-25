using UnityEngine;

public class ParticleAutoDestroy : MonoBehaviour 
{
	private ParticleSystem particleSystem;	
	public void Start() 
	{
		particleSystem = GetComponent<ParticleSystem>();
	}
	public void Update() 
	{
		if (particleSystem)
		{
			if (!particleSystem.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}
