using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagenTitulo : MonoBehaviour
{
    public Sprite imagen1;
    public Sprite imagen2;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public bool abierto;

	public void CambiarDeImagen()
    {
        if (abierto)
        {
            image.sprite = imagen1;
            abierto = false;
        }
        else
        {
            image.sprite = imagen2;
            abierto = true;
        }
    }
}
