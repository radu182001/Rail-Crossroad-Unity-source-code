using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRail : MonoBehaviour {

	public float angle;
	public float c;
	public bool rotate = false;
	public float masurator;
	private bool ok = true;

    private AudioSource audio;


	void Start () {
        audio = GetComponent<AudioSource>();
	}
	

	void Update () {
		if (rotate) {
			if (ok) {
				masurator = 0f;
				ok = false;
			}
			if (masurator < angle) {
				transform.Rotate (0f, 0f, -c);
				masurator += c;			
			} else {
				rotate = false;
				ok = true;
			}
		} 

	}


	public void Rotate(){
		rotate = true;
        audio.Play();
	}

}
