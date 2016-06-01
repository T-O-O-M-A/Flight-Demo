using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

    public Rigidbody player;
    public Camera kamera;
    Vector3 rychlost;
	// Use this for initialization
	void Start () {
        rychlost = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //player.transform.rotation= Quaternion.Euler(player.velocity - rychlost);
        rychlost = player.velocity;
        player.AddRelativeForce(Input.GetAxis("Horizontal")*force,0, Input.GetAxis("Vertical")*force);
    }
}
