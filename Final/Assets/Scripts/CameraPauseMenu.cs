using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraPauseMenu : MonoBehaviour {

    public GameObject Renaudar;
    public GameObject Salir;
    public GameObject RenaudarS;
    public GameObject SalirS;
    public GameObject MapaInstrucciones;
    public GameObject FondoNegro;
    public GameObject R2;
    public GameObject L2;


    public bool setRenaudar;
    public bool setSalir;
    public bool mostrarInstrucciones;

    private int cont;
    private bool presionado;

    private string MenuPrincipal;
    private string selectLevel;

    public Image black;
    public Animator anim;
    public bool isPaused;
    public GameObject pauseMenu;
    public float speedTime;

    void Start()
    {
        Time.timeScale=speedTime;
        MenuPrincipal = "Title_Menu";
        selectLevel = "Seleccionar_Nivel";
        isPaused = false;
        setRenaudar = false;
        setSalir = false;
        cont = 0;
        presionado = false;
        mostrarInstrucciones = false;
        pauseMenu.SetActive(isPaused);
    }

    void Update()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
                if (Input.GetButtonDown("Horizontal_Select_Derecha"))
                {
                    cont++;
                    if (cont >= 1)
                    {
                        cont = 1;
                    }

                }else if (Input.GetButtonDown("Horizontal_Select_Izquierda"))
                {
                    cont--;
                    if (cont <= 0)
                    {
                        cont = 0;
                    }
                }

            switch (cont)
            {
                case 0:
                    setRenaudar = true;
                    setSalir = false;

                    Renaudar.SetActive(false);
                    RenaudarS.SetActive(true);
                    Salir.SetActive(true);
                    SalirS.SetActive(false);

                    break;
                case 1:
                    setRenaudar = false;
                    setSalir = true;

                    Renaudar.SetActive(true);
                    RenaudarS.SetActive(false);
                    Salir.SetActive(false);
                    SalirS.SetActive(true);

                    break;
            }
            if (Input.GetButtonDown("Select"))
            {
                if (setRenaudar)
                {
                    isPaused = false;
                }
                else if (setSalir)
                {
                    StartCoroutine(Iniciar());
                }
            }
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = speedTime;
        }

        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;
        }
    }

        

    IEnumerator Iniciar()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        Time.timeScale = speedTime;
        SceneManager.LoadScene(MenuPrincipal);
    }
}
