using UnityEngine;
using System.Collections;

public class FireBubble : MonoBehaviour {

    public Rigidbody effectParticle;
    public Rigidbody coreParticle;
    public float particleVelocity;
    public int numEffectParticles;
    public float rangeEffectParticleOffset;

    private float particleSpawnOffset;


    // Use this for initialization
    void Start () {
        particleSpawnOffset = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Cardboard.SDK.Triggered)
        {
            SpawnParticle(coreParticle);

            for (int counter = 0; counter < numEffectParticles; counter++)
            {
                SpawnParticle(effectParticle);
            }
        }
	}

    void SpawnParticle (Rigidbody particle)
    {
        Vector3 spawnPosition = Camera.main.transform.position + transform.forward * particleSpawnOffset;
        Quaternion spawnRotation = Camera.main.transform.rotation;

        // add random spawn offset for effect particles
        if (particle == effectParticle)
        {
            spawnPosition.x += Random.Range(-rangeEffectParticleOffset, rangeEffectParticleOffset);
            spawnPosition.y += Random.Range(-rangeEffectParticleOffset, rangeEffectParticleOffset);
            spawnPosition.z += Random.Range(-rangeEffectParticleOffset, rangeEffectParticleOffset);
        }
        

        Rigidbody particleClone = (Rigidbody)Instantiate(particle, spawnPosition, spawnRotation);

        particleClone.velocity = Camera.main.transform.forward * particleVelocity;
    }
}
