using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public int CollisionCounter;
    public BallController BallScript;
    public float RandomPitch;

    public ParticleSystem ExplosionParticles;

    void Start()
    {
        BallScript = GameObject.Find("Ball").GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CollisionCounter >= 3)
        {

            RandomPitch = Random.Range(0.85f, 1.4f);

            BallScript.CarAlarm.pitch = RandomPitch;
            BallScript.CarAlarm.Play();

            BallScript.CycleExplosion.pitch = RandomPitch;
            BallScript.CycleExplosion.Play();

            Instantiate(ExplosionParticles, this.transform.position, Quaternion.identity);

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

            RandomPitch = Random.Range(0.85f, 1.4f);

            BallScript.CarBeep.pitch = RandomPitch;
            BallScript.CarBeep.Play();
        }
    }
}
