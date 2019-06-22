using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoTr : MonoBehaviour {

    // Use this for initialization

    private SpriteRenderer myS;
    public Sprite nwS;
    public AudioSource jumpSoundEffect;

    public float potencia;
    bool colision;
    int c,total;
    Sprite temp;
    void Start()
    {
        myS = GetComponent<SpriteRenderer>();
        temp = myS.sprite;
        c = 0;
        total = 20;
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Player" && other.transform.GetComponent<PlayerController>().grounded)
        {
            other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x, 15*potencia);
            jumpSoundEffect.Play();
            myS.sprite = nwS;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            c = 0;
            colision = true;
            //myS.sprite = temp;
        }
    }

    void Update()
    {
        if (colision)
        {
            c++;
            if (c == total)
            {
                myS.sprite = temp;
                c = 0;
                colision = false;
            }
        }
    }
}
