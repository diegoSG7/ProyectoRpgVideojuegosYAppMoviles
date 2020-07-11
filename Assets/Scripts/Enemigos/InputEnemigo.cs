using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemigo : MonoBehaviour
{
    public Transform jugador;
    public float vertical{get{return direccionhaciaJugador.y;} }
    public float horizontal{get{return direccionhaciaJugador.x;} }
    public float distanciaJugador {get{return direccionhaciaJugador.magnitude;} }
    public Vector2 direccionhaciaJugador{get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        //jugador = GameManager.instancia.jugador.transform;
        DefinirDireccionDelJugador();
    }

    // Update is called once per frame
    void Update()
    {
        DefinirDireccionDelJugador();

    }

    private void DefinirDireccionDelJugador()
    {
        direccionhaciaJugador = jugador.position - transform.position;
    }
}
