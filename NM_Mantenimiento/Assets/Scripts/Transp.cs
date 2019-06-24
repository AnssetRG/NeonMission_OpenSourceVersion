using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transp : MonoBehaviour {

    public BoxCollider2D myB;
    public float largo;

    float x;
    float pos;
	void Start () {
        myB = GetComponent<BoxCollider2D>();
        largo = GetComponentInParent<Generador>().largo;
        x = transform.localScale.x;
        transform.localScale = new Vector2(0, 0);
        myB.transform.position = new Vector2(GetComponentInParent<Generador>().transform.position.x, 0);
        pos = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        
        if (GetComponentInParent<Generador>().transform.rotation.w == 1f)
        {
            pos = GetComponentInParent<Generador>().transform.position.y - 0.5f;
        }
        if (GetComponentInParent<Generador>().transform.rotation.w == 0f)
        {
            pos = GetComponentInParent<Generador>().transform.position.y + 0.5f;
        }
        if (GetComponentInParent<Generador>().transform.rotation.w >= 0.6f && GetComponentInParent<Generador>().transform.rotation.w <= 0.8f) 
        {
            pos = GetComponentInParent<Generador>().transform.position.x + 0.5f;
        }
        if (GetComponentInParent<Generador>().transform.rotation.w <= -0.6f && GetComponentInParent<Generador>().transform.rotation.w >= -0.8f)
        {
            pos = GetComponentInParent<Generador>().transform.position.x - 0.5f;
        }

        for (int i = 0; i < largo; i++)
        {
            if (GetComponentInParent<Generador>().transform.rotation.w == 1f)
            {
                myB.transform.localScale = new Vector2(1, i + 1);

                myB.transform.position = new Vector2(GetComponentInParent<Generador>().transform.position.x, pos = pos - 0.5f);
            }
            if (GetComponentInParent<Generador>().transform.rotation.w == 0f)
            {
                myB.transform.localScale = new Vector2(1, i + 1);
                myB.transform.position = new Vector2(GetComponentInParent<Generador>().transform.position.x, pos = pos + 0.5f);
            }
            if (GetComponentInParent<Generador>().transform.rotation.w >= 0.6f && GetComponentInParent<Generador>().transform.rotation.w <= 0.8f)
            {
                myB.transform.localScale = new Vector2(i + 1, x);
                myB.transform.position = new Vector2(pos = pos + 0.5f, GetComponentInParent<Generador>().transform.position.y);
            }
            if (GetComponentInParent<Generador>().transform.rotation.w <= -0.6f && GetComponentInParent<Generador>().transform.rotation.w >= -0.8f)
            {
                myB.transform.localScale = new Vector2(i + 1, x);
                myB.transform.position = new Vector2(pos = pos - 0.5f, GetComponentInParent<Generador>().transform.position.y);
            }
        }
        if(GetComponentInParent<Generador>().Act == false)
        {
            GetComponentInParent<Generador>().created = false;
            Destroy(gameObject);
        }
	}
}
