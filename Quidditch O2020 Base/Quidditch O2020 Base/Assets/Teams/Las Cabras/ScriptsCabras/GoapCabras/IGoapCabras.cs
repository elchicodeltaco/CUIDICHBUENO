using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGoapCabras
{
    Dictionary<string, object> GetWorldState();

    // Proporcionar al planeador una meta para construir la
    // secuencia de acciones
    Dictionary<string, object> CreateGoalState();

    void PlanFailed(Dictionary<string, object> FailedGoal);

    void PlanFound(
        Dictionary<string, object> Goal, Queue<GoapActionCabras> actions);

    void ActionFinished();

    void PlanAborted(GoapActionCabras abortedAction);

    bool moveAgent(GoapActionCabras nextAction);
}
