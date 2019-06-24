using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorB : MonoBehaviour {

    public GameObject creacion;
    public bool Act;
    public bool created;
    public float largo;
    public float speed;
    public bool limit;

    bool Act2;

    private Animator anim;
    public AudioSource activeSound;
    private bool isPlaying;

    public bool Contador;
    public int intervalo;
    int c;
    void Start()
    {
        anim = GetComponent<Animator>();
        created = false;
        c = 0;
        Act2 = false;
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetBool("Act", Act);
        anim.SetBool("Act2", Act2);

        if (c >= intervalo * 3 / 5)
        {
            Act2 = true;
        }
        else
            Act2 = false;

        if (Contador)
        {
            c = c + 1;
            if (c == intervalo)
            {
                Act = !Act;
                c = 0;
            }

        }
        if (Act && !created)
        {
            created = true;

            GameObject funca;
            //activeSound.Play();
            funca = (GameObject)Instantiate(creacion);
            funca.transform.parent = transform;
            funca.GetComponent<Zgrav>().vert = speed;
            //temp = creacion;
            //temp.transform.position = new Vector2(-32.5f, -3.5f);
            isPlaying = funca.GetComponent<Zgrav>().isPlayingFoil;
            if (isPlaying)
            {
                activeSound.Play();
            }
                
            else if (!isPlaying)
            {
                activeSound.Stop();
            }
            Debug.Log(funca.GetComponent<Zgrav>().isPlayingFoil);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.transform.tag == "Player" || other.transform.tag == "Pushable")
        {
            limit = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "Pushable")
        {
            limit = false;
        }
    }
}
