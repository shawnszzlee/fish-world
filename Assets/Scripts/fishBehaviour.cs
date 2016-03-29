using UnityEngine;
using System.Collections;

public class fishBehaviour : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;

    public float maxAltitudeBeforeDestruction;

    private bool isTrapped;
    private GameObject trappingObject;

    void Start (){
        isTrapped = false;
        trappingObject = null;
    }
    
    void FixedUpdate (){

        if (isTrapped)
        {
            if (trappingObject == null)
                Destroy(gameObject);
            else
            {
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }


}
