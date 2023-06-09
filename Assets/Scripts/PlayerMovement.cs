using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 1000f;
    public float sidewaysForce = 500f;
    public Boolean isControllable;
    public Boolean isJump = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isJump)
        {
            rb.AddForce(Vector3.up * 18, ForceMode.Impulse);
            isJump = false;
        }
        if (isControllable == true)
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if (Input.GetKey("d") && isControllable == true)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a") && isControllable == true)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
