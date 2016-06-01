using UnityEngine;
using System.Collections;

public class bettercontrols : MonoBehaviour {

    public Rigidbody elevator1, elevator2, aleiron1, aleiron2, rudder;
    public float force;
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        elevator1.AddRelativeTorque(-Input.GetAxis("Vertical")*force, 0, 0);
        elevator2.AddRelativeTorque(-Input.GetAxis("Vertical") * force, 0, 0);
        aleiron1.AddRelativeTorque(-Input.GetAxis("Horizontal") * force, 0, 0);
        aleiron2.AddRelativeTorque(Input.GetAxis("Horizontal") * force, 0, 0);
    }
}
