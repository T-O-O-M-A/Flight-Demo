using UnityEngine;
using System.Collections;

public class autopilot : MonoBehaviour {

    public float rychlost, smer, vyska, manevrovaciRychlost, sila, enginePower;
    Rigidbody letadlo;
    float localmanevrovaciRychlost;
	// Use this for initialization
	void Start () {
        letadlo = this.GetComponent<Rigidbody>();
        //letadlo.velocity = new Vector3(0, 0, rychlost);
        localmanevrovaciRychlost = manevrovaciRychlost;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    //vyska
        if (letadlo.position.y < vyska)
        {
            //musim stoupat
            //localmanevrovaciRychlost = -letadlo.position.y + vyska;

            letadlo.AddRelativeTorque(sila * (letadlo.velocity.y - localmanevrovaciRychlost), 0, 0);
        }
        else
        {
            //musim klesat
            //localmanevrovaciRychlost = letadlo.position.y -vyska;
            letadlo.AddRelativeTorque(sila*(letadlo.velocity.y+localmanevrovaciRychlost), 0, 0);

        }
        if (letadlo.velocity.magnitude < rychlost)
        {
            letadlo.AddRelativeForce(0, 0, enginePower);
        }
        Debug.Log(letadlo.velocity.y);
	}
}
