using UnityEngine;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{

    public enum Colors { Red, Blue, Green, Magenta, Cyan, Yellow, White/*, Black, Gray*/ }
    public static Dictionary<Colors, Color> colors = new Dictionary<Colors, Color>()
    {
        { Colors.Red, new Color(1f,0f,0f) },
        { Colors.Green, new Color(0f,1f,0f) },
        { Colors.Blue, new Color(0f,0f,1f) },
        { Colors.Magenta, new Color(1f, 0f, 1f) },
        { Colors.Cyan, new Color(0f, 1f, 1f) },
        { Colors.Yellow, new Color(1f, 1f, 0f) },
        { Colors.White, new Color(1f, 1f, 1f) },
        /*{ Colors.Black, new Color(0f, 0f, 0f) },*/
        /*{ Colors.Gray, new Color(0.5f, 0.5f, 0.5f) },*/
    };

	public GameObject playerRed, playerGreen, playerBlue;
    Material material;
	void Start () {
		material = (Material)Resources.Load ("Materials/Canvas", typeof(Material));
	}
    // Update is called once per frame
    void Update()
    {
    	material.SetVector("_RedPos", playerRed.transform.position);
        material.SetVector("_GreenPos", playerGreen.transform.position);
        material.SetVector("_BluePos", playerBlue.transform.position);
    }
}
