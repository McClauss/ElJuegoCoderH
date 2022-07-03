using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform posEnemigo;
    public float Speed = 1.025f;
    public float distanciaTope=2f;

    public enum TipoAccion{
        seguir,
        observar
    }

    public TipoAccion accionEnemigo;
    
    void Start()
    {
        accionEnemigo=TipoAccion.observar;
    }
    
    void Update()
    {
        
        //De acuerdo a tipo de enemigo lo observa o lo persigue
        switch(gameObject.tag){
            case "soldadoSigue":
                distanciaTope=2;
                SeguirJugador();
                break;
            case "soldadoObserva":
                ObservarJugador();
                break;
            case "soldadoMixto":
                distanciaTope=5;
                LeeTipoAccion();
                break;
            default:
                ObservarJugador();
                break;

        }
    }

    //Funcion para seguir jugador hasta una distancia
    void SeguirJugador(){
        float distancia=Vector3.Distance(transform.position,posEnemigo.position);//mide distancia entre posicion vs posicion dos
        Debug.Log("Distancia Medida Enemigo: "+gameObject.tag+" es: "+distancia);
        if (distancia>distanciaTope){
           transform.position = Vector3.Lerp(transform.position,posEnemigo.position,Speed* Time.deltaTime);
           ObservarJugador();
        }
        else{
            ObservarJugador();
        }
    }

    //Función para observar a jugador
    void ObservarJugador(){
        //transform.LookAt(posEnemigo);
        transform.LookAt(Vector3.Lerp(transform.position,posEnemigo.position,Speed* Time.deltaTime));
    }

    //Funcion para Ver Tipo de Ataque Seteado en Inspector
    void LeeTipoAccion(){
        switch(accionEnemigo){
            case TipoAccion.seguir:
            SeguirJugador();
            break;
            case TipoAccion.observar:
            ObservarJugador();
            break;
            default:
            ObservarJugador();
            break;
        }
    }
}
