using UnityEngine;
using System.Collections;

public class lift : MonoBehaviour {

    public float coeficient, turbulenceFactor;
    Rigidbody kridlo;
    Transform tkridlo;
    public bool log;
    float vRychlost, plocha, vztlak, turbulence;

	// Use this for initialization
	void Start () {
        kridlo = this.GetComponent<Rigidbody>();
        tkridlo = this.GetComponent<Transform>();
        plocha = this.GetComponent<Transform>().lossyScale.x * this.GetComponent<Transform>().lossyScale.z;
        turbulence = 0;
    }

    // Update is called once per frame
    void FixedUpdate () {
        vRychlost = transform.InverseTransformDirection(kridlo.velocity).y;
        vztlak = /*-Mathf.Sign(vRychlost) * vRychlost * */-vRychlost * Mathf.Abs(tkridlo.lossyScale.x * tkridlo.lossyScale.z) * coeficient;
        //turbulence = Mathf.Lerp(turbulence, Random.Range(0, turbulenceFactor),Time.deltaTime);
        //vztlak *= turbulence;
        //vztlak *= vztlak*Mathf.Sign(vztlak);
        kridlo.AddRelativeForce(0,vztlak,0);
        if (log) { Debug.Log(turbulence); }
    }
}
