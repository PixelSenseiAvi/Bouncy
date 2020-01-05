using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public AudioSource MouseClick;

    private void Start()
    {
        Cursor.visible = true;
    }

    public void StartButton()
    {
        MouseClick.Play();
        StartCoroutine(DelayedStart());
    }

    public void HelpButton()
    {
        MouseClick.Play();
        StartCoroutine(DelayedHelp());
    }

    public void ExitButton()
    {
        MouseClick.Play();
        StartCoroutine(DelayedExit());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("RiseUpProject", LoadSceneMode.Single);
    }

    IEnumerator DelayedHelp()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("HelpScene", LoadSceneMode.Single);
    }

    IEnumerator DelayedExit()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
}
