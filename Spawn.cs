using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {

	public GameObject train;
	public GameObject train1;
	public GameObject train2;
	public GameObject train3;
	public GameObject train4;
	public GameObject train5;
	public GameObject train6;
	public GameObject train7;
	private float contor = 0f;
	public int alegere;
	public int alegereAnterior = 0;
	public float spawnSpeed;

	public int nrInterzis;

	//Play
	public bool play;
	private GameObject pauseB;
	public GameObject resumeB;
	public GameObject menuB;
    public GameObject KULU;
    private GameObject logo;
    public bool start;
    private bool logoStarts = false;
    public bool gata = true;
    public GameObject num;


	//Animators
	private Animator animCortina;
	private Animator animScor;
    private Animator animLogo;
    private Animator animContact;
    private Animator animBest;

    //Over
    public GameObject fade;

    //Audio
    public AudioSource horn;
    public AudioSource select;
    private float timeHorn = 0f;

    //Buttons
    public Color clicked;
    public Color normal;
    public GameObject fb;
    public GameObject insta;

    void Start () {
		animCortina = GameObject.Find ("Cortina").GetComponent<Animator> ();
		animScor = GameObject.Find ("ScorTable").GetComponent<Animator> ();
        animLogo = GameObject.Find("Logo").GetComponent<Animator> ();
        animContact = GameObject.Find("Contact").GetComponent<Animator> ();
        animBest = GameObject.Find("Best").GetComponent<Animator> ();
		pauseB = GameObject.Find ("PauseButton");
        logo = GameObject.Find("Logo");
        start = false;
        pauseB.SetActive(false);
	}

	void Update () {
		if (play && gata) {
			contor += Time.deltaTime;
			if (contor >= spawnSpeed) {
				do {
					alegere = Random.Range (1, 9);
				} while(alegere == alegereAnterior);
				alegereAnterior = alegere;
				Alegere ();
				contor = 0;
			}
		}

        //Play
        if (start)
        {
            logo.SetActive(false);
            if (play)
            {
                pauseB.SetActive(true);
                resumeB.SetActive(false);
                KULU.SetActive(true);
                menuB.SetActive(false);
            }
            else
            {
                pauseB.SetActive(false);
                resumeB.SetActive(true);
                KULU.SetActive(false);
                menuB.SetActive(true);
            }
        }

        //Audio
        timeHorn += Time.deltaTime;
        if (timeHorn >= Random.Range(15f, 30f))
        {
            horn.Play();
            timeHorn = 0f;
        }

		//Animator
		animCortina.SetBool("seJoaca", play);
		animScor.SetBool ("seJoaca", play);
        animLogo.SetBool("logo", logoStarts);
        animContact.SetBool("joc", logoStarts);
        animBest.SetBool("best", logoStarts);
	}

	public void Alegere (){
		if (alegere == 1) {
			if (nrInterzis != 2)
				train.GetComponent<Train> ().lansat = true;
			else {
				do {
					alegere = Random.Range (1, 9);
				} while(alegere == alegereAnterior);
				alegereAnterior = alegere;
				Alegere ();
			}
		} else if (alegere == 2) {
			if (nrInterzis != 2)
				train1.GetComponent<Train> ().lansat = true;
			else {
				do {
					alegere = Random.Range (1, 9);
				} while(alegere == alegereAnterior);
				alegereAnterior = alegere;
				Alegere ();
			}
		} else if (alegere == 3) {
			if (nrInterzis != 3)
				train2.GetComponent<Train> ().lansat = true;
			else {
				do {
					alegere = Random.Range (1, 9);
				} while(alegere == alegereAnterior);
				alegereAnterior = alegere;
				Alegere ();
			}
		} else if (alegere == 4) {
			if (nrInterzis != 3)
				train3.GetComponent<Train> ().lansat = true;
			else {
				do {
					alegere = Random.Range (1, 9);
				} while(alegere == alegereAnterior);
				alegereAnterior = alegere;
				Alegere ();
			}
		} else if (alegere == 5) {
			if(nrInterzis != 1)
				train4.GetComponent<Train> ().lansat = true;
			else {
				do {
					alegere = Random.Range (1, 9);
				} while(alegere == alegereAnterior);
				alegereAnterior = alegere;
				Alegere ();
			}
		}
		else if (alegere == 6) {
			if(nrInterzis != 1)
				train5.GetComponent<Train> ().lansat = true;
			else {
				do {
					alegere = Random.Range (1, 9);
				} while(alegere == alegereAnterior);
				alegereAnterior = alegere;
				Alegere ();
			}
		}
		else if (alegere == 7){
			if(nrInterzis != 4)
				train6.GetComponent<Train> ().lansat = true;
			else {
				do {
					alegere = Random.Range (1, 9);
				} while(alegere == alegereAnterior);
				alegereAnterior = alegere;
				Alegere ();
			}
		}
		else if (alegere == 8){
			if(nrInterzis != 4)
				train7.GetComponent<Train> ().lansat = true;
			else {
				do {
					alegere = Random.Range (1, 9);
				} while(alegere == alegereAnterior);
				alegereAnterior = alegere;
				Alegere ();
			}
		}
	}

	public void Pause(){
		play = false;
        gata = false;
        select.Play();
	}

	public void Play(){
        play = true;
        num.SetActive(true);
        select.Play();
	}

    public void GameStarts() {
        play = true;
        start = true;
    }

    public void Menu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        select.Play();
    }

    public void StartGame() {
        logoStarts = true;
    }

    public void Over()
    {
        fade.SetActive(true);
    }

    public void FBClicked() {
        fb.GetComponent<Image>().color = clicked;
    }

    public void FB() {
        fb.GetComponent<Image>().color = normal;
        Application.OpenURL("https://www.facebook.com/KULUtheOwl/");
    }

    public void InstaClicked()
    {
        insta.GetComponent<Image>().color = clicked;
    }

    public void Insta()
    {
        insta.GetComponent<Image>().color = normal;
        Application.OpenURL("https://www.instagram.com/kulutheowl/");
    }
}
