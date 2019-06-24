using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_Zone : MonoBehaviour {

  
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
            other.GetComponent<PlayerController>().ladder = true;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            other.GetComponent<PlayerController>().ladder = false;
    }
}
