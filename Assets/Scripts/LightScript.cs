using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public int CollisionCounter;
    public BallController BallScript;
    public float RandomPitch;

    public ParticleSystem LightParticles;

    public GameObject LightPosition;

    void Start()
    {
        BallScript = GameObject.Find("Ball").GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionCounter >= 1)
        {

            RandomPitch = Random.Range(0.6f, 1.4f);

            BallScript.StreetlightDestroy.pitch = RandomPitch;
            BallScript.StreetlightDestroy.Play();

            Instantiate(LightParticles, LightPosition.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
            BallScript.TotalPoints += 1;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (BallScript.hasJumped == true)
            {
                CollisionCounter += 2;
            }
            else
            {
                CollisionCounter += 1;
            }

            RandomPitch = Random.Range(0.6f, 1.4f);

            BallScript.StreetlightDestroy.pitch = RandomPitch;
            BallScript.StreetlightDestroy.Play();
        }
    }
}
