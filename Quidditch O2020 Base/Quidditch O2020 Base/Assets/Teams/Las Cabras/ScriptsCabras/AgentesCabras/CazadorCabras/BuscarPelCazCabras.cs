using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuscarPelCazCabras : GoapActionCabras
{
    private CazadorCabras Cazador;

    // Start is called before the first frame update
    public bool terminado = false;
    private float tiempoInicio = 0f;
    [SerializeField] private float duracionAccion = 0f;


    public BuscarPelCazCabras()
    {
 

        //AgregamosPrecondiciones
        AddPrecondition("tienePelota", false);

        //agregamos efectos
        AddEffect("tienePelota", true);


    }
    private void Start()
    {
        Cazador = GetComponent<CazadorCabras>();
        Cazador.steering.Target = GameManager.instancia.Quaffle.transform;
        Cazador.steering.seek = true;
        Cazador.steering.seekWeight = 1f;
    }
    public override bool checkPrecondition(GameObject obj)
    {
        if (tiempoInicio == 0)
        {
            tiempoInicio = Time.timeSinceLevelLoad;
        }
        if (Time.timeSinceLevelLoad > tiempoInicio + duracionAccion)
        {
            if (!GameManager.instancia.isQuaffleControlled())
            {
                Debug.Log("Esto entró");


                return true;
            }
        }
        else
        {
            return false;
        }
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
        Debug.Log("Esto está entrando");
        Cazador.tengoLaPelota = true;
        Cazador.steering.Target = null;
        Cazador.steering.seek = false;
        return true;
        

    }

    public override bool isDone()
    {
        return terminado;
    }
}
