using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;          

public class CamaraController : MonoBehaviour
{
    private CinemachineVirtualCamera cv;

    // Start is called before the first frame update
    void Start()
    {
        cv = GetComponent<CinemachineVirtualCamera>();
        //Transform jugador = GameObject.FindGameObjectWithTag("Player").transform;
        Transform jugador = GameManager.instancia.jugador.transform;
        cv.m_Follow = jugador;
    }

}
