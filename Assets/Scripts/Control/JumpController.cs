using System.Threading;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    Rigidbody rigidBody;
    Vector3 previousPosition;
    bool isColliding;
    bool isJumping; 

    public GameObject frog;
    Animator anim;

    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] Transform target;
    [SerializeField] Hand hand;
    [SerializeField] float frequency = 50f;
    [SerializeField] float damping = 1f;
    [SerializeField] float rotationFrequency = 100f;
    [SerializeField] float rotationDamping = 0.9f;

    [SerializeField] float climbForce = 1000f;

    void Start()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.maxAngularVelocity = float.PositiveInfinity;
        previousPosition = transform.position;

        // animation
        anim = frog.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //anim.SetTrigger("Jump");
            anim.SetTrigger("Tongue");
        }


    }

    void FixedUpdate()
    {
        PIDMovement();
        PIDRotation();
        if (isColliding)
            HookesLaw();
         
        if (isJumping)
        {
            anim.SetTrigger("Jump");
            isJumping = false;
        }
    }

    void PIDMovement()
    {
        float kp = (6f * frequency) * (6f * frequency) * 0.25f;
        float kd = 4.5f * frequency * damping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Vector3 force = (target.position -  transform.position) * ksg + (playerRigidBody.velocity - rigidBody.velocity) * kdg;
        rigidBody.AddForce(force, ForceMode.Acceleration);
    }

    void PIDRotation()
    {
        float kp = (6f * rotationFrequency) * (6f * rotationFrequency) * 0.25f;
        float kd = 4.5f * rotationFrequency * rotationDamping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Quaternion q = target.rotation * Quaternion.Inverse(transform.rotation);
        if (q.w < 0)
        {
            q.x = -q.x;
            q.y = -q.y;
            q.z = -q.z;
            q.w = -q.w;
        }
        q.ToAngleAxis(out float angle, out Vector3 axis);
        axis.Normalize();
        axis *= Mathf.Deg2Rad;
        Vector3 torque = ksg * axis * angle + -rigidBody.angularVelocity * kdg;
        rigidBody.AddTorque(torque, ForceMode.Acceleration);
    }

    void HookesLaw()
    {
        Vector3 displacementFromResting = transform.position - target.position;
        Vector3 force = displacementFromResting * climbForce;

        if (hand == Hand.Left)
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
        } 
        else
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
        }

        playerRigidBody.AddForce(force, ForceMode.Acceleration);

        if (playerRigidBody.velocity.y > 1.0f)
        {
            isJumping = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;

        if (hand == Hand.Left)
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
        }
        else
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        }
    }
}
