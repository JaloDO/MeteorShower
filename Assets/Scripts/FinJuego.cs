using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinJuego : MonoBehaviour
{
    public TextMesh texto;
    public Generador gen1;
    public Generador gen2;
    public Generador gen3;
    public Robot robo1;
    // Start is called before the first frame update
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "finalizar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.tag.Equals("estrella"))
        {
            //Debug.Break();
            Destroy(other.gameObject);
        }
        Destroy(other.gameObject);

    }
    void finalizar(){
        robo1.velocidadDesplazamiento = 0;
        gen1.producir=false;
        gen2.producir=false;
        gen3.producir=false;
        texto.gameObject.SetActive(true);

    }
}
