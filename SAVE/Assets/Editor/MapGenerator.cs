using UnityEngine;
using UnityEditor;

public class MapGenerator : ScriptableWizard
{
    [Header("Resolution")]
    [SerializeField]
    private int width = 100;
    [SerializeField]
    private int height = 100;

    [Header("Bricks")]
    [SerializeField]
    private GameObject boundaryBrick;
    [SerializeField]
    private GameObject whateverBrick;

    [Header("Parents")]
    [SerializeField]
    private Transform boundaryParent;

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
                    newBrick.name = "brick-" + j + "-" + k;
                    newBrick.transform.SetParent(boundaryParent);
                    newBrick.transform.localPosition = new Vector3(k, newBrick.transform.localPosition.y, -j);
                }
            }

        }
    }

    
}