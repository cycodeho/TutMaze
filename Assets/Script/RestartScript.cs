using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour {

	public bool isRestart = false;
	// Use this for initialization
	void Start () {
		Button b = this.GetComponent<Button> ();
		b.onClick.AddListener(delegate {
			jumpScense();
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void jumpScense(){
		SceneManager.LoadScene("Start");
	}

}
