using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour {

    private float radius_ = 3f;
    public Manager.Colors color_ = Manager.Colors.Red;
    private CircleCollider2D circleCollider;

    public float radius { get { return this.radius_; } set { this.radius_ = value; } }
    public Manager.Colors color { get { return this.color_; } set { this.color_ = value; } }

    private Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        if (rigidbody2D == null)
        {
            //rigidbody2D = gameObject.AddComponent< Rigidbody2D> as Rigidbody2D; // Doesn't work
            Debug.Log("You forgot the Circle Collider Component, noob fix plox");
        }
        circleCollider.radius = radius;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
