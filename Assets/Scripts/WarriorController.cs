using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Atributos))]
public class WarriorController : MonoBehaviour
{
    //[SerializeField] private float velocidad = 1;
    private InputWarrior inputWarrior;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    public Atributos atributosJugador;
    private Atacante atacante;
    private Salud salud;
    private NivelDeExperiencia nivelDeExperiencia;
    private float horizontal;
    private float vertical;
    private bool correr;
    public LayerMask layerInteraccion;
    private Habilidad habilidad;
    private TrailRenderer trailRenderer;
    private float dashCooldown=0; //Tiempo en el cual se tardará en ejecutar la habilidad
    private bool usandoDash;
    public Proyectil proyectil;
    private PiesAudio pies;
    int correrHashCode;

    
    // Start is called before the first frame update
    void Start()
    {
        pies = GetComponentInChildren<PiesAudio>();
        trailRenderer = GetComponent<TrailRenderer>();
        habilidad = GetComponent<Habilidad>();
        nivelDeExperiencia = GetComponent<NivelDeExperiencia>();
        salud = GetComponent<Salud>();
        inputWarrior = GetComponent<InputWarrior>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        atacante = GetComponent<Atacante>();
        correrHashCode = Animator.StringToHash("Corriendo");
        PanelAtributos.instance.ActualizarTextosAtributos(atributosJugador,salud,nivelDeExperiencia);
    }

    void FixedUpdate() //todo lo que tiene que ver con las fisicas
    {
        ///-------Movimiento------//
        if(Input.GetButtonDown("Atacar")){
            Debug.Log("atacando");
            animator.SetBool("Atacando", true);
        }

        if(animator.GetBool("Atacando")){
            rb.velocity = Vector2.zero;
        }
        else if((horizontal != 0 || vertical != 0) && !usandoDash){
            rb.velocity = new Vector2(horizontal, vertical) * atributosJugador.velocidad;
        }

        //---Habilidades---//
        if (inputWarrior.habilidad2)
        {
            usandoDash = true;
            habilidad.Dash(inputWarrior.direccionMirada, rb);

            ActivarODesactivarTrailRenderer();
        }

        if (inputWarrior.habilidad1)
        {
            habilidad.DispararProyectil(proyectil, 10f, inputWarrior.direccionMirada, atributosJugador.ataque);
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = inputWarrior.ejeHorizontal;
        vertical = inputWarrior.ejeVertical;

        if (horizontal != 0 || vertical != 0)
        {
             SetXYAnimator();
             animator.SetBool(correrHashCode, true);
        }
        else
        {
             animator.SetBool(correrHashCode, false);
        }

        if (inputWarrior.inventario)
        {
            PanelMenu.instance.AbrirCerrarPaneles();
        }

        ActualizarDashCoolDown();
    }

    private void ActualizarDashCoolDown()
    {
        if (usandoDash)
        {
            dashCooldown += Time.deltaTime;
            if (dashCooldown>trailRenderer.time)
            {
                ActivarODesactivarTrailRenderer();
                dashCooldown = 0;
                usandoDash = false;
            }
        }

    }

    private void SetXYAnimator()
    {
        animator.SetFloat("X", horizontal);
        animator.SetFloat("Y", vertical);
    }

    void ControllerAtacar(){
        atacante.Atacar(inputWarrior.direccionMirada, atributosJugador.ataque);
        animator.SetBool("Atacando", false);
    }

    private void ActivarODesactivarTrailRenderer()
    {
        if (trailRenderer.enabled)
        {
            trailRenderer.enabled = false;
        }
        else
        {
            trailRenderer.enabled = true;
        }
    }


    //Llamar a interactuar con alguna tecla o haciendo click
    public RaycastHit2D[] Interactuar()
    {
        RaycastHit2D[] circleCast = Physics2D.CircleCastAll(transform.position, GetComponent<CapsuleCollider2D>().size.x, inputWarrior.direccionMirada.normalized, 2f, layerInteraccion);
        if (circleCast!= null)
        {
            return circleCast;
        }
        else
        {
            return null;
        }
    }

    private void Pisar()
    {
        
        pies.ReproducirSonido();
    }

}
