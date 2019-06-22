using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransB : MonoBehaviour {

    public BoxCollider2D myB;
    public float largo;
    float pos;
    void Start()
    {
        myB = GetComponent<BoxCollider2D>();
        largo = GetComponentInParent<GeneradorB>().largo;
        myB.transform.localScale = new Vector2(0, 0);
        myB.transform.position = new Vector2(GetComponentInParent<GeneradorB>().transform.position.x, 0);
        pos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 0.3f);

        if (GetComponentInParent<GeneradorB>().transform.rotation.w == 1f)
        {
            pos = GetComponentInParent<GeneradorB>().transform.position.y - 0.5f;
        }
        if (GetComponentInParent<GeneradorB>().transform.rotation.w == 0f)
        {
            pos = GetComponentInParent<GeneradorB>().transform.position.y + 0.5f;
        }
        if (GetComponentInParent<GeneradorB>().transform.rotation.w >= 0.6f && GetComponentInParent<GeneradorB>().transform.rotation.w <= 0.8f)
        {
            pos = GetComponentInParent<GeneradorB>().transform.position.x + 0.5f;
        }
        if (GetComponentInParent<GeneradorB>().transform.rotation.w <= -0.6f && GetComponentInParent<GeneradorB>().transform.rotation.w >= -0.8f)
        {
            pos = GetComponentInParent<GeneradorB>().transform.position.x - 0.5f;
        }


        for (int i = 0; i < largo; i++)
        {
            if (GetComponentInParent<GeneradorB>().transform.rotation.w == 1f)
            {
                myB.transform.localScale = new Vector2(1, i + 1);

                myB.transform.position = new Vector2(GetComponentInParent<GeneradorB>().transform.position.x, pos = pos - 0.5f);
            }
            if (GetComponentInParent<GeneradorB>().transform.rotation.w == 0f)
            {
                myB.transform.localScale = new Vector2(1, i + 1);
                myB.transform.position = new Vector2(GetComponentInParent<GeneradorB>().transform.position.x, pos = pos + 0.5f);
            }
            if (GetComponentInParent<GeneradorB>().transform.rotation.w >= 0.6f && GetComponentInParent<GeneradorB>().transform.rotation.w <= 0.8f)
            {
                myB.transform.localScale = new Vector2(i + 1, 1);
                myB.transform.position = new Vector2(pos = pos + 0.5f, GetComponentInParent<GeneradorB>().transform.position.y);
            }
            if (GetComponentInParent<GeneradorB>().transform.rotation.w <= -0.6f && GetComponentInParent<GeneradorB>().transform.rotation.w >= -0.8f)
            {
                myB.transform.localScale = new Vector2(i + 1, 1);
                myB.transform.position = new Vector2(pos = pos - 0.5f, GetComponentInParent<GeneradorB>().transform.position.y);
            }
        }
        if (GetComponentInParent<GeneradorB>().Act == false)
        {
            GetComponentInParent<GeneradorB>().created = false;
            Destroy(gameObject);
        }
    }
}
