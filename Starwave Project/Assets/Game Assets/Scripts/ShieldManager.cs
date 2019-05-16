using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldManager : MonoBehaviour {

    public Image canvasBar;

    public ScoreCounter findScore;

    public float damageIntake;

    private void Update()
    {
        if (canvasBar.fillAmount <= 0)
        {

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
