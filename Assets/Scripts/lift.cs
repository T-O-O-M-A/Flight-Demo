using UnityEngine;
using System.Collections;

public class lift : MonoBehaviour {

    public float coeficient;
    Rigidbody kridlo;
    Transform tkridlo;
    public bool log;
    float vRychlost, plocha, vztlak;

	// Use this for initialization
	void Start () {
        kridlo = this.GetComponent<Rigidbody>();
        tkridlo = this.GetComponent<Transform>();
        plocha = this.GetComponent<Transform>().lossyScale.x * this.GetComponent<Transform>().lossyScale.z;
    }

    // Update is called once per frame
    void FixedUpdate () {
        vRychlost = transform.InverseTransformDirection(kridlo.velocity).y;
        vztlak = /*-Mathf.Sign(vRychlost) * vRychlost * */-vRychlost * Mathf.Abs(tkridlo.lossyScale.x * tkridlo.lossyScale.z) * coeficient;
        kridlo.AddRelativeForce(0,vztlak,0);
        if (log) { Debug.Log(vztlak); }
    }
}
