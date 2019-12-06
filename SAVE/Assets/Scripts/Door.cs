using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activator
{
    public bool isOpen;
    public CameraFollow mainCamera;
    void Start()
    {
        mainCamera = Camera.main.GetComponent<CameraFollow>();
        if (isOpen)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
        } else
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trigger()
    {
        if (isOpen)
        {
            isOpen = false;
            TriggerOff();
        } else
        {
            isOpen = true;
            TriggerOn();
        }
    }

    public override void TriggerOn()
    {
        // Hide attached gameObject
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<Collider>().enabled = false;
    }

    public override void TriggerOff()
    {
        // Hide attached gameObject
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<Collider>().enabled = true;
    }
}
