using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed = 3;
    public bool onFloor = true;
    public List<bool> doorStates = new List<bool>();
    public GameObject doors;

    // Use this for initialization
    void Start()
    {

    }

    //Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("o"))
        {
            saveState();
        } else if (Input.GetKey("p"))
        {
            loadState();
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w"))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        }
        else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("s"))
        {
            transform.position -= transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            transform.position -= transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }
    }

    public void saveState()
    {
        doorStates.Clear();
        foreach (Transform child in doors.transform)
        {
            doorStates.Add(child.GetComponent<Door>().isOpen);
        }

    }

    public void loadState()
    {
        for (int i = 0; i < doorStates.Count; ++i)
        {

            Debug.Log(i);
            Door doorScript = doors.transform.GetChild(i).GetComponent<Door>();
            
            if (doorScript.isOpen && !doorStates[i])
            {
                doorScript.Trigger();
            } else if (!doorScript.isOpen && doorStates[i])
            {
                doorScript.Trigger();
            }
        }
        doorStates.Clear();
    }

}