using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class S_Buildings : MonoBehaviour, IPlaceable
{
    [SerializeField] SO_Building buildingBase;
    public abstract int sizeX { get; set; }
    public abstract int sizeZ { get; set; }
    public abstract float X { get; set; }
    public abstract float Z { get; set; }


    protected float CooldownTime;
    public int gridScaleX;
    public int gridScaleZ;



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





}
