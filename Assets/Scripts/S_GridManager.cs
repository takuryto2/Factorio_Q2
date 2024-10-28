using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;

using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;

public class S_GridManager : MonoBehaviour
{
    public static S_GridManager Instance;


    [SerializeField] int Width, Height;

    // THE SCALE CAN'T BE A FLOAT
    [SerializeField] Vector3Int gridScale = new();

    public List<GameObject> tileCreated = new();

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(Width, 0.1f, Height);
    }

    /// <summary>
    /// Try to create the specified T building type at the Tile corresponding to the given position
    /// return false if the prefab is not a building or if there is not enough space to instantiate it.
    /// </summary>
    public bool CreateTileAtPosition(Vector3 _pointerPos, GameObject BuildingPrefab)
    {
        if (BuildingPrefab.TryGetComponent<S_Buildings>(out S_Buildings building))
        {
            if(FindTileAtPosition(_pointerPos,building.sizeX,building.sizeZ, out GameObject tileFound))
            {
                Debug.Log("Not enough space");
                return false;
            }
            Vector3 centerPos = FindCenterOfTile(_pointerPos, building.sizeX, building.sizeZ);
            
            var newBuilding = Instantiate(BuildingPrefab, centerPos, Quaternion.identity);

            //get the scale of the grid for the Start of the building so it can apply it.
            newBuilding.GetComponent<S_Buildings>().gridScaleX = (int)gridScale.x;
            newBuilding.GetComponent<S_Buildings>().gridScaleZ = (int)gridScale.z;

            tileCreated.Add(newBuilding.gameObject);
            return true;
        }
        Debug.Log("This prefab is not a building");
        return false;

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
        Vector3 centerPos = CornerLeft + (new Vector3(gridScale.x * sizeX, 0, gridScale.z * sizeZ) / 2);
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
        List<Collider> BuildingTouched= Physics.OverlapBox(centerOfTile, (new Vector3(gridScale.x * sizeX, 0, gridScale.z * sizeZ) / 2)).ToList();
        foreach (Collider c in BuildingTouched)
        {
            if(c.TryGetComponent<S_Buildings>(out S_Buildings building))
            {
                Debug.Log("Building Found");
                buildingFound = building.gameObject;
                return true;
            }
        }
        return false;
    }
}
