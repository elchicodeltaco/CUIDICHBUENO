using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GoapActionCabras : MonoBehaviour
{
    // Precondiciones
    private Dictionary<string, object> Precondiciones;

    // Efectos
    private Dictionary<string, object> Efectos;

    // Una acción puede tener un costo
    public float cost;

    // Una acción por lo general se ejecuta sobre un objeto
    public GameObject Target;

    public bool inRange;

    public GoapActionCabras()
    {
        Precondiciones = new Dictionary<string, object>();
        Efectos = new Dictionary<string, object>();
    }

    // Limpiar la acción
    public void Reset()
    {
        Target = null;
        inRange = false;
        mReset();
    }

    // Para que cada acción resetee sus propias variables
    public abstract void mReset();

    // Cada acción debe decir si ya terminó de ejecutarse
    public abstract bool isDone();

    // Cada acción debe checar si puede ejecutarse
    public abstract bool checkPrecondition(GameObject obj);

    // Cada acción debe ejecutar sus tareas
    public abstract bool Perform(GameObject obj);

    // Si la acción requiere estar cerca de un objetivo
    public abstract bool requiresInRange();

    public bool IsInRange()
    {
        return inRange;
    }

    public void SetInRange(bool range)
    {
        inRange = range;
    }

    // Agregar precondiciones
    public void AddPrecondition(string key, object value)
    {
        Precondiciones.Add(key, value);
    }

    // Quitar precondiciones
    public void RemovePrecondition(string key)
    {
        Precondiciones.Remove(key);
    }

    // Agregar efectos
    public void AddEffect(string key, object value)
    {
        Efectos.Add(key, value);
    }

    // Remover efectos
    public void RemoveEffect(string key)
    {
        Efectos.Remove(key);
    }

    // Revisar las precondiciones de una acción
    public Dictionary<string, object> GetPrecondiciones
    {
        get { return Precondiciones; }
    }

    // Revisar los efectos de una acción
    public Dictionary<string, object> GetEfectos
    {
        get { return Efectos; }
    }
}
