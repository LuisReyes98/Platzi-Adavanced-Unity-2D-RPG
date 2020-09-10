using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerController.playerCreated)
        {
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // void Awake()
    // {
    //     // Primero creamos un Array que busque y guarde todos los objetos que contengan la misma tag
    //     GameObject[] objectsWithSameTag = GameObject.FindGameObjectsWithTag(this.gameObject.tag);

    //     // Si el largo de nuestro array es mayor que uno destruimos el objeto que intenta instanciarse,
    //     if (objectsWithSameTag.Length > 1)
    //     {
    //         Destroy(this.gameObject);
    //     }

    //     // Si la condicion de arriba no se cumple llamamos a DontDestroyOnLoad
    //     DontDestroyOnLoad(this.gameObject);
    // }
}
