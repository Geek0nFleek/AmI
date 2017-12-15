using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingScene : MonoBehaviour
{

    void OnCollisionEnter (Collision col)
    {

        if (col.gameObject.name == "trigger")
        {
            //Application.LoadLevel("Elevator");
            
        }
        
    }
}
