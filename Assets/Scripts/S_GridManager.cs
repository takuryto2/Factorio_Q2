using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class S_GridManager : MonoBehaviour
{
    public static S_GridManager Instance;


    [SerializeField] int Width, height;

    // THE SCALE CAN'T BE A FLOAT
    [SerializeField] Vector3Int gridScale = new();

    public List<GameObject> tileCreated = new();

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(Width, 0.1f, height);
    }

    /// <summary>
    /// Try to create the specified T building type at the Tile corresponding to the given position
    /// return false if the prefab is not a building or if there is not enough space to instantiate it.
    /// </summary>
    public bool CreateTileAtPosition(Vector3 _pointerPos, GameObject _objectPrefab)
    {
        if (!_objectPrefab.TryGetComponent<IPlaceable>(out IPlaceable _objectToPlace))
        {
            return false;
        }
        int SizeX=0;
        int SizeZ=0;
        if (_objectToPlace is S_Buildings)
        {
            SizeX = (_objectToPlace as S_Buildings).buildingBase.sizeX;
            SizeZ = (_objectToPlace as S_Buildings).buildingBase.sizeZ;
        }
        else if (_objectToPlace is S_BeltBehaviour)
        {
            SizeX = 1;
            SizeZ = 1;
        }
        if (SizeX == 0 || SizeZ == 0)
        {
            return false;
        }
        if (FindTileAtPosition(_pointerPos, SizeX, SizeZ, out GameObject tileFound) )
        {
            return false;
        }
        


            Vector3 centerPos = FindCenterOfTile(_pointerPos, SizeX, SizeZ);
            centerPos.y = centerPos.y+ _objectPrefab.transform.localScale.y / 2;

        var newBuilding = Instantiate(_objectPrefab, centerPos, _objectPrefab.transform.rotation);
        //get the scale of the grid for the Start of the building so it can apply it.
        newBuilding.GetComponent<IPlaceable>().gridScaleX = (int)gridScale.x;
        newBuilding.GetComponent<IPlaceable>().gridScaleZ = (int)gridScale.z;

        tileCreated.Add(newBuilding.gameObject);

        return true;
    }
    /// <summary>
    /// find the point corresponding to the center of the building in the grid by his size
    /// </summary>
    private Vector3 FindCenterOfTile(Vector3 pos, int sizeX = 1, int sizeZ = 1)
    {
        //get the down left corner of the tile by getting the closest smallest integer of the the X and Z
        Vector3 CornerLeft = new Vector3((Mathf.FloorToInt(pos.x)), 0, (Mathf.FloorToInt(pos.z)));

        // calculate the center by applying the gridScale and the size of the building to the down left corner,
        // returning half the diagonal of the tile : the center of it.
        Vector3 centerPos = new();
        centerPos = CornerLeft + (new Vector3(gridScale.x * sizeX, 0, gridScale.z * sizeZ)) / 2;
        return centerPos;
    }


    /// <summary>
    /// return true if a building is in the space of another one and return it.
    /// the Size parameters are the size we want to take to verify if there is nothing in it.
    /// </summary>
    public bool FindTileAtPosition(Vector3 buildingPos, int sizeX, int sizeZ, out GameObject buildingFound)
    {
        buildingFound = null;
        Vector3 centerOfTile = FindCenterOfTile(buildingPos, sizeX, sizeZ);
        List<Collider> BuildingTouched = Physics.OverlapBox(centerOfTile, ((new Vector3(gridScale.x * sizeX, 0, gridScale.z * sizeZ) / 2) * 0.8f)).ToList();
        Collider Found = null;
        BuildingTouched = BuildingTouched
            .Where(collider => collider.TryGetComponent<S_Buildings>(out S_Buildings building))
            .ToList();
    
        if (BuildingTouched.Count>0)
        {
            Found= BuildingTouched.First();
        }
        
        if (Found == null) { return false; }

        buildingFound =Found.gameObject;
        return true;
    }
    public Vector3 AdjustToTile(Vector3 pos)
    {
        return FindCenterOfTile(pos);
    }
}
