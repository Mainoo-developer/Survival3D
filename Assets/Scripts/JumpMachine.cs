using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMachine : MonoBehaviour
{
    public float jumpForce = 0f;


    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
