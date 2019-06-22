using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zgrav : MonoBehaviour {

    public float vert;
    float temp;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        temp = GetComponentInParent<GeneradorB>().speed;
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.tag == "Player" || other.tag == "Pushable"))
        {
            //if (GetComponentInParent<GeneradorB>().limit)
            //{
            //    vert = 1f;
            //}

            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, vert);
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if ((other.tag == "Player" || other.tag == "Pushable"))
        {
            vert = temp;
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, vert);

        }
    }
}
