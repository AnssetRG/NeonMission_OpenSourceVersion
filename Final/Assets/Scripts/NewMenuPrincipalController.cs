using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class NewMenuPrincipalController : MonoBehaviour {

    public GameObject Tutorial;
    public GameObject SeleccionarNiveles;
    public GameObject Salir;
    public GameObject TutorialS;
    public GameObject SeleccionarNivelesS;
    public GameObject SalirS;
    public GameObject MapaInstrucciones;
    public GameObject FondoNegro;
    

    public bool setTutorial;
    public bool setSN;
    public bool setSalir;
    public bool mostrarInstrucciones;

    private int cont;
    private bool presionado;

    public string tutorial;
    public string selectLevel;
    public string lvl1tag;

    public Image black;
    public Animator anim;
    private string lvlToLoad;

    public static bool [] lvlPasado = new bool [4];

    // Use this for initialization
    void Start () {
        setTutorial = true;
        setSN = false;
        setSalir = false;
        cont = 0;
        presionado = false;
        mostrarInstrucciones = false;
        
    }
	
	// Update is called once per frame
	void Update () {
        //move = ;
        MapaInstrucciones.SetActive(mostrarInstrucciones);
        FondoNegro.SetActive(mostrarInstrucciones);
        if (!mostrarInstrucciones)
        {
            if (!presionado)
            {
                if (Input.GetAxis("Vertical_Select") < -0.08f)
                {
                    cont++;
                    if (cont >= 2)
                    {
                        cont = 2;
                    }
                    presionado = true;

                }
                if (Input.GetAxis("Vertical_Select") > 0.08f)
                {
                    cont--;
                    if (cont <= 0)
                    {
                        cont = 0;
                    }
                    presionado = true;
                }
            }
            if (presionado)
            {
                if (Input.GetAxis("Vertical_Select") > -0.08 && Input.GetAxis("Vertical_Select") < 0.08f)
                {
                    presionado = false;
                }
            }
        }
        
        switch (cont)
        {
            case 0:
                setTutorial = true;
                setSN = false;
                setSalir = false;

                Tutorial.SetActive(false);
                TutorialS.SetActive(true);
                SeleccionarNiveles.SetActive(true);
                SeleccionarNivelesS.SetActive(false);
                Salir.SetActive(true);
                SalirS.SetActive(false);

                break;
            case 1:
                setTutorial = false;
                setSN = true;
                setSalir = false;

                Tutorial.SetActive(true);
                TutorialS.SetActive(false);
                SeleccionarNiveles.SetActive(false);
                SeleccionarNivelesS.SetActive(true);
                Salir.SetActive(true);
                SalirS.SetActive(false);

                break;
            case 2:
                setTutorial = false;
                setSN = false;
                setSalir = true;

                Tutorial.SetActive(true);
                TutorialS.SetActive(false);
                SeleccionarNiveles.SetActive(true);
                SeleccionarNivelesS.SetActive(false);
                Salir.SetActive(false);
                SalirS.SetActive(true);

                break;
        }
        if (Input.GetButtonDown("Select"))
        {

            if (setTutorial && mostrarInstrucciones)
            {
                lvlToLoad = tutorial;
                StartCoroutine(Iniciar(lvlToLoad));
            }else  if (setTutorial)
            {
                mostrarInstrucciones = !mostrarInstrucciones;


            } else if (setSN)
            {
                lvlToLoad = selectLevel;
                StartCoroutine(Iniciar(lvlToLoad));
            } else if (setSalir)
            {
                Application.Quit();
            }
        }
	}

    IEnumerator Iniciar(string level)
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(level);
    }

}
