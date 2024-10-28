using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingTest : S_Buildings
{
    
    protected override void Start()
    {
        base.Start();
    }
    float _posX;
    float _posZ;
    int _sizeX;
    int _sizeZ;
    public override int sizeZ { get { return _sizeZ; } set { _sizeZ = value; } }       
    public override int sizeX { get { return _sizeX; } set { _sizeX = value; } }
    public override float X { get { return _posX; } set{ _posX = value; } }
    public override float Z { get { return _posZ; } set { _posZ = value; } }

}
