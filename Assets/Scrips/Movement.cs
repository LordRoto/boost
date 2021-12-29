using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //PARAMTERS - for tuning, typically set in the editor
    //CACHE - e.g. references for readability or speed
    //STATE - private instance (member) variables



    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotation = 200f;
    [SerializeField] AudioClip whoosh;
    [SerializeField] ParticleSystem mainthrustParticles;
        [SerializeField] ParticleSystem leftthrustParticles;
        [SerializeField] ParticleSystem rightthrustParticles;

    [SerializeField] AudioClip BGM;

    Rigidbody rb;
    AudioSource audioSource;

    bool isAlive;


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
                StartThrusting();
                }
            else
                {
                audioSource.Stop();
                mainthrustParticles.Stop();
                }
        }

    

    void ProcessRotation()
       {
            //Goin Right
            if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotation);
            if (!leftthrustParticles.isPlaying)
                {
                leftthrustParticles.Play();
                }
            
        }
           //Goin Left 
           else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotation);
            if (!rightthrustParticles.isPlaying)
                {
                rightthrustParticles.Play();
                }
        }
        else //Please Stop
        {
            rightthrustParticles.Stop();
            leftthrustParticles.Stop();
        }

    }
    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationThisFrame);
    }
private void StartThrusting()
    {
        Debug.Log("Thrusting");
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(whoosh);
        }
        if (!mainthrustParticles.isPlaying)
        {
            mainthrustParticles.Play();
        }
    }
}