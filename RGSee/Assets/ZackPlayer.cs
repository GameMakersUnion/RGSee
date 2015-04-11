using UnityEngine;
using System.Collections;

public class ZackPlayer : MonoBehaviour {

    public float speed = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal") * speed / 100f;
        float y = Input.GetAxis("Vertical") * speed / 100f;
        transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
	}
}
