using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {
    public GameObject cam;
    public float speed = 2f, sensitivity = 2f, jumpDistance = 5f;
    float moveFB, moveLR, rotX, rotY, verticalVelocity;
    CharacterController charCon;
    Animator astro;

	// Use this for initialization
	void Start () {
        charCon = gameObject.GetComponent<CharacterController>();
        astro = gameObject.GetComponent<Animator>();
    }

	
	// Update is called once per frame
	void Update () {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, verticalVelocity, moveFB);
        transform.Rotate(0, rotX, 0);
        cam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;
        charCon.Move(movement * Time.deltaTime);

        if (charCon.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpDistance;
            }

        }

        if (charCon.velocity.x > 0 || charCon.velocity.z > 0 || charCon.velocity.x < 0 || charCon.velocity.z < 0)
        {
            astro.SetFloat("Speed", 1);
        }   else {
            astro.SetFloat("Speed", 0);
        }
  

    }

    private void FixedUpdate()
    {
        if (!charCon.isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
            astro.SetBool("Jump", true);
        }
        else
        {
            astro.SetBool("Jump", false);
        }

    }

}
