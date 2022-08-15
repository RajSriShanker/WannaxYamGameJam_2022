using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerRuneSelection playerRuneSelectionScript;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RuneMatch()
    {
        if (playerRuneSelectionScript.conveyorRune == playerRuneSelectionScript.playerRune)
        {
            Debug.Log("1 Point");
        }
        else
        { 
            Debug.Log("Miss");
        }
    }
}
