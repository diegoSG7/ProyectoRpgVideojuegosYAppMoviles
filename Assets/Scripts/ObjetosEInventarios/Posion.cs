using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="ObjetosScriptables/Items/Pociones/Salud")]
public class Posion : Item 
{
    public int curacion;

    public override bool UsarItem()
    {
        Salud saludJugador = GameManager.instancia.jugador.GetComponent<Salud>();
        if (saludJugador.SaludActual>=saludJugador.salud)
        {
            Debug.Log("Salud Llena , no se utilizará poción");
            return false;
        }
        else
        {
            saludJugador.modificarSaludActual(curacion);
            return true;
        }
    }
}
