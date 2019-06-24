using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Camera cam;
    public PlayerController player1;
    public PlayerController player2;
    public bool IsFollowing;


    public float xOffSet;
    public float yOffSet;
    public bool changeSizeCamera;
    public float cameraOrthoSize;

    public float shakeTimer;
    public float shakeAmount;

    // Use this for initialization
    void Start () {
        //player = FindObjectOfType<PlayerController>();
        if (cameraOrthoSize == 0)
            cameraOrthoSize = 6;
        cam = GetComponent<Camera>();
        IsFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsFollowing)
        {
            if (player1.isDead == false && player2.isDead == false)
            {
                transform.position = new Vector3((player1.transform.position.x + player2.transform.position.x) / 2 + xOffSet, (player1.transform.position.y + player2.transform.position.y) / 2 + yOffSet, transform.position.z);

                //Debug.Log((Mathf.Abs(player1.transform.position.x - player2.transform.position.x) + (player1.transform.position.y - player2.transform.position.y))/2/* / 2 - (player1.transform.position.y + player2.transform.position.y) / 2*/);
                if (Mathf.Abs((player1.transform.position.x - player2.transform.position.x) + (player1.transform.position.y - player2.transform.position.y)) / 2 <= cameraOrthoSize-1)
                    cam.orthographicSize = (cameraOrthoSize);

                if (Mathf.Abs((player1.transform.position.x - player2.transform.position.x) + (player1.transform.position.y - player2.transform.position.y)) / 2 > cameraOrthoSize-1 && !changeSizeCamera)
                    cam.orthographicSize = ((Mathf.Abs((player1.transform.position.x - player2.transform.position.x) + (player1.transform.position.y - player2.transform.position.y))) / 2 + 1f);
            }
        }

        if (shakeTimer >= 0)
        {
            if(shakeTimer < 0.2f)
            {
                shakeAmount = 0.02f;
            }
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y, transform.position.z + ShakePos.y);
            //shakeAmount -= 0.001f;
            shakeTimer -= Time.deltaTime;
        }
    }

    public void ChangeOrthoSize(float n)
    {
        cameraOrthoSize = n;
    }

    public void SetShakeValues(float shakeTimer, float shakeAmount)
    {
        this.shakeTimer = shakeTimer;
        this.shakeAmount = shakeAmount;
    }
}
