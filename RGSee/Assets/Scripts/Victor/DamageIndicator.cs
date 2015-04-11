using UnityEngine;
using System.Collections;

public class DamageIndicator : MonoBehaviour {
    public float life = 3f; //The amount of seconds the damage indicator should last
    private float startTime;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, life); //Blow up after a bit
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
