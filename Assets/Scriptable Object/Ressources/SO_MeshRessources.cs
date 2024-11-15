using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeshRessources_Data", menuName = "ScriptableObjects/MeshRessources_Data", order = 3)]
public class SO_MeshRessources : ScriptableObject
{
    [Header("ressources necessary elements")]
    public List<ItemType> acceptedType;
    public MeshFilter mesh;
}
