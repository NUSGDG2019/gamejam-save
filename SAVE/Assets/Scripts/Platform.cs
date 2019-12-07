using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Activator
{
    [SerializeField]
    private float RaiseTime = 1.0f;
    [SerializeField]
    private float ClearTime = 1.0f;

    private bool isRaising = false;
    private bool isClearing = false;

    private float timeLeft = 0;
    public bool isClear;

    private float localY;

    public void Trigger()
    {
        if (isClear)
        {
            isClear = false;
            TriggerOff();
        }
        else
        {
            isClear = true;
            TriggerOn();
        }
    }

    public override void TriggerOff()
    {
        Raise();
    }

    public override void TriggerOn()
    {
        Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        localY = this.gameObject.transform.localPosition.y;
        if (isClear)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isClearing & timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            resizePlatform(timeLeft / ClearTime);
        }
        else if (isClearing)
        {
            isClearing = false;
            // Hide attached gameObject
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (isRaising & timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            resizePlatform(1 - timeLeft / RaiseTime);
        }
        else if (isClearing)
        {
            isClearing = false;
        }
    }

    public void Clear()
    {
        isClear = true;
        isClearing = true;
        timeLeft = ClearTime;
        this.gameObject.GetComponent<Collider>().enabled = false;
    }

    public void Raise()
    {
        isClear = false;
        isRaising = true;
        timeLeft = RaiseTime;
        this.gameObject.GetComponent<Collider>().enabled = true;
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    void resizePlatform(float TimePercentage)
    {
        // 0 to be open and 1 to be closed
        this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, localY + (TimePercentage - 1), this.gameObject.transform.localPosition.z);
        this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, TimePercentage*2, this.gameObject.transform.localScale.z);
    }
}
