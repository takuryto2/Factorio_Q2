using UnityEngine;

public class S_BeltBehaviour : MonoBehaviour, IPlaceable
{
    int _sizeX;
    int _sizeZ;
    public int _gridScaleX;
    public int _gridScaleZ;
    float _posX;
    float _posZ;
    Vector3 _direction;
    Quaternion _rotation;
    

    private void Start()
    {
        _direction =transform.forward;

        sizeX = 1;
        sizeZ = 1;
        AdjustSize(gridScaleX, gridScaleZ);
        posX = transform.position.x;
        posZ = transform.position.z;
    }
    public int gridScaleX { get { return _gridScaleX; } set { _gridScaleX = value; } }
    public int gridScaleZ { get { return _gridScaleZ; } set { _gridScaleZ = value; } }
    public float posX { get { return _posX; } set { _posX = value; } }
    public float posZ { get { return _posZ; } set { _posZ = value; } }    
    public int sizeX { get { return _sizeX; } set { _sizeX = value; } }
    public int sizeZ { get { return _sizeZ; } set { _sizeZ = value; } }
    public Vector3 direction { get { return _direction; } private set { _direction = value; } }
    public Quaternion rotation { get { return _rotation; } private set { _rotation = value; } }

    public void AdjustSize(int gridX, int gridZ)
    {
        sizeX *= gridX;
        sizeZ *= gridZ;
        transform.localScale = new Vector3(sizeX*transform.localScale.x, transform.localScale.y, sizeZ * transform.localScale.z);
    }

}
