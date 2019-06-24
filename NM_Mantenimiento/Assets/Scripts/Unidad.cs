using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unidad : MonoBehaviour {

    private BoxCollider2D myBC;
    // Use this for initialization
    void Start()
    {
        myBC = GetComponent<BoxCollider2D>();
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if ((other.transform.tag == "Player" && other.transform.GetComponent<PlayerController>().plataformed) || other.transform.name == "UnMov" || other.transform.name == "UnMov(Clone)")
        {
            other.transform.parent = myBC.transform;
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.transform.tag == "Player" && other.transform.GetComponent<PlayerController>().plataformed) || other.transform.name == "UnMov" || other.transform.name == "UnMov(Clone)" || (other.transform.tag == "Pushable" && other.gameObject.GetComponent<Unidad3>().solo))
        {
            other.transform.parent = myBC.transform;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player" || other.transform.name == "UnMov" || other.transform.name == "UnMov(Clone)" || (other.transform.tag == "Pushable" && other.gameObject.GetComponent<Unidad3>().solo))
            other.transform.parent = null;
    }
}
