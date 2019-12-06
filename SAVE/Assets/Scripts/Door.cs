using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activator
{
    [SerializeField]
    private float CloseTime = 1.0f;
    [SerializeField]
    private float OpenTime = 1.0f;

    private bool isOpening = false;
    private bool isClosing = false;

    private float timeLeft = 0;
    public bool isOpen;

    private float localZ;

    void Start()
    {
        localZ = this.gameObject.transform.localPosition.z;
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
        if (isOpening & timeLeft > 0)
        {             
            timeLeft -= Time.deltaTime;
            resizeDoor(timeLeft / OpenTime);
        } else if(isOpening)
        {
            isOpening = false;
            // Hide attached gameObject
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;   
        }
        else if(isClosing & timeLeft > 0) 
        {
            timeLeft -= Time.deltaTime;      
            resizeDoor(1 - timeLeft / CloseTime);
        } else if(isClosing)
        {
            isClosing = false;
        }
    }

    public void Trigger()
    {
        Debug.Log("Trigger");
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
        Open();
    }

    public override void TriggerOff()
    {
        Close();
    }

    public void Open()
    {
        isOpen = true;
        isOpening = true;
        timeLeft = OpenTime;
        this.gameObject.GetComponent<Collider>().enabled = false;
    }

    public void Close()
    {
        isOpen = false;
        isClosing = true;
        timeLeft = CloseTime;
        this.gameObject.GetComponent<Collider>().enabled = true;
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    void resizeDoor(float TimePercentage)
    {
        // 0 to be open and 1 to be closed
        this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y, localZ + (TimePercentage - 1) * 0.5f);
        this.gameObject.transform.localScale = new Vector3(TimePercentage, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
    }
}
