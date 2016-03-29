using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyTarget : MonoBehaviour {

    public float maxAltitudeBeforeDestruction;
    public static int fishLeft;
    public Rigidbody effectParticle;

    private bool isTrapped;
    private GameObject trappingObject;

	// Use this for initialization
	void Start () {
        isTrapped = false;
        trappingObject = null;
        fishLeft = 5; 
    }

    void Update()
    {
        isTrapped = false;
        trappingObject = null;
    }

    void FixedUpdate()
    {
        if(isTrapped)
        {
            if (trappingObject == null)
                Destroy(gameObject);
            else
            {
                Destroy(trappingObject);
                transform.position = trappingObject.transform.position;
            }
        }  
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Black Fish"))
        {
            isTrapped = true;
            trappingObject = other.gameObject;
            Destroy(other.gameObject);

            for (int counter = 0; counter < 5; counter++)
            {
                SpawnParticle(effectParticle);
            }


            fishLeft--;
            if (fishLeft == 0)
            {
                Application.LoadLevel(0);
                //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
            //Vector3 movement = new Vector3(0, 100, 0);
            //other.rigidbody.AddForce(movement);
        }

    }

    void SpawnParticle(Rigidbody particle)
    {
        Vector3 spawnPosition = Camera.main.transform.position;
        Quaternion spawnRotation = Camera.main.transform.rotation;

        // add random spawn offset for effect particles
        if (particle == effectParticle)
        {
            spawnPosition.x += Random.Range(-0.5f, 0.5f);
            spawnPosition.y += Random.Range(-0.5f, 0.5f);
            spawnPosition.z += Random.Range(-0.5f, 0.5f);
        }


        Rigidbody particleClone = (Rigidbody)Instantiate(particle, spawnPosition, spawnRotation);
    }
}
