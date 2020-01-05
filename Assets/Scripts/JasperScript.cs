using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JasperScript : MonoBehaviour
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
        if (CollisionCounter >= 1)
        {
            this.GetComponent<Animator>().SetBool("IsDead", true);

            CollisionCounter = 0;

            RandomPitch = Random.Range(0.85f, 1.4f);

            BallScript.JasperDeath.pitch = RandomPitch;
            BallScript.JasperDeath.Play();

            Instantiate(BloodParticles, BloodPosition.transform.position, Quaternion.identity);

            StartCoroutine(CountdownToDeath());

            BallScript.TotalPoints -= 4;
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
        }
    }

    IEnumerator CountdownToDeath()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}


