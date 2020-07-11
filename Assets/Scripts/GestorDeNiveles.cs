using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorDeNiveles : MonoBehaviour
{
    public void CargarSiguienteNivel()
    {
        int escenaActualIndice = SceneManager.GetActiveScene().buildIndex;
        int siguieteEscenaIndice = ++escenaActualIndice;
        SceneManager.LoadScene(siguieteEscenaIndice);
    }
}
