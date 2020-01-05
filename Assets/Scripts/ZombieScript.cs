using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int CollisionCounter;
    public BallController BallScript;

    public float RandomPitch;

    public ParticleSystem BloodParticles;

    public GameObject BloodPosition;

    void Start()
    {
        BallScript = GameObject.Find("Ball").GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionCounter >= 6)
        {
            RandomPitch = Random.Range(0.85f, 1.4f);

            BallScript.ZombieDeath.pitch = RandomPitch;
            BallScript.ZombieDeath.Play();

            Instantiate(BloodParticles, BloodPosition.transform.position, Quaternion.identity);

            CollisionCounter = 0;

            this.GetComponent<Animator>().SetBool("IsDead", true);
            StartCoroutine(CountdownToDeath());
            BallScript.TotalPoints += 2;
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

            BallScript.JasperDeath.pitch = RandomPitch;
            BallScript.JasperDeath.Play();
        }
    }

    IEnumerator CountdownToDeath()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(this.gameObject);
    }
}
