using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    private GameObject home;
    public float speed = 10f;
    public Manager.Colors color;
    float timer = 0f;
    Vector2 vel = Vector2.zero;
    float amp = 1f;
    public float maxAmp = 2f;
    public float minAmp = 0.5f;
    float period = 20f;
    private Rigidbody2D rigidbody2D;
    private bool red, green, blue;
    private List<Manager.Colors> attackers;
    GameObject[] players;

    // Use this for initialization
    void Start()
    {
        players = new GameObject[] {
            GameObject.Find("Player0"),
            GameObject.Find("Player1"),
            GameObject.Find("Player2")
        };
        home = GameObject.Find("Home");
        var r = GetComponent<SpriteRenderer>();
        color = (Manager.Colors)Random.Range(0, System.Enum.GetValues(typeof(Manager.Colors)).Length);
        r.color = Manager.colors[color];
        amp = Random.Range(minAmp, maxAmp);
        period = Random.Range(1f, 4f);

        rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D == null)
        {
            //rigidbody2D = gameObject.AddComponent< Rigidbody2D> as Rigidbody2D; // Doesn't work
            Debug.Log("You forgot the Rigidbody2d Component, noob fix plox");
        }
        attackers = new List<Manager.Colors>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector2 dir = home.transform.position - transform.position;
        float angle = amp * Mathf.Cos(timer * period);
        dir = dir.Rotate(angle);
        //float dist = dir.magnitude;
        if (rigidbody2D != null)
        {
            //rigidbody2D.AddForce(dir.normalized * speed / 100f);
            rigidbody2D.velocity = (dir.normalized * speed / 100f);
        }
        //transform.position = transform.position + (dir.normalized * speed / 100f).ToVector3();

        Color finalColor = new Color(0, 0, 0);
        float redDist = (transform.position - players[0].transform.position).magnitude;
        float greenDist = (transform.position - players[1].transform.position).magnitude;
        float blueDist = (transform.position - players[2].transform.position).magnitude;
        float rad = 3f;
        if (redDist <= rad)
        {
            finalColor += Manager.colors[Manager.Colors.Red];
        }
        if (greenDist <= rad)
        {
            finalColor += Manager.colors[Manager.Colors.Green];
        }
        if (blueDist <= rad)
        {
            finalColor += Manager.colors[Manager.Colors.Blue];
        }
        finalColor.a = 1;
        Debug.Log(finalColor);
        if (Manager.colors[color] == finalColor)
        {
            Destroy(gameObject);
        }
    }
}
