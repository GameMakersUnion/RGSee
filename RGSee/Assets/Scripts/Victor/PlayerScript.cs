using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour {
    public Manager.PlayerNum playerNum;
    private float radius_ = 3f;
    private Manager.Colors color_;
    private CircleCollider2D circleCollider;

    public float radius { get { return this.radius_; } 
		set { 
			this.radius_ = value; 
			SetRadius(value);
		} 
	}

	//figure out why not exposed in inspector
    public Manager.Colors color { get { return this.color_; } 
		set {
			this.color_ = value; 
			SetColor(value);
		} 
	}


    private new Rigidbody2D rigidbody2D;

    public float speed = 10, deadzone = 0.1f;

	Material canvasMat;

	private void SetRadius (float radius) {
		string name = "_" + playerNum + "Rad";
		canvasMat.SetFloat (name, radius);
	}

	private void SetColor (Manager.Colors color) {
		string name = "_" + playerNum + "Col";
		canvasMat.SetColor (name, Manager.colors[color]);
	}

    // Use this for initialization
    void Start()
    {
		canvasMat = (Material)Resources.Load ("Materials/canvas", typeof(Material));
		SetRadius (radius_);
		SetColor ( (Manager.Colors)playerNum );
    }

    // Update is called once per frame
    void Update()
    {
        int playernum = (int)playerNum + 1;
        string leftright = (playernum % 2 == 1) ? "Left" : "Right";
        string horz = getAxisString("Horizontal", playernum, leftright);
        string vert = getAxisString("Vertical", playernum, leftright);
        //Debug.Log("playernum: " + playernum + "    horz:" + horz + "   vert:" + vert);
        float x = Input.GetAxis(horz) * speed / 100f;
        float y = Input.GetAxis(vert) * speed / 100f;
        if (Mathf.Abs(x) < deadzone) x = 0;
        if (Mathf.Abs(y) < deadzone) y = 0;
        //Debug.Log(x + "   " + y);
        transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
        //Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
		string name1 = "_" + playerNum + "Pos";
		canvasMat.SetVector (name1, transform.position);
    }
    string getAxisString(string axis, int playernum, string leftright)
    {
        return leftright + axis + ((playernum + 1) / 2);
    }
}
