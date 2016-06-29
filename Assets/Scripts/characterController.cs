using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {

    public Rigidbody player;
    public Camera kamera;
    float force = 50;
    Vector3 rychlost, staraRychlost, zrychleni;
	// Use this for initialization
	void Start () {
        rychlost = Vector3.zero;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        staraRychlost = rychlost;
        rychlost = player.velocity;
        zrychleni = staraRychlost - rychlost;
        //Debug.Log(zrychleni.magnitude/Time.deltaTime);
        zrychleni.z -= 9.81f;
        //player.transform.rotation= Quaternion.Euler(player.velocity - rychlost);
        /*rychlost = player.velocity;
        player.AddRelativeForce(Input.GetAxis("Horizontal")*force,0, Input.GetAxis("Vertical")*force);
        kamera.transform.rotation = Quaternion.Lerp(player.rotation, Quaternion.Euler(-Input.mousePosition.y,Input.mousePosition.x,0), Time.deltaTime);
        player.transform.up = player.velocity - rychlost;*/

        transform.rotation = Quaternion.LookRotation(transform.position,transform.position-zrychleni);
        //player.transform.rotation = Quaternion.FromToRotation(transform.position, transform.position - zrychleni);
     

    }
}
