using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialRessources_Data", menuName = "ScriptableObjects/MaterialRessources_Data", order = 4)]
public class SO_RessourceType : ScriptableObject
{
    [Header("ressources necessary elements")]
    public List<ItemType> acceptedType;
    public Material material;
}
