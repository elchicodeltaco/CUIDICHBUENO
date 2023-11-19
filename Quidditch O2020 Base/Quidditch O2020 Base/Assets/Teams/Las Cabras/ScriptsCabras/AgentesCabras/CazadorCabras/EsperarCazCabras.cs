using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EsperarCazCabras : GoapActionCabras
{
    private CazadorCabras Cazador;

    // Start is called before the first frame update
    public bool terminado = false;
    private float tiempoInicio = 0f;
    [SerializeField] private float duracionAccion = 0f;


    public EsperarCazCabras()
    {
        //AgregamosPrecondiciones
        AddPrecondition("tienePelota", false);
        //AddPrecondition("estaEnRango", false);

        //agregamos efectos

        //AddEffect("estaEnRango", true);
        AddEffect("AnotarUnGol", true);
        AddEffect("tienePelota", true);
    }

    public override bool checkPrecondition(GameObject obj)
    {

        if (Cazador.myStartingPosition != null)
        {
            cazador.steering.Target = cazador.myStartingPosition;
            cazador.steering.arrive = true;
            cazador.steering.arriveWeight = 1f;
        }

        List<Transform> objetivos = GetComponentInParent<TeamCabras>().rivalGoals;
        float distanciaMenor = 0f;

        Transform objetivoMasCercano = null;


        //Primer pase
        if (objetivoMasCercano == null)
        {
            float distanciaMinima = float.MaxValue;
            Debug.Log(objetivos.Count);

            foreach (Transform t in objetivos)
            {


                if (distanciaMinima < Vector3.Distance(t.transform.position, transform.position))
                {
                    distanciaMinima = Vector3.Distance(t.transform.position, transform.position);
                    objetivoMasCercano = t;
                }
            }
        }
        Debug.Log("El objetivo es " + objetivoMasCercano);

        if (objetivoMasCercano!= null)
        {
            Cazador.steering.Target = objetivoMasCercano;
            return true;
            
        }
        else
        {

            return false;
        }


        //Asignamos lo que encontramos

    }


    public override bool requiresInRange()
    {
        return true;
    }

    //para que cada accion resetee sus variables
    public override void mReset()
    {

        terminado = false;
        tiempoInicio = 0f;
    }

    public override bool Perform(GameObject obj)
    {
        GameManager.instancia.Quaffle.GetComponent<Quaffle>().Throw(
        Cazador.steering.Target.position - Cazador.transform.position,
        Cazador.ThrowStrenght);
        GameManager.instancia.FreeQuaffle();

        GetComponent<LasBolas>().LaPelota = 0;
        //Cazador.steering.seek = false;
        //Cazador.steering.seekWeight = 0f;
        Target = null;
        return true;
    }

    public override bool isDone()
    {

        Debug.Log("Ya lo terminé");

        return terminado;
    }
}
