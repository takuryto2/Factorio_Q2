using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class S_Buildings : MonoBehaviour, IPlaceable
{
    public abstract int sizeX { get;}
    public abstract int sizeY { get;}
    public abstract float X { get; set; }
    public abstract float Y { get; set; }
    protected abstract float CooldownTime { get;}



    
}
