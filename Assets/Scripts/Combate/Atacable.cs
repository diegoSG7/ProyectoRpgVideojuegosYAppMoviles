using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacable : MonoBehaviour
{
    private Salud miSalud;
    private Rigidbody2D rb;

    void Start()
    {
        miSalud = GetComponent<Salud>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void RecibiendoAtaque()
    {
        miSalud.SaludActual -= 1;
    }

    public void RecibiendoAtaque(Vector2 direccionAtaque, int danio)
    {
        miSalud.modificarSaludActual(-danio);
        rb.AddForce(direccionAtaque*danio*10);
    }
}
