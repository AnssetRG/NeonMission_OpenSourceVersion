using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour {

    public GameObject creacion;
    public bool Act;
    public bool created;
    public float largo;
    public bool siempre;

    public bool padre;

    bool Act2;

    private Animator anim;

    public bool Contador;
    public int intervalo;
    int c;
	void Start () {
        anim = GetComponent<Animator>();
        created = false;
        c = 0;
        Act2 = false;
        if (transform.parent != null)
        {
            padre = true;
        }
        else
        {
            padre = false;
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        anim.SetBool("Act", Act);
        anim.SetBool("Act2", Act2);
        if (Time.timeScale != 0f)
        {
            if (c >= intervalo * 2 / 4)
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

                funca = (GameObject)Instantiate(creacion);
                funca.transform.parent = transform;
                //temp = creacion;
                //temp.transform.position = new Vector2(-32.5f, -3.5f);
            }
        }
    }
}
