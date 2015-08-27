using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

[SerializableAttribute]
public class TextScript : MonoBehaviour {
	public Text Display;

	// Use this for initialization
	void Start () {
		Display = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		Display.text = "HR: " + HRM.GetHeartRate();
	}
}
