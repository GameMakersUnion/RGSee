using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
    Material canvasMat;
    GameObject[] players;
	// Use this for initialization
	void Start () {
        players = new GameObject[] {
            GameObject.Find("Player0"),
            GameObject.Find("Player1"),
            GameObject.Find("Player2")
        };
        canvasMat = (Material)Resources.Load("Materials/Canvas", typeof(Material));
	}
	
	// Update is called once per frame
	void Update () {
        canvasMat.SetVector("_RedPos", players[0].transform.position);
        canvasMat.SetVector("_GreenPos", players[1].transform.position);
        canvasMat.SetVector("_BluePos", players[2].transform.position);
    }
}
