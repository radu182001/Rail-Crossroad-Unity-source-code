using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scor : MonoBehaviour {

	public int scor = 0;
	private Text textScor;
	public int punctMin;
    public int punctMax;
    public AudioSource audio;

    //HS
    public int bestScore = 0;
    private Text textBest;
    public Color bestC;

	void Start () {
		textScor = GetComponent<Text> ();
        textBest = GameObject.Find("Best").GetComponent<Text>();
        if (PlayerPrefs.HasKey("best"))
            bestScore = PlayerPrefs.GetInt("best",0);
	}

	void Update () {
		textScor.text = "" + scor;
        textBest.text = "Best: " + bestScore;
        if (bestScore < scor)
        {
            textScor.color = bestC;
            textScor.fontStyle = FontStyle.Bold;
            bestScore = scor;
            PlayerPrefs.SetInt("best", bestScore);
        }
	}

	public void youScore(){
		scor += Random.Range(punctMin,punctMax);
        audio.Play();
	}
}
