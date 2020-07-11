using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputWarrior : MonoBehaviour
{
    public float ejeHorizontal { get; private set; }
    public float ejeVertical { get; private set; }
    public bool atacar { get; private set; }
    public bool correr { get; private set; }
    public bool habilidad1 { get; private set; }
    public bool habilidad2 { get; private set; }
    public bool inventario { get; private set; }
    public bool interactuar { get; private set; }
    [HideInInspector]
    public Vector2 direccionMirada = new Vector2(0,-1f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        atacar = Input.GetButtonDown("Atacar");
        correr = Input.GetButtonDown("Correr");
        habilidad1 = Input.GetButtonDown("Habilidad1");
        habilidad2 = Input.GetButtonDown("Habilidad2");
        inventario = Input.GetButtonDown("Inventario");
        interactuar = Input.GetButtonDown("Interactuar");
        ejeHorizontal = Input.GetAxis("Horizontal");
        ejeVertical = Input.GetAxis("Vertical");
        
        DeterminarDireccionMirada();
        //Debug.DrawLine(transform.position, transform.position + (Vector3)direccionMirada.normalized*3, Color.green);
    }

    private void DeterminarDireccionMirada()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            direccionMirada.x = ejeHorizontal;
            direccionMirada.y = ejeVertical;
        }
    }
}
