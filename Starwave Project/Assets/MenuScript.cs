using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Animator menuAnim;

    public Animator cameraAnim;

    public GameObject score, config;

    public ParticleSystem motor1, motor2;

    public void Start()
    {
        menuAnim.SetBool("ScoreboardClicked", false);

        menuAnim.SetBool("OptionsClicked", false);

        cameraAnim.SetBool("PlayClicked", false);
    }

    public void PlayGame()
    {
        cameraAnim.SetBool("PlayClicked", true);
        score.SetActive(false);
        config.SetActive(false);
        motor1.Stop();
        motor2.Stop();
        cameraAnim.Play("PlayAnim");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoToScoreboard()
    {
        menuAnim.SetBool("ScoreboardClicked", true);
        menuAnim.Play("MenuScoreboard");
    }

    public void ReturnToMenuFromScoreboard()
    {
        menuAnim.SetBool("ScoreboardClicked", false);
        menuAnim.Play("ScoreboardToMainMenu");

    }

    public void GoToOptions()
    {
        menuAnim.SetBool("OptionsClicked", true);
        menuAnim.Play("MainMenuToOptions");

    }

    public void ReturnToMenuFromOptions()
    {
        menuAnim.SetBool("OptionsClicked", false);
        menuAnim.Play("OptionsToMainMenu");

    }
}
