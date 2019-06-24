using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamaño : MonoBehaviour {

    Camera camara;
    GameObject myGo;

    float posX, posY;
    int c;
    void Start()
    {
        myGo = GetComponent<GameObject>();
        camara = GetComponentInParent<Camera>();
        c = 0;
        posX = transform.localScale.x;
        posY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {

        posX = camara.orthographicSize / 6;
        posY = camara.orthographicSize / 6;

        transform.localScale = new Vector3(posX, posY, transform.localScale.z);
    }
}
