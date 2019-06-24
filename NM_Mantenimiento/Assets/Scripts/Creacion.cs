using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creacion : MonoBehaviour {

    // Use this for initialization
    public GameObject creacion;
    public GameObject prefaCrea;
    public AudioSource activeSound;

    private SpriteRenderer myS;
    public Sprite nwS;


    public bool Act;
    public bool creado;

    Vector2 pos;

    Sprite temp;
    void Start()
    {
        //creacion = GetComponentInChildren<GameObject>();
        myS = GetComponent<SpriteRenderer>();
        temp = myS.sprite;
        pos = creacion.transform.position;
    }
    void Update()
    {
        if(Act)
        {
            GameObject funca;
            funca = (GameObject)Instantiate(prefaCrea);
            funca.transform.position = pos;
            funca.transform.parent = transform;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Movible"/* && other.transform.GetComponent<PlayerController>().grounded*/)
        {
            Act = true;
            myS.sprite = nwS;
            activeSound.Stop();
            activeSound.Play();
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Pushable")
        {
            Act = false;
            creado = false;
            myS.sprite = temp;
        }

    }
}
