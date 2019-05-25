using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour {

    public int scoreCount = 0;
    TextMeshProUGUI score;
    public TextMeshProUGUI endScore;
	// Use this for initialization
	public void Start () {
        score = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	public void Update () {
        endScore.text = "" + scoreCount;
        score.text = "" + scoreCount;
        PlayerPrefs.SetInt("endscore", scoreCount);
		
	}
}
