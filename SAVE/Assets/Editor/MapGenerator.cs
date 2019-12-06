﻿using UnityEngine;
using UnityEditor;

public enum MapType
{
    Default,
    Boundary,
    Walking,
    Door
}

public class MapGenerator : ScriptableWizard
{
    [Header("Resolution")]
    [SerializeField]
    private int width = 10;
    [SerializeField]
    private int height = 10;

    [Header("Bricks")]
    [SerializeField]
    private GameObject boundaryBrick;
    [SerializeField]
    private GameObject pathBrick;

    [Header("Parents")]
    [SerializeField]
    private Transform boundaryParent;
    [SerializeField]
    private Transform pathParent;

    [Header("BrickParticulars")]
    [Header("Boundary Bricks")]
    [SerializeField]
    private int[] ups = { 0, 0, 1, 4, 5, 6};
    [SerializeField]
    private int[] downs = { 7, 1, 4, 5, 6, 7 };
    [SerializeField]
    private int[] lefts = { 0, 1, 2, 6, 2, 1 };
    [SerializeField]
    private int[] rights = { 1, 7, 7, 7, 7, 7 };


    private MapType[,] map;

    [MenuItem("GameObject/Create Other/Create Map")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Duplicate Prefab", typeof(MapGenerator));
    }

    void OnWizardUpdate()
    {
    }

    UnityEngine.Object duplicatePrefab(UnityEngine.GameObject go)
    {
        // FYI:  Don't need to call this if go is already a prefab:
        //UnityEngine.Object prefab = UnityEditor.PrefabUtility.GetPrefabObject( go );
        return UnityEditor.PrefabUtility.InstantiatePrefab(go);
    }

    void OnWizardCreate()
    {
        map = new MapType[height, width];
        // Create boundary Bricks     
        for (int i = 0; i < ups.Length; i++)
        {
            if (ups[i] > downs[i] | lefts[i] > rights[i]) break;
            for (int j = ups[i]; j < downs[i]; j++)
            {
                for (int k = lefts[i]; k < rights[i]; k++)
                {
                    UnityEngine.Object prefab = duplicatePrefab(boundaryBrick);
                    UnityEngine.GameObject newBrick = (UnityEngine.GameObject)prefab;
                    map[j, k] = MapType.Boundary;
                    newBrick.name = "brick-" + j + "-" + k;
                    newBrick.transform.SetParent(boundaryParent);
                    newBrick.transform.localPosition = new Vector3(k, newBrick.transform.localPosition.y, -j);
                }
            }
        }

        // Create path Bricks
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if(map[i, j] != MapType.Boundary)
                {
                    UnityEngine.Object prefab = duplicatePrefab(pathBrick);
                    UnityEngine.GameObject newBrick = (UnityEngine.GameObject)prefab;
                    map[i, j] = MapType.Walking;
                    newBrick.name = "brick-" + i + "-" + j;
                    newBrick.transform.SetParent(pathParent);
                    newBrick.transform.localPosition = new Vector3(j, newBrick.transform.localPosition.y, -i);
                }
            }
        }
    }

    
}