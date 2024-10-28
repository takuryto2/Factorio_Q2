using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit_Data", menuName = "ScriptableObjects/UnitData", order = 1)]
public class SO_Building : ScriptableObject
{
    [Header("Building variable")]
    public string buildingName;
    public float cooldownMultiplier;

    [Header("grid variable")]
    public int sizeX;
    public int sizeY;

    [Header("display and match variable")]
    /*unit display and match variable*/
    public Mesh BuildingMesh;
    public List<ScriptableObject> recipe;
}