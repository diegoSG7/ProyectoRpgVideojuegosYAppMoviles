using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextMesh))]
public class TextHit : MonoBehaviour
{
    public float tiempoVida = 2f;
    public float distanciaElevacion = 2;
    public TextMesh textMesh;
    public float tiempoInicioDesvanecer;
    public Color color;
    public string sortingLayer = "TEXTO";

    private bool desvaneciendo;
    private float distanciaActual = 0;
    private Vector3 movimientoVertical;
    private float cantidadAscender=0.1f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = sortingLayer;
        textMesh = GetComponent<TextMesh>();
        movimientoVertical = new Vector2(0,cantidadAscender);
    }

    // Update is called once per frame
    void Update()
    {
        if(distanciaActual<distanciaElevacion)
        {
            transform.localPosition += movimientoVertical;
            distanciaActual += cantidadAscender;

        }
        else
        {
            if(desvaneciendo==false)
            {
                Destroy(gameObject,tiempoVida);
                desvaneciendo = true;
                StartCoroutine(Desvanecer());
            }
            
        }
    }

    IEnumerator Desvanecer()
    {
        Color colorActual= textMesh.color;
        for(float alpha = 1; alpha > 0; alpha -= (1/(tiempoVida)*Time.deltaTime))
        {
            colorActual.a = alpha;
            textMesh.color = colorActual;
            yield return new WaitForEndOfFrame(); 
        }
    }
}
