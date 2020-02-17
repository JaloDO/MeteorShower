using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Robot : MonoBehaviour
{
    public TextMesh texto;
    float f;
    Rigidbody2D rigi;
    public float velocidadDesplazamiento = 0f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        texto.gameObject.SetActive(false);
    }
    void awake(){
        rigi=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
         //Obtenemos -1 si se pulsa flecha izquierda y 1 si se pulsa flecha derecha
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        //Cambiar la direcci�n del sprite robot
        Vector3 characterScale = transform.localScale;
        if (movimientoHorizontal < 0)
            characterScale.x = -4.5913f;
        if (movimientoHorizontal > 0)
            characterScale.x = 4.5913f;

        transform.localScale = characterScale;

        //C�lculo de la posici�n en el ejeX despu�s de la pulsaci�n de la tecla
        //Time.deltaTime independiza el movimiento del fotograma. Calcula el tiempo que tarda el fotograma en ejecutarse
        float posX = transform.position.x + (movimientoHorizontal * velocidadDesplazamiento * Time.deltaTime);
        //Evitar que el robot se salga por los laterales del juego
        if (posX < -8.10)
            posX = -8.10f;
        if (posX > 8.10)
            posX = 8.10f;
        //Aplicamos el desplazamiento
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);

        f = velocidadDesplazamiento * Math.Abs(Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("vel",f);
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag.Equals("estrella")){
            
            Destroy(other.gameObject);
            NotificationCenter.DefaultCenter().PostNotification(this, "finalizar");


        }
    }
}
