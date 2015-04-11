using UnityEngine;
using System.Collections;

public class ZackEnemy : MonoBehaviour {
    private GameObject player;
    public float speed = 10f;
    private Color color;
    float timer = 0f;
    Vector2 vel = Vector2.zero;
    float amp = 1f;
    public float maxAmp = 2f;
    public float minAmp = 0.5f;
    float period = 20f;
    private Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        color = Color.red;
        var r = GetComponent<SpriteRenderer>();
        r.color = color;
        amp = Random.Range(minAmp, maxAmp);
        period = Random.Range(1f, 4f);
        Debug.Log("amp: " + amp + ", period: " + period);
        rigidbody2D = GetComponent<Rigidbody2D>();
		if (rigidbody2D == null) {
            //rigidbody2D = gameObject.AddComponent< Rigidbody2D> as Rigidbody2D; // Doesn't work
            Debug.Log("You forgot the Rigidbody2d Component, noob fix plox");
        }
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Vector2 dir = player.transform.position - transform.position;
        float angle = amp * Mathf.Cos(timer*period);
        dir = dir.Rotate(angle);
        //float dist = dir.magnitude;
        if(rigidbody2D != null) {
            //rigidbody2D.AddForce(dir.normalized * speed / 100f);
            rigidbody2D.velocity = (dir.normalized * speed / 100f);
        }
        //transform.position = transform.position + (dir.normalized * speed / 100f).ToVector3();
    }

}
