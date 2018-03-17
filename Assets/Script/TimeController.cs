using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour {


    public Text text_box;
    static float timer = 0.0f;

    // Use this for initialization
    void Start () {
        text_box = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        text_box.text = timer.ToString("0.00");
	}
}
