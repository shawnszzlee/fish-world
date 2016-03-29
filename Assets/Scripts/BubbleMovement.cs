using UnityEngine;
using System.Collections;

public class BubbleMovement : MonoBehaviour {

    private Rigidbody rigidBody;
    public float verticalAccelerationFast;
    public float verticalAccelerationSlow;
    public float maxAltitudeBeforeDestruction;
    public float randomForceRange;
    public float maxAltitudeBeforeForceChange;

    private Vector3 previousRandomForce;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        previousRandomForce.Set(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.y > maxAltitudeBeforeDestruction)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate ()
    {
        float appliedVerticalAcceleration = (transform.position.y > maxAltitudeBeforeForceChange) ?
            verticalAccelerationFast : verticalAccelerationSlow;

        Vector3 movement = new Vector3(0, appliedVerticalAcceleration, 0);
        rigidBody.AddForce(movement);

        // random bubble jitter motion
        // subtract previous random force
        previousRandomForce.x = -previousRandomForce.x;
        previousRandomForce.y = -previousRandomForce.y;
        previousRandomForce.z = -previousRandomForce.z;
        rigidBody.AddForce(previousRandomForce);

        // add new random force
        Vector3 newRandomForce = new Vector3(Random.Range(-randomForceRange, randomForceRange),
            Random.Range(-randomForceRange, randomForceRange), Random.Range(-randomForceRange, randomForceRange));

        previousRandomForce = newRandomForce;
    }

}
