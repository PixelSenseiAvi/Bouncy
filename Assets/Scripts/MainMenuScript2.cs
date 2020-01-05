using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript2 : MonoBehaviour
{
    public AudioSource MouseClick;

    public void BackButton()
    {
        MouseClick.Play();
        StartCoroutine(DelayedBack());
    }

    IEnumerator DelayedBack()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
