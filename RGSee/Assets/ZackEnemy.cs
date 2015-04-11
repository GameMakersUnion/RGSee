using UnityEngine;
using System.Collections;

public class ZackEnemy : MonoBehaviour {
    private GameObject player;
    public float speed = 10f;
    private Color color;
    float timer = 0f;
    Vector2 vel = Vector2.zero;
    float amp = 1f;
    float period = 20f;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        color = Color.red;
        var r = GetComponent<SpriteRenderer>();
        r.color = color;
        amp = Random.Range(0.5f, 2f);
        period = Random.Range(1f, 4f);
        Debug.Log("amp: " + amp + ", period: " + period);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Vector2 dir = player.transform.position - transform.position;
        float angle = amp * Mathf.Cos(timer*period);
        dir = dir.Rotate(angle);
        //float dist = dir.magnitude;
        transform.position = transform.position + (dir.normalized * speed / 100f).ToVector3();
    }

}
