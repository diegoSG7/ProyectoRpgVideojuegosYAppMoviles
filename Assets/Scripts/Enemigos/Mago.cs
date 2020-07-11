using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mago : EnemigoIA
{
    public Proyectil proyectil;

    public override void EnemigoAtacar()
    {
        Debug.Log("Disparando bola de fuego");
        habilidad.DispararProyectil(proyectil,proyectil.velocidadInicial,input.direccionhaciaJugador,atributos.ataque);
    }

    protected override void VoltearSprite()
    {
        if(input.horizontal<0){
            sr.flipX = false;
        }
        else{
            sr.flipX = true;
        }
    }

}
