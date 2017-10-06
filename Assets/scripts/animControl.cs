using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class animControl : MonoBehaviour {

    public Animator anim;
    public float movementSpeed = 0.01f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;
    public Rigidbody rigidbody;
    public AudioClip swordSound;
    private AudioSource source;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.Play("standing_jump");
            //rigidbody.position += Vector3.up * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            anim.Play("standing_run_forward" , -1, 1f);
            //anim.Play("standing_idle");
            rigidbody.position += Vector3.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            anim.Play("standing_idle");
            anim.Play("standing_run_back", -1, 1f);
            //anim.Play("standing_idle");
            rigidbody.position -= Vector3.right * Time.deltaTime * movementSpeed;
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            anim.Play("standing_melee_attack_360_high", -1, 0f);
            source.PlayOneShot(swordSound, 1F);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            anim.Play("standing_melee_attack_horizontal", -1, 0f);
        }
    }
}
