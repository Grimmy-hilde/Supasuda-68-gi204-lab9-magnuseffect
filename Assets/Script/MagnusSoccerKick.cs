using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusSoccerKick : MonoBehaviour
{
    [SerializeField] float kickForce;
    [SerializeField] float spinAmount;
    [SerializeField] float magnusStreangth = 0.5f;

    Rigidbody rb;
    bool isShot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isShot = false ;
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasReleasedThisFrame && !isShot)
        {
            rb.AddTorque(Vector3.up * spinAmount);
            rb.AddForce(Vector3.forward * kickForce, ForceMode.Impulse);
            

            isShot = true ;
        }
    }
    void FixedUpdate()
    {
        if (isShot) return;
        Vector3 velocity = rb.linearVelocity;
        Vector3 spin = rb.angularVelocity;

        Vector3 magunsForce = magnusStreangth * Vector3.Cross(spin, velocity);
        rb.AddForce(magunsForce);
    }
}
