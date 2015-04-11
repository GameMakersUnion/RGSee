using UnityEngine;
using System.Collections;

public class ColorController : MonoBehaviour {
    private Manager.Colors[] players;

	// Use this for initialization
	void Start () {
        //Setting the player colors
        players = new Manager.Colors[2];
        players[0] =  Manager.Colors.Red;
        players[1] = Manager.Colors.Green;
        players[2] = Manager.Colors.Blue;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
