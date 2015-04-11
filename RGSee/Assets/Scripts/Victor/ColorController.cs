using UnityEngine;
using System.Collections;

public class ColorController : MonoBehaviour {
    public Manager.Colors color = Manager.Colors.Red;
    private Material material;

    //public Manager.Colors color { get { return this.color_; } set { this.color_ = value; } }

	// Use this for initialization
	void Start () {
        material = (Material)Resources.Load("Materials/Canvas",typeof (Material));
        
        //1=Red
        if(color == Manager.Colors.Red) {
            material.SetColor("_WispCol1",Manager.colors[Manager.Colors.Red]);
        }
        //2=Green
        if (color == Manager.Colors.Green)
        {
            material.SetColor("_WispCol2", Manager.colors[Manager.Colors.Green]);
        }
        //3=Blue
        if (color == Manager.Colors.Blue)
        {
            material.SetColor("_WispCol3", Manager.colors[Manager.Colors.Blue]);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
