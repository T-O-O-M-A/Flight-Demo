using UnityEngine;
using System.Collections;

public class naklaneniPostavicky : MonoBehaviour {

    float verticalInput, horizontalInput, sWangleCounter;
    public float angle, frontAngle, sideAngle;
    public Vector3 velocity, lastVelocity;
    Transform mainCamera;
    Rigidbody rb;
    Animator anim;
    public Vector3 move;
    Vector3 lastPosition;
    public float walkSpeed, runSpeed, acceleration, stepDistance, tiltPower, turnRate;
    public Vector3 acc;
    // Use this for initialization
    void Start()
    {
        verticalInput = 0;
        horizontalInput = 0;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        mainCamera = Camera.main.transform;
        lastPosition = Vector3.zero;
        sWangleCounter = 0.0f;
        lastVelocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
    }
    void FixedUpdate()
    {
        CalcMove();
        rb.AddForce(move, ForceMode.Acceleration);
        CalcAngle();
        CalcAcc();
        float accSignZ = 1;
        if (acc.z < 0)
            accSignZ = -1;
        //rb.MoveRotation (rb.rotation * Quaternion.Euler ((Mathf.Max(-1, Mathf.Round (acc.z)) * tiltPower - sideAngle ) * Time.deltaTime, 0.0f, (Mathf.Round (acc.x) * tiltPower - frontAngle) * Time.deltaTime));
        rb.MoveRotation(rb.rotation * Quaternion.Euler((Mathf.Max(-1, Mathf.Round(acc.z)) * tiltPower - sideAngle) * Time.deltaTime, angle * turnRate * Time.deltaTime, (Mathf.Round(acc.x) * tiltPower - frontAngle) * Time.deltaTime));
        //rb.AddTorque (0, angle * 10, 0, ForceMode.Acceleration);
        //rb.AddTorque (-rb.angularVelocity, ForceMode.VelocityChange);
        CalcRunStage();
        anim.SetFloat("speed", Mathf.Sqrt((rb.velocity.x * rb.velocity.x) + (rb.velocity.z * rb.velocity.z)));
    }
    void GetInputs()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    void CalcMove()
    {
        move = Vector3.zero;
        if (verticalInput > 0)
            move += Vector3.Scale(mainCamera.forward, new Vector3(1, 0, 1)).normalized;
        else if (verticalInput < 0)
            move -= Vector3.Scale(mainCamera.forward, new Vector3(1, 0, 1)).normalized;
        if (horizontalInput > 0)
            move += Vector3.Scale(mainCamera.right, new Vector3(1, 0, 1)).normalized;
        else if (horizontalInput < 0)
            move -= Vector3.Scale(mainCamera.right, new Vector3(1, 0, 1)).normalized;
        move = move.normalized * acceleration;
    }
    void CalcRunStage()
    {
        lastPosition = new Vector3(lastPosition.x, 0f, lastPosition.z);
        Vector3 currentPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        float dist = Vector3.Distance(lastPosition, currentPosition);
        float turnAngle = (dist / (2 * Mathf.PI * 1)) * 360f; //PI * 1 should be PI * radius, we just chose radius to be 1
        sWangleCounter += turnAngle;
        if (sWangleCounter > stepDistance)
            sWangleCounter = 0.0f;
        anim.SetFloat("runstage", (sWangleCounter / stepDistance));
        if (anim.GetFloat("runstage") > 1.0f)
            anim.SetFloat("runstage", 0);
        lastPosition = currentPosition;
    }
    void CalcAngle()
    {
        angle = Vector3.Angle(transform.forward, rb.velocity.normalized);
        if (Vector3.Cross(transform.forward, rb.velocity.normalized).y < 0)
            angle = -angle;
        if (move == Vector3.zero)
            angle = 0.0f;
        frontAngle = transform.rotation.eulerAngles.z;
        frontAngle = Mathf.DeltaAngle(0, frontAngle);
        sideAngle = transform.rotation.eulerAngles.x;
        sideAngle = Mathf.DeltaAngle(0, sideAngle);
    }
    void CalcAcc()
    {
        velocity = transform.InverseTransformVector(rb.velocity);
        acc = (velocity - lastVelocity) / Time.fixedDeltaTime;
        lastVelocity = velocity;
        if (Mathf.Abs(acc.x) < 0.01 && Mathf.Abs(acc.z) < 0.01)
            acc = Vector3.zero;
    }
    int Sign(float number)
    {
        if (number < 0.0f)
            return -1;
        else
            return 1;
    }
}