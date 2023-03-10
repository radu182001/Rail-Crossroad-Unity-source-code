using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Train : MonoBehaviour {

	private GameObject cRail;
	public bool onRail = false;

	public float speed;

	public Vector3 dir;
	public bool lansat = false;

	public Vector3 origPos;
	public Vector3 origRot;

	//Culoarea locomotivei
	public Color vrdC;
	public Color abstrC;
	public Color rosuC;
	public Color glbnC;
	public bool vrd = false;
	public bool abstr = false;
	public bool rosu = false;
	public bool glbn = false;
	public GameObject top;
	private int ceCul;
	private bool culAles = false;

	//Spawn
	private Spawn spawn;

	//Busit
	public GameObject partBusit;
	public GameObject locPart;
	public bool inJoc;

	//Puncte
	private Scor scor;
    private Animator circleAnim;
    private Animator cameraAnim;
    private Cerc cerc;

    //Particle culori
    private ParticleSystem cercPart;

    //Audio
    private AudioSource audio;
    private bool playAudio = false;

	void Start () {
		cRail = GameObject.Find ("CenterRail");
		origPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		origRot = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		spawn = GameObject.Find ("Spawn System").GetComponent<Spawn> ();
		scor = GameObject.Find ("ScorText").GetComponent<Scor> ();
        cercPart = GameObject.Find("CercPart").GetComponent<ParticleSystem> ();
        circleAnim = GameObject.Find("Circle").GetComponent<Animator> ();
        cerc = GameObject.Find("Circle").GetComponent<Cerc> ();
        cameraAnim = Camera.main.GetComponent<Animator> ();
        audio = GetComponent<AudioSource>();
    }
	

	void Update () {
        if (lansat && spawn.play && spawn.gata) {
            if (!playAudio)
            {
                audio.Play();
                playAudio = true;
            }
			if (!culAles) {
				ceCul = Random.Range (1, 5);
				culAles = true;
			}
			Alegere ();
			transform.Translate (dir * Time.deltaTime * speed);
		}
		SetareNr ();
		if (onRail)
			transform.SetParent (cRail.transform);
//			transform.rotation = Quaternion.Euler (cRail.transform.eulerAngles.x, cRail.transform.eulerAngles.y, cRail.transform.eulerAngles.z);
		else transform.parent = null;

        //Animator
        circleAnim.SetBool ("Punct", cerc.punct);
	}

	void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "In") {
            onRail = true;
        } else if (other.gameObject.tag == "Out") {
            onRail = false;
            inJoc = true;
        } else if (other.gameObject.tag == "InAfara") {
            Instantiate(partBusit, locPart.transform.position, partBusit.transform.rotation);
            spawn.Over();
            Retragere();
        } else if (other.gameObject.tag == "PeLanga") {
            Retragere();
            //Over();
        }
        else if (other.gameObject.tag == "Train" && inJoc) {
            Instantiate(partBusit, locPart.transform.position, partBusit.transform.rotation);
            spawn.Over();
            Retragere();
        }
        else if (other.gameObject.tag == "Verde" && inJoc) {
            inJoc = false;
            if (vrd)
            {
                scor.youScore();
                cerc.punct = true;
                cameraAnim.SetTrigger("Punct");
                cercPart.startColor = vrdC;
                cercPart.Play();
            }
            else
            {
                spawn.Over();
                Retragere();
            }
        } else if (other.gameObject.tag == "Rosu" && inJoc) {
            inJoc = false;
            if (rosu)
            {
                scor.youScore();
                cerc.punct = true;
                cameraAnim.SetTrigger("Punct");
                cercPart.startColor = rosuC;
                cercPart.Play();
            }
            else
            {
                spawn.Over();
                Retragere();
            }
        }
        else if (other.gameObject.tag == "Albastru" && inJoc) {
            inJoc = false;
            if (abstr)
            {
                scor.youScore();
                cerc.punct = true;
                cameraAnim.SetTrigger("Punct");
                cercPart.startColor = abstrC;
                cercPart.Play();
            }
            else
            {
                spawn.Over();
                Retragere();
            }
        }
        else if (other.gameObject.tag == "Galben" && inJoc) {
            inJoc = false;
            if (glbn)
            {
                scor.youScore();
                cerc.punct = true;
                cameraAnim.SetTrigger("Punct");
                cercPart.startColor = glbnC;
                cercPart.Play();
            }
            else
            {
                spawn.Over();
                Retragere();
            }
        }
	}

	public void Retragere(){
        audio.Stop();
		transform.position = origPos;
		transform.eulerAngles = origRot;
		lansat = false;
		culAles = false;
		vrd = false;
		abstr = false;
		rosu = false;
		glbn = false;
		inJoc = false;
        playAudio = false;
	}

	public void Alegere(){
		if (ceCul == 1) {
			vrd = true;
			top.GetComponent<SpriteRenderer> ().color = vrdC;
		}else if (ceCul == 2) {
			abstr = true;
			top.GetComponent<SpriteRenderer> ().color = abstrC;
		}else if (ceCul == 3) {
			rosu = true;
			top.GetComponent<SpriteRenderer> ().color = rosuC;
		}else if (ceCul == 4) {
			glbn = true;
			top.GetComponent<SpriteRenderer> ().color = glbnC;
		}
	}

	public void SetareNr(){
		if (vrd)
			spawn.nrInterzis = 1;
		else if (abstr)
			spawn.nrInterzis = 2;
		else if (rosu)
			spawn.nrInterzis = 3;
		else if (glbn)
			spawn.nrInterzis = 4;

	}

}
