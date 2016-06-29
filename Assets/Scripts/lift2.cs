using UnityEngine;
using System.Collections;

public class lift2 : MonoBehaviour {

    float uhelNabehu, sila;
    public float plocha, koeficient;
    Rigidbody kridlo;

	// Use this for initialization
	void Start () {
        kridlo = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //uhelNabehu = Mathf.Atan(transform.InverseTransformDirection(kridlo.velocity).y / Mathf.Sqrt(transform.InverseTransformDirection(kridlo.velocity).x * transform.InverseTransformDirection(kridlo.velocity).x + transform.InverseTransformDirection(kridlo.velocity).z * transform.InverseTransformDirection(kridlo.velocity).z));
        //CoL *= Mathf.Sign(transform.InverseTransformDirection(kridlo.velocity).z);
        uhelNabehu = -Mathf.Atan(transform.InverseTransformDirection(kridlo.velocity).y / transform.InverseTransformDirection(kridlo.velocity).z);
        uhelNabehu *= Mathf.Rad2Deg;
        sila= vztlak(uhelNabehu);
        Debug.Log(sila);
        kridlo.AddRelativeForce(0, sila, 0);
    }

    float vztlak(float AoA) {
        float maxAngle = 30, rychlostOdtrzeni = 3;
        if (Mathf.Abs(AoA) < maxAngle)
        {
            return AoA * koeficient * plocha;
        }else
        {
            float x = AoA - rychlostOdtrzeni*Mathf.Abs(maxAngle - Mathf.Abs(AoA))*Mathf.Sign(AoA);
            if (Mathf.Sign(x)!=Mathf.Sign(AoA)) { x = 0; }
            return x*koeficient*plocha;
        }
    }
}
