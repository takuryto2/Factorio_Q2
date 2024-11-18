using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Craft_Data", menuName = "ScriptableObjects/Craft_Data", order = 2)]
public class SO_Crafts : ScriptableObject
{
    [Header("craft values")]
    public List<ItemType> inputType;
    public List<int> inputInt;
    public List<ItemType> outputType;
    public List<int> outputInt;
    public float time; //in seconds
}
