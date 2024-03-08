using System;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    Rigidbody rigidBody;

    [SerializeField] Rigidbody playerRigidBody;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform target;
    [SerializeField] Hand hand;
    [SerializeField] float frequency = 10f;
    [SerializeField] float damping = 1f;
    [SerializeField] float rotationFrequency = 100f;
    [SerializeField] float rotationDamping = 0.9f;

    [SerializeField] float flyThreshold = 3.0f;
    [SerializeField] float flyForce = 5f;
    [SerializeField] float glideForce = 3f;

    void Start()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;

        rigidBody = GetComponent<Rigidbody>();
        rigidBody.maxAngularVelocity = float.PositiveInfinity;
    }

    void FixedUpdate()
    {
        PIDMovement();
        PIDRotation();

        Vector3 velocityOffset = playerRigidBody.velocity - rigidBody.velocity;
        // Debug.Log("Hand velocity: " + rigidBody.velocity);
        Debug.Log("Body velocity: " + playerRigidBody.velocity);

        if (velocityOffset.y > flyThreshold)
        {
            Debug.Log("Offset" + velocityOffset);
            Fly(velocityOffset);
        }

        // if (playerRigidBody.velocity.y > 3)
        if (IsWingWide())
        {
            Glide();
        }
    }

    void PIDMovement()
    {
        float kp = (6f * frequency) * (6f * frequency) * 0.25f;
        float kd = 4.5f * frequency * damping;
        float g = 1 / (1 + kd * Time.fixedDeltaTime + kp * Time.fixedDeltaTime * Time.fixedDeltaTime);
        float ksg = kp * g;
        float kdg = (kd + kp * Time.fixedDeltaTime) * g;
        Vector3 force = (target.position - transform.position) * ksg + (playerRigidBody.velocity - rigidBody.velocity) * kdg;
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

    void Fly(Vector3 speedOffset)
    {
        Vector3 force = speedOffset * flyForce;
        Debug.Log("Force: " + -speedOffset * flyForce);

/*        if (hand == Hand.Left)
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
        }
        else
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
        }*/

        playerRigidBody.AddForce(force, ForceMode.Acceleration);
    }

    void Glide()
    {
        // calculate direction & glide
        Vector3 force = new Vector3(0, glideForce,0);
        playerRigidBody.AddForce(force, ForceMode.Acceleration);
    }

    bool IsWingWide()
    {
        if (Math.Abs(playerTransform.position.z - transform.position.z) > 0.5f)
            return true;
        return false;
    }
}
