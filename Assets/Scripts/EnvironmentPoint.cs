using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPoint : MonoBehaviour
{
    public BallController BControllerScript;

    float ResetTimer;
    bool ResetBool;

    public AudioSource BounceSound;

    void Start()
    {
        BControllerScript = GameObject.Find("Ball").GetComponent<BallController>();
        BounceSound = GameObject.Find("Ball").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(ResetBool == true)
        {
            ResetTimer += Time.deltaTime;
        }
        
        if(ResetTimer>=3.0f)
        {
            ResetBool = false;
            ResetTimer = 0.0f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (ResetBool == false)
            {
                ResetBool = true;
                BControllerScript.TotalPoints -= 1;

                BounceSound.Play();
                print("YOU LOSE A POINT!");
            }
        }
    }
}
