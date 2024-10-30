using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class S_Buildings : MonoBehaviour, IPlaceable
{


    protected float CooldownTime;
    public int gridScaleX;
    public int gridScaleZ;
    float _posX;
    float _posZ;
    int _sizeX;
    int _sizeZ;
    [SerializeField] SO_Building _building;
    public int sizeZ { get { return _sizeZ; } set { _sizeZ = value; } }
    public int sizeX { get { return _sizeX; } set { _sizeX = value; } }
    public float X { get { return _posX; } set { _posX = value; } }
    public float Z { get { return _posZ; } set { _posZ = value; } }

    public SO_Building buildingBase { get { return _building; } }


    protected virtual void Start()
    {
        CooldownTime=buildingBase.cooldownMultiplier;
        GetComponent<MeshFilter>().mesh = buildingBase.BuildingMesh;
        sizeX = buildingBase.sizeX;
        sizeZ = buildingBase.sizeZ;
        transform.localScale = new Vector3(sizeX, 1, sizeZ);
        adjustSize(gridScaleX, gridScaleZ);
        X = transform.position.x;
        Z = transform.position.z;
    }

    public void adjustSize(int gridX, int gridZ)
    {
        sizeX *= gridX;
        sizeZ *= gridZ;
        transform.localScale = new Vector3(sizeX, 1, sizeZ);
    }
    public bool VerifySO(SO_Building building)
    {
        if(building==buildingBase) return true;
        return false;
    }





}
