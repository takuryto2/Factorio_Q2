using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingTest : S_Buildings
{

    [SerializeField] SO_Building buildingBase;
    private void Start()
    {
        _sizeX = buildingBase.sizeX; _sizeY = buildingBase.sizeY;
        X = 0; Y = 0;
        _Cooldown = buildingBase.cooldownMultiplier;
    }
    float _Cooldown;
    int _sizeX;
    int _sizeY;
    float _posX;
    float _posY;
    protected override float CooldownTime { get => _Cooldown; }

    public override int sizeX => _sizeX;

    public override int sizeY => _sizeY;
    public override float X { get => _posX; set => _posX=value; }
    public override float Y { get => _posY; set => _posY = value; }
}
