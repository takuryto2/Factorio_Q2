using UnityEngine;

public abstract class S_Buildings : MonoBehaviour, IPlaceable
{


    protected float CooldownTime;
    int _sizeX;
    int _sizeZ;
    public int _gridScaleX;
    public int _gridScaleZ;
    float _posX;
    float _posZ;
    [SerializeField] SO_Building _building;
    [SerializeField] protected GameObject _ressourcePrefab;
    protected S_RessourceBehaviour _ressourcePrefabScript;
    protected Vector3 posToSpawnRessources;
    public int gridScaleX { get { return _gridScaleX; } set { _gridScaleX = value; } }
    public int gridScaleZ { get { return _gridScaleZ; } set { _gridScaleZ = value; } }
    public float posX { get { return _posX; } set { _posX = value; } }
    public float posZ { get { return _posZ; } set { _posZ = value; } }
    public int sizeZ { get { return _sizeZ; } set { _sizeZ = value; } }
    public int sizeX { get { return _sizeX; } set { _sizeX = value; } }
    public SO_Building buildingBase { get { return _building; } }

    protected virtual void Start()
    {
        posToSpawnRessources=transform.GetChild(0).position;
        CooldownTime=buildingBase.cooldownMultiplier;
        GetComponent<MeshFilter>().mesh = buildingBase.BuildingMesh;
        sizeX = buildingBase.sizeX;
        sizeZ = buildingBase.sizeZ;
        transform.localScale = new Vector3(sizeX, 1, sizeZ);
        AdjustSize(gridScaleX, gridScaleZ);
        posX = transform.position.x;
        posZ = transform.position.z;
        _ressourcePrefabScript=_ressourcePrefab.GetComponent<S_RessourceBehaviour>();
    }

    public void AdjustSize(int gridX, int gridZ)
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
