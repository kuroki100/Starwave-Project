using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour {

    Animator playAnim;


	// Use this for initialization
	void Start () {
        playAnim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKey(KeyCode.D))
        {
            playAnim.SetBool("DisActive", true);
            playAnim.SetBool("AisActive", false);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            playAnim.SetBool("DisActive", false);
            playAnim.SetBool("AisActive", true);
        }
        else
        {
            playAnim.SetBool("DisActive", false);
            playAnim.SetBool("AisActive", false);
        }
    }
}
