using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuscarElAro : GoapActionCabras
{
    private CazadorCabras Cazador;

    // Start is called before the first frame update
    public bool terminado = false;
    private float tiempoInicio = 0f;
    [SerializeField] private float duracionAccion = 0f;
    private SteeringCombined steering;


    public BuscarElAro(CazadorCabras Cazador)
    {

        this.Cazador = Cazador;

        //AgregamosPrecondiciones
        AddPrecondition("tienePelota", true);

        //agregamos efectos

        AddEffect("estaEnRango", true);
    }

    public override bool checkPrecondition(GameObject obj)
    {
        if (GameManager.instancia.ControlQuaffle(gameObject))
        {
            steering.seek = false;
            return true;
        }

        else
                {
            return false;
        }
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

         terminado = true;
         return true;
    }

    public override bool isDone()
    {

        Debug.Log("Ya lo terminé");
        steering.Target = null;
        steering.seek = false;
        steering.seekWeight = 0f;
        return terminado;
    }
}
