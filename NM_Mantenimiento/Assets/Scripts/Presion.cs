using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presion : MonoBehaviour {

    public GameObject obj;
    // Use this for initialization

    private SpriteRenderer myS;
    public Sprite nwS;
    public AudioSource activeSound;

    public bool temp2;
    public bool temp3;

    public bool Act;
    Sprite temp;
    void Start()
    {
        myS = GetComponent<SpriteRenderer>();
        temp = myS.sprite;
        if (obj.transform.GetComponent<GeneradorB>() != null)
        {
            temp2 = obj.transform.GetComponent<GeneradorB>().Act;
            temp3 = !temp2;
        }
    }
    void Update()
    {
        //if(Act)
        //{
        //    activeSound.Play();
        //}
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Pushable"/* && other.transform.GetComponent<PlayerController>().grounded*/)
        {
            activeSound.Play();
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Pushable"/* && other.transform.GetComponent<PlayerController>().grounded*/)
        {
            //obj.transform.GetComponent<Rotatorio>().speed = -1;
            if (obj.transform.GetComponent<PlataformaMov>() != null)
                obj.transform.GetComponent<PlataformaMov>().Act = true;
            if (obj.transform.GetComponent<Rotatorio>() != null)
                obj.transform.GetComponent<Rotatorio>().Act = true;
            if (obj.transform.GetComponent<Generador>() != null)
                obj.transform.GetComponent<Generador>().Act = false;
            if (obj.transform.GetComponent<GeneradorB>() != null)
                obj.transform.GetComponent<GeneradorB>().Act = temp3;
            myS.sprite = nwS;
            Act = true;
        }
        
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Pushable")
        {
            if (obj.transform.GetComponent<PlataformaMov>() != null)
                obj.transform.GetComponent<PlataformaMov>().Act = false;
            if (obj.transform.GetComponent<Rotatorio>() != null)
                obj.transform.GetComponent<Rotatorio>().Act = false;
            if (obj.transform.GetComponent<Generador>() != null)
                obj.transform.GetComponent<Generador>().Act = true;
            if (obj.transform.GetComponent<GeneradorB>() != null)
                obj.transform.GetComponent<GeneradorB>().Act = temp2;
            myS.sprite = temp;
            activeSound.Stop();
        }        
        
    }
}
