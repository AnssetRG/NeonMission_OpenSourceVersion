using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unidad2 : MonoBehaviour {

    private BoxCollider2D myBC;
    Rigidbody2D rig;

    public float tamañoNec;
    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        myBC = GetComponent<BoxCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null && other.gameObject.tag == "Player" && ((transform.position.y - tamañoNec) > other.transform.position.y) && (other.gameObject.GetComponent<PlayerController>().prepara))
        {
            other.gameObject.GetComponent<PlayerController>().JumpOther = true;
            rig.velocity = new Vector2(rig.velocity.x, 8 * (1.25f));
            other.transform.parent = myBC.transform;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.transform.tag == "Player" && other.transform.GetComponent<PlayerController>().grounded && !other.transform.GetComponent<PlayerController>().pushed)
        {
            other.transform.parent = myBC.transform;
            if(myBC.transform.tag == "Pushable")
                other.transform.GetComponent<PlayerController>().velocityAd = GetComponent<Rigidbody2D>().velocity.x;
        }
    }

    void OnCollisionExit2D(Collision2D other)   
    {
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<PlayerController>().velocityAd = 0;
            other.transform.parent = null;
        }
    }
}
