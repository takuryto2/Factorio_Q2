using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unity_Data", menuName = "ScriptableObjects/UnityData", order = 1)]
public class SO_Building : ScriptableObject
{
    /*Building particular variable*/
    public string buildingName;
    public float cooldownMultiplier;

    /*grid variable*/
    public int sizeX;
    public int sizeZ;

    /*unit display and match variable*/
    public Mesh BuildingMesh;
    public List<ScriptableObject> recipe;
}