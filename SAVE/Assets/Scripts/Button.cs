using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Trigger
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "aPlayer" | collider.tag == "NPC")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            TriggerOn();
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "NPC")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            TriggerOn();
        }
    }
}
