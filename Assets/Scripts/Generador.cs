using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public bool producir;
    private Rigidbody2D rigidbody;
    public GameObject[] objeto;
    public float tiempoMin = 1f;
    public float tiempoMax = 2f;

    // Start is called before the first frame update
    void Start()
    {
        producir = true;
        Generar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generar()
    {
        if(producir){
            Instantiate(objeto[Random.Range(0, objeto.Length)],
            transform.position, Quaternion.identity);
        Invoke("Generar", Random.Range(tiempoMin, tiempoMax));

        }
        
        
    }
}
