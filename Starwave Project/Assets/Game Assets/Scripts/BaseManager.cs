using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseManager : MonoBehaviour {

    public Image canvasBar;

    public float damageIntake;

    public GameObject lose;
    public GameObject player;

    public ScoreCounter findScore;

    private void Update()
    {
        if (canvasBar.fillAmount <= 0)
        {
            lose.SetActive(true);
            player.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            findScore.scoreCount -= 20;

            canvasBar.fillAmount -= damageIntake;
        }

    }
}
