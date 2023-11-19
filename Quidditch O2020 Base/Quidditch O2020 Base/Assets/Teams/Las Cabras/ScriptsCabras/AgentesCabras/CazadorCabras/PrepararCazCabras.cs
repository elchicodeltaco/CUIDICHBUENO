using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PrepararCazCabras : GoapActionCabras
{
    private CazadorCabras Cazador;

    // Start is called before the first frame update
    public bool terminado = false;
    private float tiempoInicio = 0f;
    [SerializeField] private float duracionAccion = 0f;


    public PrepararCazCabras()
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
        Cazador = GetComponent<CazadorCabras>();
        
        if (Cazador.myStartingPosition != null)
        {
            Debug.Log("Esta entrando aqui mero");
            Cazador.steering.Target = Cazador.myStartingPosition;
            Cazador.steering.arrive = true;
            Cazador.steering.arriveWeight = 1f;
            Target = Cazador.myStartingPosition.gameObject;            
            return true;            
        }

        return false;
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
        StartCoroutine(CorutinaEsperar());
        return true;
    }

    public override bool isDone()
    {

        Debug.Log("Ya lo terminé");

        return terminado;
    }
    private IEnumerator CorutinaEsperar()
    {
        yield return new WaitForSeconds(5f);
        if (!GameManager.instancia.isGameStarted())
        {
            StartCoroutine(CorutinaEsperar());
        }
    }
}
