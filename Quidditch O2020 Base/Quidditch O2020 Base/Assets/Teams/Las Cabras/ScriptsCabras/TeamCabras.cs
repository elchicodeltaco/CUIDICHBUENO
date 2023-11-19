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
    public List<Transform> LasCabras;
    public List<Transform> LosRivales;

    private GameObject QuaffleOwner;
    private Transform ClosestTeammateToQuaffle;


    public List<Transform> rivalGoals;
    private List<Transform> ownGoals;

    public List<Transform> MyStartingPositions;

    public List<Transform> myStartingPositions; // Saber donde inician mis jugadores
    public Transform mySeekerStartingPosition;

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

        Invoke("FillLateData", 1f);

    }

    void FillLateData()
    {
        if (GetTeamNumer() == 1)
        {
            // Mis rivales
            LosRivales = GameManager.instancia.team2Players;
            Rivals = LosRivales;
            // Mis posiciones iniciales
            myStartingPositions = GameManager.instancia.Team1StartPositions;
            mySeekerStartingPosition = GameManager.instancia.Team1SeekerStartPosition;

        }
        else
        {
            LosRivales = GameManager.instancia.team1Players;
            Rivals = LosRivales;
            myStartingPositions = GameManager.instancia.Team2StartPositions;
            mySeekerStartingPosition = GameManager.instancia.Team2SeekerStartPosition;
        }

        for (int j = 0; j < 6; j++)
        {

            Teammates[j].GetComponent<Player>().myNumberInTeam = j;
            Teammates[j].GetComponent<Player>().myStartingPosition = myStartingPositions[j];
        }
        LasCabras[6].GetComponent<Player>().myNumberInTeam = 6;
        LasCabras[6].GetComponent<Player>().myStartingPosition = mySeekerStartingPosition;

    }
}
