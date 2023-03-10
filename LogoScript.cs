using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScript : MonoBehaviour {

    private Spawn spawn;

    void Start()
    {
        spawn = GameObject.Find("Spawn System").GetComponent<Spawn>();
    }

    public void Logo()
    {
        spawn.GameStarts();
    }
}
