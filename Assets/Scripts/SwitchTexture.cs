using UnityEngine;


public class SwitchTexture : MonoBehaviour
{

	public Texture2D[] textures;
	
	private Texture2D _texture;
	private int _textureIndex;
	private ParticleSystem _ps; 
	
	private ParticleSystem.EmissionModule _emission;
	private ParticleSystem.ExternalForcesModule _externalForces;
	private ParticleSystem.NoiseModule _noise;
	private ParticleSystem.ShapeModule _shape;

	void Start()
	{
		_ps = GetComponent<ParticleSystem>();
		
		_emission = _ps.emission;
		_externalForces = _ps.externalForces;
		_noise = _ps.noise;
		_shape = _ps.shape;
		
		_shape.texture = textures[_textureIndex];
		_emission.rateOverTime = 0;
	}
	
	public void NextTexture()
	{
		_noise.enabled = false;
		_externalForces.enabled = false;
		
		_textureIndex++;
		_textureIndex %= textures.Length;
		_shape.texture = textures[_textureIndex];
		
		_ps.Emit(10000);
		Invoke (nameof(BlowAway), 1);
	}

	
	public void BlowAway()
	{
		_noise.enabled = true;
		_externalForces.enabled = true;
	}
	
	
}
