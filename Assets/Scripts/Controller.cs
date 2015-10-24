using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

    public Player mainPlayer;
    public CameraFollow camFollow;

    Player activePlayer;
    int currentPlayer = 0;

    List<Player> players;

	void Start () {
        players = new List<Player>();
        players.Add(mainPlayer);
        activePlayer = mainPlayer;
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentPlayer++;
            if (currentPlayer >= players.Count)
            {
                currentPlayer = 0;
            }

            activePlayer = players[currentPlayer];
            camFollow.target = activePlayer.transform;
        }

        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        activePlayer.setTarget((mousePos.origin + (mousePos.direction * (-mousePos.origin.z / mousePos.direction.z))));
	}

    public void addPlayer(Player movement)
    {
        if(!players.Contains(movement))
            players.Add(movement);
    }
}
