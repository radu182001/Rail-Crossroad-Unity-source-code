using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Num : MonoBehaviour {

    private Text textNum;
    private int num = 3;
    private float contor = 0f;

    private Spawn spawn;

	void Start () {
        textNum = GetComponent<Text>();
        spawn = GameObject.Find("Spawn System").GetComponent<Spawn>();
	}
	
	void Update () {
        textNum.text = num.ToString();
        contor += Time.fixedDeltaTime;
        if (contor >= 1f && num > 1)
        {
            num--;
            contor = 0f;
        }
        else if (contor >= 1f && num == 1)
        {
            spawn.gata = true;
            reset();
            gameObject.SetActive(false);
        }
            
	}

    void reset() {
        contor = 0f;
        num = 3;
    }
}
