using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamCabras : Team
{
    public string TeamName = "Cabras";

    private int MyTeamNumber;

    public int GetTeamNumer()
    {
        return MyTeamNumber;
    }

    private List<Transform> rivalGoals;
    private List<Transform> ownGoals;

    public List<Transform> MyStartingPositions;

    public Color MyTeamColor;
    // Start is called before the first frame update
    protected override void Start()
    {
        Teammates = new List<Transform>();

        Teammates.Add(transform.Find("Primer Cazador"));
        Teammates.Add(transform.Find("Segundo Cazador"));
        Teammates.Add(transform.Find("Tercer Cazador"));
        Teammates.Add(transform.Find("Guardian"));
        Teammates.Add(transform.Find("Golpeador Uno"));
        Teammates.Add(transform.Find("Golpeador Dos"));
        Teammates.Add(transform.Find("Buscador"));

        MyTeamNumber = GameManager.instancia.SetTeamName(TeamName);

        //Ya sabemos la posicion del equipo

        if (MyTeamNumber == 1)
        {
            GameManager.instancia.team1Players = Teammates;

            rivalGoals = GameManager.instancia.team2Goals;
            ownGoals = GameManager.instancia.team1Goals;
        }

        else
        {

            GameManager.instancia.team2Players = Teammates;

            rivalGoals = GameManager.instancia.team1Goals;
            ownGoals = GameManager.instancia.team2Goals;
        }

        GameManager.instancia.SetTeamColor(MyTeamNumber, MyTeamColor);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
