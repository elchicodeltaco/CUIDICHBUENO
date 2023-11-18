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


    public BuscarElAro()
    {
        //AgregamosPrecondiciones
        AddPrecondition("tienePelota", true);
        //AddPrecondition("estaEnRango", false);

        //agregamos efectos

        //AddEffect("estaEnRango", true);
        AddEffect("tienePelota", false);



    }

    public override bool checkPrecondition(GameObject obj)
    {

        /*if(Cazador.steering.Target!= null)
        {
            if (Cazador.tengoLaPelota == true && Vector3.Distance(Cazador.transform.position, Cazador.steering.Target.position) <
            Cazador.distanceToShoot)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        return false;*/
        return true;

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
        /*GameManager.instancia.Quaffle.GetComponent<Quaffle>().Throw(
        Cazador.steering.Target.position - Cazador.transform.position,
        Cazador.ThrowStrenght);
        GameManager.instancia.FreeQuaffle();

        Cazador.tengoLaPelota = false;
        Cazador.steering.seek = false;
        Cazador.steering.seekWeight = 0f;
        terminado = true;
        return true;*/
        return true;
    }

    public override bool isDone()
    {

        Debug.Log("Ya lo terminé");

        return terminado;
    }
}
