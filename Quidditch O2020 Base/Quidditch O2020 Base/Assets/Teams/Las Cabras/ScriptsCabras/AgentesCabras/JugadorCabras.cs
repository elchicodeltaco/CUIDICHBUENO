﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JugadorCabras : Player, IGoapCabras
{
    // Start is called before the first frame update
    //public bool tengoLaPelota = false;
    public MisBolas misBolas;

    public abstract Dictionary<string, object> CreateGoalState();

    public Dictionary<string, object> GetWorldState()
    {

        Dictionary<string, object> datos = new Dictionary<string, object>();

        datos.Add("tienePelota", misBolas.LaPelota > 0);


        return datos;
    }
    public void PlanFailed(Dictionary<string, object> FailedGoal)
    {


    }

    public void PlanFound(
        Dictionary<string, object> Goal, Queue<GoapActionCabras> actions)
    {


    }

    public void ActionFinished()
    {

    }

    public void PlanAborted(GoapActionCabras abortedAction)
    {

    }

    public bool moveAgent(GoapActionCabras nextAction)
    {
        return false;
    }

    private void Start()
    {
        //tengoLaPelota = false;
        misBolas = GetComponent<MisBolas>();
    }
    private void Update()
    {
        
    }
}

//////////////////////////////////////////////////


