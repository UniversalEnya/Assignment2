using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotSpeed = 120f;

    public void Update()
    {
        movementInput();
    }

    void movementInput()
    {
        transform.Translate(0, 0, Input.GetAxis("Jump") * Time.deltaTime * speed);

        transform.Rotate(Input.GetAxis("Vertical") * (-1) * Time.deltaTime * rotSpeed, 0, 0);
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed, 0);
    }
}
