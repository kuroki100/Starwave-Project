using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class LandmineController : MonoBehaviour
{
    public GameObject skillQ;
    public int landMineCount = 5;
    public float qCooldown = 5;
    private float nextQ = 0;

    public Image qUI;

    void Update()
    {
        SkillQ();

        if (landMineCount == 0)
        {
            qUI.fillAmount += 1 / qCooldown * Time.deltaTime;
        }
        else if (landMineCount > 0)
        {
            qUI.fillAmount -= 1 / qCooldown * Time.deltaTime;
        }
    }

    void SkillQLayout()
    {
        Instantiate(skillQ, transform.position, transform.rotation);
    }

    void SkillQ()
    {
        

        if (Time.time > nextQ)
        {
            if (landMineCount > 0 && Input.GetKeyDown(KeyCode.Q))
            {
                landMineCount -= 1;
                SkillQLayout();
                print(" you have " + landMineCount + " cannon crystals of 5.");

            }
            else if (landMineCount == 0)
            {
                qUI.fillAmount += 1 / qCooldown * Time.deltaTime;
                nextQ = Time.time + qCooldown;
                
                print(" Cooldown has started.");

                landMineCount = 5;
                print("you have regenerated your cannon you now have: " + landMineCount + ".");
            }
        }
    }
}

