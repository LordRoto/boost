using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotation = 200f;
    Rigidbody rb;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent <Rigidbody>();
        audioSource = GetComponent <AudioSource>();
    }

    // Update is called once per frame


    void Update()
    {
        ProcessJump();
        ProcessRotation();
    }

       void ProcessJump()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
                if(!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
            audioSource.Stop();
            }
        }

       void ProcessRotation()
       {
            if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotation);
        }
           else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotation);
        }


    }
    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
    }


}