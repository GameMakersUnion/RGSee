using UnityEngine;
using System.Collections.Generic;


public class Player : MonoBehaviour
{

    public enum Players { Player1, Player2, Player3, Player4 }
    public Players PlayerNum;
    public bool halfController = true;

    private enum Actions_ { Fire1, Fire2, Fire3, Jump, Submit, Cancel };
    private Dictionary<Actions_, bool> actionState_ = new Dictionary<Actions_, bool>()
    {
        {Actions_.Fire1, false },
        {Actions_.Fire2, false },
        {Actions_.Fire3, false },
        {Actions_.Jump, false },
        {Actions_.Submit, false },
        {Actions_.Cancel, false }
    };
    private int actionsSize_ = System.Enum.GetValues(typeof(Actions_)).Length;


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var actions = System.Enum.GetValues(typeof(Actions_));
        foreach (Actions_ action in actions)
        {
            bool actionPressed = Input.GetButton(action.ToString());
            if (actionPressed)
            {
                actionState_[action] = true;
                Debug.Log( action.ToString() );
            }
        }

        
    }
}
