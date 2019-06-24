using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionM : MonoBehaviour {

    // Use this for initialization
    public GameObject creacion;
    public GameObject prefaCrea;
        
    //private SpriteRenderer myS;
    //public Sprite nwS;

    public float finish;
    float c;
    public bool Act;
    public bool creado;
    public bool random;

    float temp2;
    Vector2 pos;
    Transform final;

    Sprite temp;
    void Start()
    {
        //creacion = GetComponentInChildren<GameObject>();
        //myS = GetComponent<SpriteRenderer>();
        //temp = myS.sprite;
        pos = creacion.transform.position;
        final = creacion.GetComponent<Destruccion>().target;
        temp2 = finish;
        c = 0;
    }
    void Update()
    {
        c++;
        if(c>=finish)
        {
            Act = true;
        }
        if (Act)
        {
            if (random)
            {
                finish = temp2 + 100*Random.value;
            }
            c = 0;
            Act = false;
            GameObject funca;
            funca = (GameObject)Instantiate(prefaCrea);
            funca.transform.position = pos;
            funca.transform.GetComponent<Destruccion>().target = final;
            funca.transform.parent = transform;
        }

        
        
    }
}
