using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloquearLvl6 : MonoBehaviour
{

    public GameObject desbloqueable;
    public GameObject removible;
    public GameObject CameraO;
    private bool mostarNivel;
    private int contLvl;
    public int NumTest;

    // Use this for initialization
    void Start()
    {
        NumTest = 0;
        contLvl = 0;
        for (int i = 0; i < NewMenuPrincipalController.lvlPasado.Length; i++)
        {
            mostarNivel = NewMenuPrincipalController.lvlPasado[i];
            if (mostarNivel)
            {
                contLvl++;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (contLvl >= 5 || NumTest >=5)
        {
            removible.SetActive(false);
            desbloqueable.SetActive(true);
            CameraO.SetActive(false);
            
        }
        else
        {
            removible.SetActive(true);
            desbloqueable.SetActive(false);
            CameraO.SetActive(true);
        }
    }
}
