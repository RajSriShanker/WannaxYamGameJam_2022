using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRuneSelection : MonoBehaviour
{
    public int playerRune;

    public int conveyorRune;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Player Rune is {playerRune} and Conveyor Rune is {conveyorRune}");
    }
}
