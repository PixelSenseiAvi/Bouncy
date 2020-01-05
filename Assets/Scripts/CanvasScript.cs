using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public BallController BallScript;
    public TextMeshProUGUI TextM;
    public TextMeshProUGUI MinutesTimer;
    public TextMeshProUGUI SecondsTimer;

    public int minutes;
    public int seconds;

    private float Timer = 600f;

    public bool GameOver = false;
    public GameObject GameoverImage;

    public GameObject CannotJump;
    public GameObject InSafeMode;
    public AudioSource YouLose;
    public OutOfBoundsScript OOBScript;

    public bool isYouLose = false;

    void Start()
    {
        BallScript = GameObject.Find("Ball").GetComponent<BallController>();
        OOBScript = GameObject.Find("OutofBoundsPlatform").GetComponent<OutOfBoundsScript>();

        StartCoundownTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer<=0)
        {
            Timer = 0;
            GameOver = true;
            GameoverImage.SetActive(true);

            if (isYouLose == false)
            {
                isYouLose = true;
                YouLose.Play();
            }

            StartCoroutine(GameOverLevel());
        }
    }

    void StartCoundownTimer()
    {     
        InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
    }

    void UpdateTimer()
    {
        if (Timer > 0 && BallScript.TotalPoints >= 0 && OOBScript.isYouLose == false)
        {
            Timer -= Time.deltaTime;
        }

        minutes = Mathf.RoundToInt(Mathf.Floor(Timer / 60));
        seconds = Mathf.RoundToInt(Mathf.Floor(Timer % 60));

        MinutesTimer.text = minutes.ToString();
        SecondsTimer.text = seconds.ToString();

        TextM.text = BallScript.TotalPoints.ToString();
    }

    IEnumerator GameOverLevel()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
