using UnityEngine;
using System.Collections;

public class ovladani : MonoBehaviour {

    Rigidbody letadlo;
    public float force = 20, speed = 75, enginePower;
    public Camera kamera;
	// Use this for initialization
	void Start () {
        letadlo=this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /*Input.GetAxis("Horizontal");
        Input.GetAxis("Vertical");*/
        letadlo.AddRelativeTorque(Input.GetAxis("Vertical") * force*2, 0, -Input.GetAxis("Horizontal") * force);
        if (letadlo.velocity.magnitude < speed) { letadlo.AddRelativeForce(0, 0, enginePower); }
        //Debug.Log(letadlo.velocity.magnitude);

        kamera.transform.position = Vector3.Lerp(kamera.transform.position, letadlo.position, Time.deltaTime);
        kamera.transform.rotation = Quaternion.Lerp(kamera.transform.rotation,Quaternion.FromToRotation(kamera.transform.position, letadlo.position),Time.deltaTime*9);
        //kamera.transform.rotation= Quaternion.Euler(0, kamera.transform.rotation.eulerAngles.y, kamera.transform.rotation.eulerAngles.z);
        kamera.transform.LookAt(Vector3.Lerp(kamera.transform.position, letadlo.position, Time.deltaTime*8.9f));
    }
}
