using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txt : MonoBehaviour {

    public gamemanager GM;
    public Text text_;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        text_.text =(GM.magazine_num.ToString() + "/" + GM.magazine_num_max.ToString());

	}
}
