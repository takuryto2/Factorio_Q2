using System.Collections.Generic;
using UnityEngine;

public class S_RessourceSource : MonoBehaviour, IRessources, IPlaceable
{
    [SerializeField]
    List<ItemType> _ressource;


    float _posX;
    float _posZ;
    int _sizeX;
    int _sizeZ;
    public int sizeZ { get { return _sizeZ; } set { _sizeZ = value; } }
    public int sizeX { get { return _sizeX; } set { _sizeX = value; } }
    public float X { get { return _posX; } set { _posX = value; } }
    public float Z { get { return _posZ; } set { _posZ = value; } }

    public List<ItemType> ressourceToMine { get { return _ressource; } }
    private void Start()
    {
        X = transform.position.x;
        Z = transform.position.z;
        sizeX = (int)transform.localScale.x;
        sizeZ = (int)transform.localScale.z;
    }
}
