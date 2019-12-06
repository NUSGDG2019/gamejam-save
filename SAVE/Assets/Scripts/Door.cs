using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activator
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void TriggerOn()
    {
        // Hide attached gameObject
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    public override void TriggerOff()
    {
        // Hide attached gameObject
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
