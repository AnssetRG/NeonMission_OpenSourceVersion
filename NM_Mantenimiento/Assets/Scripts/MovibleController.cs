using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovibleController : MonoBehaviour {

    //public PlayerController player;

    //public Rigidbody2D boxRB;
    //protected RaycastHit2D hit;

    //// Use this for initialization
    //void Start () {
    //    boxRB = GetComponent<Rigidbody2D>();
    //}
	
    //// Update is called once per frame
    //void Update () {
    //    Physics2D.queriesStartInColliders = false;
    //   // RaycastHit2D hit = Physics2D.Raycast(GetComponent<Rigidbody2D>().position, Vector2.right *)
    //}

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        Physics2D.queriesStartInColliders = false;

    //        RaycastHit2D hit = Physics2D.Raycast(boxRB.position, Vector2.right * boxRB.transform.localScale.x, distance, boxMask);

    //        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyDown(agarrar) && anim.GetBool("Grounded"))
    //        {
    //            pushed = true;
    //            box = hit.collider.gameObject;
    //            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
    //            box.GetComponent<FixedJoint2D>().enabled = true;
    //            box.GetComponent<Rigidbody2D>().mass = 5;
    //            anim.SetBool("Pushed", pushed);
    //        }
    //        else if (Input.GetKeyUp(agarrar) && box)
    //        {
    //            pushed = false;
    //            box.GetComponent<FixedJoint2D>().enabled = false;
    //            box.GetComponent<Rigidbody2D>().mass = 100;
    //            anim.SetBool("Pushed", pushed);
    //        }
    //    }
    //}
}
