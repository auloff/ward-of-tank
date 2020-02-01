using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float turnSpeed;
    private Rigidbody playerRigidbody;
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 newMovement = transform.forward * vertical * movementSpeed * Time.fixedDeltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + newMovement);

        Quaternion newRotation = Quaternion.Euler(0f, horizontal * turnSpeed, 0f);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * newRotation);
    }
}
