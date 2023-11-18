using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CazadorCabras : JugadorCabras
{
    public float distanceToShoot = 10;
    public float ThrowStrenght = 15;

    public override Dictionary<string, object> CreateGoalState()
    {
        Dictionary<string, object> meta = new Dictionary<string, object>();

        // Vamos a darle una meta en la vida
        meta.Add("AnotarUnGol", true);

        Debug.Log("Se propuso golear al resto");    

        return meta;
    }
}
