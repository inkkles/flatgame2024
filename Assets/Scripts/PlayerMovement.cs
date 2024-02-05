using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2f;
    public Vector3 scale;
    public bool isSoundPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int horizontalMove = 0;

       
        if (Input.GetKey(KeyCode.A))
        {
            horizontalMove -= 1;
            scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalMove += 1;
            scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
        }

        //if moving
        if (horizontalMove != 0)
        {
            //if sound isn't already playing, then start it
            if (!isSoundPlaying)
            {
                GetComponent<AudioSource>().Play();
                isSoundPlaying = true;
            }
        }
        else 
        {
            isSoundPlaying = false;
            GetComponent<AudioSource>().Stop();
        }
        this.transform.position += new Vector3(horizontalMove * playerSpeed * Time.deltaTime, 0, 0);

        
    }
}
