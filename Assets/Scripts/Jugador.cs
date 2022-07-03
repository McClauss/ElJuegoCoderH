using UnityEngine;

public class Jugador : MonoBehaviour
{

    public float speed=5;   //Velocidad Movimiento
    Vector3 posInicial;     //Posición inicial del jugador
    public Transform posEnemigo; //Posicion del Enemigo
    public GameObject HachaEspalda;//Arma Enfundada
    public GameObject HachaAtaque;//Arma Desenfundada

    void Start()
    {
        posInicial=transform.position;
    }

    
    void Update()
    {
        MovimientoJugador();
        VerificaCaida();
        DesenfundaArma();
        
    }

     //Función para mover/rotar jugador con Teclado (Felchas y AWSD)
    void MovimientoJugador(){
        float hor= Input.GetAxis("Horizontal");//Lee Eje Horizontal
        float ver= Input.GetAxis("Vertical");//Lee Eje Vertical

        transform.Translate(new Vector3(0,0,ver)*speed*Time.deltaTime);//Mover Adelanta-Atrás
        transform.Rotate(0,hor,0);//Rotar
    }

    //Función para verificar caida del mapa
    void VerificaCaida(){
        if(transform.position.y <-10){//Si Jugador Cae del Tablero
            Respawn();
        }
    }

    /*Función para Respawn al Jugador*/
    void Respawn(){
        transform.position=posInicial;
    }

    /*Funcion para Sacar el Arma a determinada proximidad*/
    void DesenfundaArma(){
        float distancia=Vector3.Distance(transform.position,posEnemigo.position);//mide distancia entre posicion vs posicion dos
        
        if (distancia<=8){
            //Debug.Log("Distancia: "+distancia+". Activar Arma");
            ActivarArma();
        }
        else
        {
            //Debug.Log("Distancia: "+distancia+". Desactivar Arma");
            DesactivarArma();
        }
    }

    //Activar Arma
    void ActivarArma(){
        HachaEspalda.SetActive(false);
        HachaAtaque.SetActive(true);
    }

    //Desactivar Arma
    void DesactivarArma(){
        HachaEspalda.SetActive(true);
        HachaAtaque.SetActive(false);
    }

   
}
