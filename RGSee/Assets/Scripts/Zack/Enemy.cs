using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
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
    private bool red,green,blue;
    private List<Manager.Colors> attackers;

    // Use this for initialization
    void Start()
    {
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

        
      
            if (red && blue && green && color == Manager.Colors.White)
                Destroy(gameObject);
            else if(red && blue && color == Manager.Colors.Magenta)
                Destroy(gameObject);
            else if(green && blue && color == Manager.Colors.Cyan)
                Destroy(gameObject);
            else if (red && green && color == Manager.Colors.Yellow)
                Destroy(gameObject);
        else
        {
            switch (color)
            {
                case Manager.Colors.Red:
                    if (red == true)
                        Destroy(gameObject);
                    break;
                case Manager.Colors.Green:
                    if (green == true)
                        Destroy(gameObject);
                    break;
                case Manager.Colors.Blue:
                    if (blue == true)
                        Destroy(gameObject);
                    break;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Manager.Colors other = col.gameObject.GetComponent<PlayerScript>().color;
            switch (other)
            {
                case Manager.Colors.Red:
                    red = true;
                    break;
                case Manager.Colors.Green:
                    green = true;
                    break;
                case Manager.Colors.Blue:
                    blue = true;
                    break;
            }
            
          
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {

        Manager.Colors other = col.gameObject.GetComponent<PlayerScript>().color;
        switch (other)
        {
            case Manager.Colors.Red:
                red = false;
                break;
            case Manager.Colors.Green:
                green = false;
                break;
            case Manager.Colors.Blue:
                blue = false;
                break;
        }

    }
}
