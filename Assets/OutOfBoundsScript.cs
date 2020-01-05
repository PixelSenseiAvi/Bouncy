using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBoundsScript : MonoBehaviour
{
    public BallController BallScript;
    public CanvasScript CanvasSc;
    public bool isYouLose = false;
    public AudioSource YouLose;
    
    public void Start()
    {
        CanvasSc = GameObject.Find("Canvas").GetComponent<CanvasScript>();
        BallScript = GameObject.Find("Ball").GetComponent<BallController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        BallScript.GameOver = true;
        BallScript.GameoverImage.SetActive(true);

        StartCoroutine(GameOverLevel());

        if (isYouLose == false)
        {
            isYouLose = true;
            YouLose.Play();
        }
    }

    IEnumerator GameOverLevel()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
