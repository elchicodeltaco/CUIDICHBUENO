using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuscarPelCazCabras : GoapActionCabras
{

    // Start is called before the first frame update
    public bool terminado = false;
    private float tiempoInicio = 0f;
    [SerializeField] private float duracionAccion = 1f;


    public BuscarPelCazCabras()
    {
        //AgregamosPrecondiciones
        AddPrecondition("tienePelota", false);

        //agregamos efectos
        AddEffect("AnotarUnGol", true);
        AddEffect("tienePelota", true);
    }
    public override bool checkPrecondition(GameObject obj)
    {
        Debug.Log("Se checó la precondición");
        GameObject objetivo = GameObject.Find("Quaffle");

        //Primer pase
        if (objetivo != null)
        {
            Target = objetivo;
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
        if (tiempoInicio == 0)
        {
            tiempoInicio = Time.timeSinceLevelLoad;
        }
        if (Time.timeSinceLevelLoad > tiempoInicio + duracionAccion)
        {

            Target.GetComponent<Quaffle>().Control(transform);
            //GetComponent<JugadorCabras>().tengoLaPelota = true;

            GetComponent<MisBolas>().LaPelota = 1;
            terminado = true;
        }
        return true;
    }

    public override bool isDone()
    {
        return terminado;
    }
}
