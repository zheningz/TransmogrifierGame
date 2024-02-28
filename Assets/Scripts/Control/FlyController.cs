using UnityEngine;

public class FlyController : MonoBehaviour
{
    bool isSliding = false;
    Vector3 flyForce;
    Vector3 slideForce;

    [SerializeField] GameObject upperTrigger;
    [SerializeField] GameObject lowerTrigger;
    [SerializeField] Rigidbody playerRigidbody;
    public Transform userCamera;
    [SerializeField] Hand hand;
    [SerializeField] float flyUp = 20.0f;
    [SerializeField] float slideUp = 10.0f;
    [SerializeField] float flyForward = 0.0f;
    [SerializeField] float slideForward = 0.0f;

    private void Start()
    {
        // camera forward

        flyForce = new Vector3(flyForward, flyUp, 0.0f);
        slideForce = new Vector3(slideForward, slideUp, 0.0f);
    }

    void Update()
    {
        /*if (isSliding)
        {
            // Sliding
            Vector3 force = new Vector3(0.0f, flyForce, 0.0f);
            playerRigidbody.AddForce(force, ForceMode.Acceleration);

            if (hand == Hand.Left)
            {
                OVRInput.SetControllerVibration(1, 0.5f, OVRInput.Controller.LTouch);
            }
            else
            {
                OVRInput.SetControllerVibration(1, 0.5f, OVRInput.Controller.RTouch);
            }
        }
        else
        {
            if (hand == Hand.Left)
            {
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.LTouch);
            }
            else
            {
                OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            }
        }*/
    }

    private void Fly()
    {
        if (hand == Hand.Left)
        {
            OVRInput.SetControllerVibration(1, 0.5f, OVRInput.Controller.LTouch);
        }
        else
        {
            OVRInput.SetControllerVibration(1, 0.5f, OVRInput.Controller.RTouch);
        }
        playerRigidbody.AddForce(flyForce, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision enter");

        if (collider.gameObject.Equals(upperTrigger) || collider.gameObject.Equals(lowerTrigger))
        {
            Fly();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.Equals(upperTrigger) || collider.gameObject.Equals(lowerTrigger))
        {
            Fly();
            // isSliding = false;
        }
    }
}
