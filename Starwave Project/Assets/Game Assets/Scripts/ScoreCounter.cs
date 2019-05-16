using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour {

    public int scoreCount = 0;
    TextMeshProUGUI score;

	// Use this for initialization
	public void Start () {
        score = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	public void Update () {

        score.text = "" + scoreCount;
		
	}
}
