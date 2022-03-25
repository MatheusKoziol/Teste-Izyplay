using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{

    Rigidbody rb;
    public float impulseForceUp;
    public float impulseForceForward;
    public float torqueForce;
    public bool lockRotation;
    public float minHeight;

    public bool firstInput;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lockRotation)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ;
        }

        if(transform.position.y < minHeight)
        {
            lockRotation = false;
        }

        if (Input.GetButtonDown("Fire1") || Input.touchCount > 0)
        {
            if (firstInput) 
            { 
                rb.useGravity = true;
                firstInput = false;
            }
            if (transform.position.y > 4) return;
            KnifeImpulse();
        }
    }

    void KnifeImpulse()
    {
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;

        rb.AddForce(Vector3.up * impulseForceUp, ForceMode.Impulse);
        rb.AddForce(Vector3.right * impulseForceForward, ForceMode.Impulse);
        rb.AddTorque(transform.forward * -torqueForce);
    }

    public void BounceImpulse()
    {
        rb.AddForce(Vector3.up * impulseForceUp/2, ForceMode.Impulse);
        rb.AddForce(Vector3.right * -impulseForceForward/2, ForceMode.Impulse);
        rb.AddTorque(transform.forward * torqueForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.layer == 10)
        {
            lockRotation = false;
        }

        if (other.transform.gameObject.layer == 11)
        {
            ScoreManager.Instance.EndGame();
        }
    }

    private void OnEnable()
    {
        firstInput = true;
    }

}
