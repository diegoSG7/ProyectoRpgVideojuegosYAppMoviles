using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistente : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NoDestruir();
    }

    private void NoDestruir()
    {
        DontDestroyOnLoad(this);
    }

}
