using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private bool isTouchingTable=false;
    private Vector3 initialLocation;
    private Vector3 initialVelocity;
    private Rigidbody rigidBody;
    public float jumpForce = 5.0f;

    public AudioClip ballRollClip, ballHitClip;
    private AudioSource tableCollisionAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        initialLocation = rigidBody.transform.position;
        initialVelocity = rigidBody.velocity;
        tableCollisionAudioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.R)) {
            rigidBody.transform.position = initialLocation;
            rigidBody.velocity = initialVelocity;
        }
        if(Input.GetKey(KeyCode.Space) && Physics.Raycast(transform.position,Vector3.down,.51f))
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x,jumpForce, rigidBody.velocity.z);
        }
        tableCollisionAudioSource.volume = rigidBody.velocity.magnitude/5.0f;
        
        if(isTouchingTable && rigidBody.velocity!=Vector3.zero && !tableCollisionAudioSource.isPlaying)
        {
            tableCollisionAudioSource.PlayOneShot(ballRollClip);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        //ball hitting table first time, play bounce clip
        if(collision.gameObject.tag=="Table" && isTouchingTable==false)
            {
            isTouchingTable=true;
            tableCollisionAudioSource.PlayOneShot(ballHitClip);
            }
    }
    public void OnCollisionExit(Collision collision)
        {
            isTouchingTable=false;
        }
}
