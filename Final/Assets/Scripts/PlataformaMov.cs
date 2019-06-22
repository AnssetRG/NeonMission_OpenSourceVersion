using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMov : MonoBehaviour {

    public Transform target;
    public float speed;
    public bool Act;

    private Vector3 start, end;
	void Start () {
		if(target != null)
        {
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
	}
	
	// Update is called once per frame
	void Update()
    {

    }
    void FixedUpdate () {
        if (Act)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }

            if (transform.position == target.position)
            {
                target.position = (target.position == start) ? end : start;
            }
        }
	}
}
