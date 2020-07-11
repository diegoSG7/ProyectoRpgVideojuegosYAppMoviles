using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerSpawnPoint; //punto de inicio del jugador
    public GameObject jugador;
    //singleton para que la instancia no vuelva a ser definida
    public static GameManager instancia{get; private set;}
    //private static GameManager instancia{ get { return _instancia; } }
    public Transform contenedorDeProyectiles;

    //Awake se ejecuta apenas el script es cargado dentro del juego
    private void Awake(){
        if(instancia == null){
            instancia = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        jugador.transform.position = playerSpawnPoint.position;
    }

}
