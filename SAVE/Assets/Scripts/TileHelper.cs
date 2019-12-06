using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream

public class TileHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
=======
using System.IO;

public enum MapType
{
    Boundary,
    Walking,
    Door
}
public class TileHelper : MonoBehaviour
{
    [SerializeField]
    private int width = 32;
    [SerializeField]
    private int height = 18;
    [SerializeField]
    private Button tileButton;
    [SerializeField]
    private Asset TextToWrite;

    private 
    // Start is called before the first frame update
    void Start()
    {
        for(int i )
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
