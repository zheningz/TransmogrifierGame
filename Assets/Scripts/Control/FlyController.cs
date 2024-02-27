using UnityEngine;

public class FlyController : MonoBehaviour
{
    bool isSliding = false;

    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] Hand hand;
    [SerializeField] float flyForce = 200.0f;
    [SerializeField] float slideForce = 50.0f;

    void Update()
    {
        if (isSliding)
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
        }
    }

    private void Fly()
    {
        Vector3 force = new Vector3(0.0f, flyForce, 0.0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Fly");
            playerRigidbody.AddForce(force, ForceMode.Acceleration);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Upper" || collision.collider.gameObject.name == "Lower")
        {
            Vector3 force = new Vector3(0.0f, flyForce, 0.0f);
            playerRigidbody.AddForce(force, ForceMode.Acceleration);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.name == "Upper")
        {
            isSliding = false;
        }
    }
}
