using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruccion : MonoBehaviour {

    public Transform target;
    public float speed;
    public bool Act;

    public bool random;
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
        }
        if (random)
        {
            speed = (speed) + 2f*Random.value; //1.5
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void FixedUpdate()
    {
        if (Act)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            if (transform.position == target.position)
            {
                Destroy(gameObject);
            }
        }
    }
}
