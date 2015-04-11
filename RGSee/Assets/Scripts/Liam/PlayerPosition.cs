using UnityEngine;
using System.Collections;

public class PlayerPosition : MonoBehaviour {
	public Material[] materials;
	public GameObject playerRed, playerGreen, playerBlue;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		foreach (Material mat in materials) {
			mat.SetVector("_RedPos", playerRed.transform.position);
			mat.SetVector("_GreenPos", playerGreen.transform.position);
			mat.SetVector("_BluePos", playerBlue.transform.position);
		}
	}
}
