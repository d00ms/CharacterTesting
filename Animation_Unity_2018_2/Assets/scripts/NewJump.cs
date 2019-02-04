using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJump : MonoBehaviour {

    Animator anim;
    bool move = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J)) {

            move = !move;
            anim.SetBool("bool1", move);
        }
	}
}
