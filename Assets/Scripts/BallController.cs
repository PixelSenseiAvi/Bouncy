using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody BallRb;

    public GameObject Camera1;
    public GameObject Camera2;

    float jumpTimer = 0.0f;
    public bool hasJumped = false;

    public int TotalPoints;

    public AudioSource CollisionSound;
    public AudioSource CarBeep;
    public AudioSource CarAlarm;
    public AudioSource CycleSound;
    public AudioSource CycleExplosion;
    public AudioSource JasperDeath;
    public AudioSource StreetlightCollision;
    public AudioSource StreetlightDestroy;
    public AudioSource ZombieDeath;

    public AudioSource BallRolling;
    public AudioSource YouLose;

    public float RandomPitch;

    public CanvasScript CanvasSc;

    public bool GameOver = false;
    public GameObject GameoverImage;

    public bool isYouLose = false;

    private void Start()
    {
        BallRb = GetComponent<Rigidbody>();
        CanvasSc = GameObject.Find("Canvas").GetComponent<CanvasScript>();

        StartCoroutine(DisableSecondCamera());
    }

    private void FixedUpdate()
    {
        if (CanvasSc.GameOver == false)
        {
            if (GameOver == false)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                float moveVertical = Input.GetAxis("Vertical");

                Vector3 movingForce = new Vector3(moveHorizontal * 13, 0f, moveVertical * 13);

                movingForce = Camera.main.transform.TransformDirection(movingForce);

                BallRb.AddForce(movingForce);
            }
        }
    }

    private void Update()
    {
        // Placeholder ball rolling sound
        //---------------------------------

        //BallRolling.pitch = BallRb.velocity.magnitude;
        //BallRolling.Play();
        //---------------------------------


        // Jump tracker to limit the jumps allowed
        //---------------------------------
        if (hasJumped == true)
        {
            jumpTimer += Time.deltaTime;
        }

        if(jumpTimer>= 3.0f)
        {
            hasJumped = false;
            jumpTimer = 0.0f;
        }
        //---------------------------------

        if (CanvasSc.GameOver == false)
        {
            if (GameOver == false)
            {
                // Camera Switching
                //---------------------------------
                if (Input.GetKeyDown("1"))
                {
                    Camera1.SetActive(true);
                    Camera2.SetActive(false);
                }
                else
                if (Input.GetKeyDown("2"))
                {
                    Camera1.SetActive(false);
                    Camera2.SetActive(true);
                }
                //---------------------------------


                // Ball Throwing
                //---------------------------------
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (Camera2.activeInHierarchy == true)
                    {
                        if (hasJumped == false)
                        {
                            hasJumped = true;

                            Vector3 ParabolicForce = new Vector3(0, 0, 0);

                            BallRb.AddForce(500 * Camera2.transform.forward);
                            BallRb.AddForce(1400 * Camera2.transform.up);
                        }
                    }
                    else
                    {
                        CanvasSc.CannotJump.SetActive(true);
                        CanvasSc.InSafeMode.SetActive(true);

                        StartCoroutine(DisableJumpText());
                    }
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                }
            }
            //---------------------------------


            // Gameover and transition to main menu
            //---------------------------------
            if (TotalPoints<0)
            {
                GameOver = true;
                GameoverImage.SetActive(true);

                if (isYouLose == false)
                {
                    isYouLose = true;
                    YouLose.Play();
                }

                StartCoroutine(GameOverLevel());
            }
            //---------------------------------
        }
    }

    IEnumerator DisableSecondCamera()
    {
        yield return new WaitForSeconds(0.001f);
        Cursor.visible = false;
        Camera2.SetActive(false);
    }

    IEnumerator DisableJumpText()
    {
        yield return new WaitForSeconds(1.5f);
        CanvasSc.CannotJump.SetActive(false);
        CanvasSc.InSafeMode.SetActive(false);
    }

    IEnumerator GameOverLevel()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void OnCollisionEnter(Collision other)
    {
        RandomPitch = Random.Range(0.6f, 1.4f);

        CollisionSound.pitch = RandomPitch;
        CollisionSound.Play();
    }
}


