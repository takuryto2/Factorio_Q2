using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Craft_Data", menuName = "ScriptableObjects/Craft_Data", order = 2)]
public class SO_Crafts : ScriptableObject
{
    [Header("craft values")]
    public List<string> inputName;
    public List<float> inputFloat;
    public List<string> outputName;
    public List<float> outputFloat;
    public float time; //in seconds
}
