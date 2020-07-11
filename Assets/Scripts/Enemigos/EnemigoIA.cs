using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Salud))]
[RequireComponent(typeof(InputEnemigo))]

public class EnemigoIA : Enemigo
{
    private Animator animator;
    protected InputEnemigo input;
    protected SpriteRenderer sr;
    private Atacante atacante;
    private bool muerto;
    private bool atacando;
    private bool enCombate;
    private Vector2 direccionAtaque;
    private int correrHash;
    private int atacarHash;
    private int muerteHash;

    protected Habilidad habilidad;

    [SerializeField] private float distanciaDeteccion;
    [SerializeField] private float distaciaDeAtaque;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        input = GetComponent<InputEnemigo>();
        atacante = GetComponent<Atacante>();
        correrHash = Animator.StringToHash("Corriendo");
        atacarHash = Animator.StringToHash("Atacar");
        muerteHash = Animator.StringToHash("Muerto");
        habilidad = GetComponent<Habilidad>();

        Instantiate(puff, transform);
        Presentarse();
    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento();
    }

    protected void Comportamiento()
    {
        if(!muerto)
        {
            //Ataque
            if(!atacando && input.distanciaJugador < distaciaDeAtaque)
            {
                RealizarAtaque();
            }
            else if(!atacando && (enCombate || input.distanciaJugador<distanciaDeteccion)){
                MoverHaciaJugador();
            }
        }
    }

    private void RealizarAtaque()
    {
        float probabilidadDeAtaque = UnityEngine.Random.Range(0, 100);
        animator.SetBool(correrHash, false);
        if(probabilidadDeAtaque > 95)
        {
            direccionAtaque = input.direccionhaciaJugador;
            atacando = true;
            enCombate = true;
            animator.SetTrigger(atacarHash);
        }
    }

    private void MoverHaciaJugador()
    {
        animator.SetBool(correrHash, true);
        VoltearSprite();
        transform.position += (Vector3)input.direccionhaciaJugador*atributos.velocidad*Time.deltaTime;
    }

    protected virtual void VoltearSprite(){
        if(input.horizontal<0){
            sr.flipX = true;
        }
        else{
            sr.flipX = false;
        }
    }

    public virtual void EnemigoAtacar(){
        atacante.Atacar(direccionAtaque,atributos.ataque);
    }

    void SetAtacandoFalso(){
        atacando = false;
    }

    public void Morir(){
        muerto = true;
        animator.SetBool(muerteHash,true);
    }
}
