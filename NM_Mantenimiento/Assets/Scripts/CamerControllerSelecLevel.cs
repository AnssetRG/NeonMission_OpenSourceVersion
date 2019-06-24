using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerControllerSelecLevel : MonoBehaviour {

    private Camera cam;
    public PlayerController player1;
    public PlayerController player2;
    public bool IsFollowing;


    public float xOffSet;
    public float yOffSet;

    // Use this for initialization
    void Start()
    {
        //player = FindObjectOfType<PlayerController>();
        cam = GetComponent<Camera>();
        IsFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFollowing)
        {
            if (player1.isDead == false && player2.isDead == false)
            {
                transform.position = new Vector3((player1.transform.position.x + player2.transform.position.x) / 2 + xOffSet, (player1.transform.position.y + player2.transform.position.y) / 2 + yOffSet, transform.position.z);

                //Debug.Log((Mathf.Abs(player1.transform.position.x - player2.transform.position.x) + (player1.transform.position.y - player2.transform.position.y))/2/* / 2 - (player1.transform.position.y + player2.transform.position.y) / 2*/);
                if (Mathf.Abs((player1.transform.position.x - player2.transform.position.x) + (player1.transform.position.y - player2.transform.position.y)) / 2 <= 5)
                    cam.orthographicSize = (6);

                if (Mathf.Abs((player1.transform.position.x - player2.transform.position.x) + (player1.transform.position.y - player2.transform.position.y)) / 2 > 5)
                    cam.orthographicSize = ((Mathf.Abs((player1.transform.position.x - player2.transform.position.x) + (player1.transform.position.y - player2.transform.position.y))) / 2 + 1f);
            }
        }
    }
}
