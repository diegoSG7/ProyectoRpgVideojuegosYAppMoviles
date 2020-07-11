using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class Proyectil : MonoBehaviour
{
    public float velocidadInicial;
    public Vector2 direccionInicial;
    public int danio;
    private Rigidbody2D rb;
    public string tagObjetivo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direccionInicial.normalized * velocidadInicial;
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(tagObjetivo))
        {
            collision.gameObject.GetComponent<Atacable>().RecibiendoAtaque(direccionInicial, danio);
            Destroy(gameObject);
        }
    }
}
