using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

    public Rigidbody player;
    public Camera kamera;
    float force = 50;
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
        kamera.transform.rotation = Quaternion.Lerp(player.rotation, Quaternion.Euler(-Input.mousePosition.y,Input.mousePosition.x,0), Time.deltaTime);
        player.transform.up = player.velocity - rychlost;
    }
}
