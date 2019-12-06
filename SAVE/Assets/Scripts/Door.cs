using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen;
    public Collider objCol;
    public SpriteRenderer objSpr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (isOpen)
        {
            objCol.enabled = true;
            objSpr.enabled = true;
        } else
        {
            objCol.enabled = false;
            objSpr.enabled = false;
        }
    }
}
