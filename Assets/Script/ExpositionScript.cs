using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpositionScript : MonoBehaviour {


	public float timer;
	GameObject panel1;
	GameObject panel2;
	// Use this for initialization
	void Start () {
		timer = 0f;
		panel1 = GameObject.Find ("Panel1");
		panel2 = GameObject.Find ("Panel2");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 5f && 10f > timer) {
			panel2.SetActive (true);
			panel1.SetActive (false);

		} else if(timer > 10f){
			panel2.SetActive (false);
		}
	}
}
