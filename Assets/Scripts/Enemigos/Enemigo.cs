using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Atributos  atributos;
    public string nombre;
    public int experiencia;
    public GameObject puff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Presentarse(){
        Debug.Log("Hola, yo soy" + nombre);
    }

    public void EntregarExperiencia()
    {
        GameManager.instancia.jugador.GetComponent<NivelDeExperiencia>().experiencia += experiencia;
    }

}
