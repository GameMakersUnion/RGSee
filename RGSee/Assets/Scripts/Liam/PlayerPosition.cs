using UnityEngine;
using System.Collections.Generic;

public class PlayerPosition : MonoBehaviour
{

    public enum Colors { Red, Blue, Green, Magenta, Cyan, Yellow, White, Black, Gray }
    public Dictionary<Colors, Color> colors = new Dictionary<Colors, Color>()
    {
        { Colors.Red, new Color(1f,0f,0f) },
        { Colors.Green, new Color(0f,1f,0f) },
        { Colors.Blue, new Color(0f,0f,1f) },
        { Colors.Magenta, new Color(1f, 0f, 1f) },
        { Colors.Cyan, new Color(0f, 1f, 1f) },
        { Colors.Yellow, new Color(1f, 1f, 0f) },
        { Colors.White, new Color(1f, 1f, 1f) },
        { Colors.Black, new Color(0f, 0f, 0f) },
        { Colors.Gray, new Color(0.5f, 0.5f, 0.5f) },
    };


    public Material[] materials;
    public GameObject playerRed, playerGreen, playerBlue;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Material mat in materials)
        {
            mat.SetVector("_RedPos", playerRed.transform.position);
            mat.SetVector("_GreenPos", playerGreen.transform.position);
            mat.SetVector("_BluePos", playerBlue.transform.position);
        }
    }
}
