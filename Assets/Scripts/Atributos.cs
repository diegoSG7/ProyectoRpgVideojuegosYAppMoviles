using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Atributo
{
    velocidad,
    ataque,
    Salud
}

[CreateAssetMenu(menuName = "ObjetosScriptables/Atributos")]
public class Atributos : ScriptableObject
{
   [Tooltip("Velocidad de movimiento")]

    [SerializeField]
    private int velocidadBase;
    [SerializeField]
    private int ataqueBase;

    private int velocidadModificador;
    private int ataqueModificador;

    public int velocidad { get {return velocidadBase+velocidadModificador ; } }
    public int ataque { get { return ataqueBase + ataqueModificador; }}

    public void AumentarVelocidadBase(int cantidad)
    {
        velocidadBase += cantidad;
    }

    public void AumentarAtaqueBase(int cantidad)
    {
        ataqueBase += cantidad;
    }
    
   public void ModificarAtributo(Atributo atributo, int cantidad)
    {
        switch (atributo)
        {
            case Atributo.velocidad:
                velocidadModificador += cantidad;

                break;
            case Atributo.ataque:
                ataqueModificador += cantidad;
                break;
            case Atributo.Salud:
                break;
            default:
                Debug.Log("Ninguna de las anteriores");
                break;
        }
    }

    private void ModificarSalud(Salud salud,int cantidad)
    {
        salud.ModificadorSalud += cantidad;
    }

    public void ActualizarEquipamiento(List<Equipamiento> equipamientos)
    {
        ResetearModificadores();
        foreach (Equipamiento equipo in equipamientos)
        {
            velocidadModificador += equipo.velocidad;
            ataqueModificador += equipo.ataque;

            GameManager.instancia.jugador.GetComponent<Salud>().ModificadorSalud += equipo.salud;
        }

        PanelAtributos.instance.ActualizarTextosAtributos(this, GameManager.instancia.jugador.GetComponent<Salud>(), GameManager.instancia.jugador.GetComponent<NivelDeExperiencia>());
        GameManager.instancia.jugador.GetComponent<Salud>().ActualizarBarraDeSalud();
    }

    private void ResetearModificadores()
    {
        velocidadModificador = 0;
        ataqueModificador = 0;
        GameManager.instancia.jugador.GetComponent<Salud>().ModificadorSalud = 0;
    }
}
