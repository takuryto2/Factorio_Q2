using System.Collections.Generic;
using UnityEngine;

public class S_RessourceSource : MonoBehaviour, IRessources, IPlaceable
{
    [SerializeField]
    SO_Crafts _ressource;

    protected float CooldownTime;
    public int _gridScaleX;
    public int _gridScaleZ;
    float _posX;
    float _posZ;
    int _sizeX;
    int _sizeZ;
    public int sizeZ { get { return _sizeZ; } set { _sizeZ = value; } }
    public int sizeX { get { return _sizeX; } set { _sizeX = value; } }
    public float X { get { return _posX; } set { _posX = value; } }
    public float Z { get { return _posZ; } set { _posZ = value; } }
    public int gridScaleX { get { return _gridScaleX; } set { _gridScaleX = value; } }
    public int gridScaleZ { get { return _gridScaleZ; } set { _gridScaleZ = value; } }
    public SO_Crafts ressourceToMine { get { return _ressource; } }

    public void AdjustSize(int gridX, int gridZ)
    {
        sizeX *= gridX;
        sizeZ *= gridZ;
        transform.localScale = new Vector3(sizeX, 1, sizeZ);
    }

    private void Start()
    {
        X = transform.position.x;
        Z = transform.position.z;
        sizeX = (int)transform.localScale.x;
        sizeZ = (int)transform.localScale.z;
    }
}
