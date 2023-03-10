using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public void GataPunct()
    {
        Camera.main.GetComponent<Animator>().ResetTrigger("Punct");
    }
}
