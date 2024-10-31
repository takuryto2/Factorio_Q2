using System.Collections.Generic;
using UnityEngine;

public class S_RessourceSource : MonoBehaviour, IRessources, IPlaceable
{
    [SerializeField]
    SO_Crafts _ressource;

    public float X { get { return X; } set { X = value; } }
    public float Z { get { return Z; } set { Z = value; } }
    public int sizeX { get { return sizeX; } private set { sizeX = value; } }
    public int sizeZ { get { return sizeX; } private set { sizeX = value; } }
    public int gridScaleX { get { return gridScaleX; } set { gridScaleX = value; } }
    public int gridScaleZ { get { return gridScaleZ; } set { gridScaleZ = value; } }
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
