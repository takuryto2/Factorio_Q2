using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

public class S_GridManager : MonoBehaviour
{
    public static S_GridManager Instance;


    [SerializeField] int Width, Height;
    [SerializeField] Vector3 gridScale=new();
    public List<S_Buildings> tileCreated= new();

    private void Start()
    {
        gameObject.transform.localScale=new Vector3(Width,0.1f,Height);
    }

    /// <summary>
    /// Try to create the specified T building type at the Tile corresponding to the given position
    /// return false if the tile already contains a building, or the prefab is not a building
    /// </summary>
    public bool CreateTileAtPosition(Vector3 _pointerPos, GameObject BuildingPrefab)
    {
        if (BuildingPrefab.TryGetComponent<S_Buildings>(out S_Buildings building))
        {
            var localPointerPos = transform.InverseTransformPoint(_pointerPos);
            Vector3 centerPos = FindCenterOfTile(localPointerPos, building.sizeX, building.sizeY);
            Vector3 centerPosInWorld = transform.TransformPoint(centerPos);
            if (FindTileAtPosition(centerPosInWorld, out S_Buildings tileFound))
            {
                Debug.Log("a tile already exists here");
                return false;
                
            }

            var newBuilding = Instantiate(BuildingPrefab, centerPosInWorld, Quaternion.identity);
            return true;
        }
        Debug.Log("This prefab is not a building");
        return false;

    }
    /// <summary>
    /// find the center of the point corresponding to the tiles taken by size
    /// </summary>
    private Vector3 FindCenterOfTile(Vector3 pos, int sizeX=1, int sizeY=1)
    {
        Vector3 CornerLeft = new Vector3((int)pos.x * gridScale.x, (int)pos.y * gridScale.y, (int)pos.z);
        Vector3 CornerRight = new Vector3((Mathf.CeilToInt(pos.x) * gridScale.x)*sizeX, (Mathf.CeilToInt(pos.y) * gridScale.y)*sizeY, Mathf.CeilToInt(pos.z));
        Vector3 centerPos = CornerLeft + gridScale / 2;
        return centerPos;
    }

    /// <summary>
    /// return true if a building is at the tile corresponding to the position given and return it
    /// </summary>
    public bool FindTileAtPosition(Vector3 pos, out S_Buildings tile)
    {
        tile=null;
        Vector3 centerOfTile = FindCenterOfTile(pos);
        List<Collider> colliders = Physics.OverlapSphere(centerOfTile,gridScale.magnitude/2).ToList();
        foreach (Collider collider in colliders) 
        {
            if (collider.TryGetComponent<S_Buildings>(out S_Buildings tileFound))
            {
                tile = tileFound;
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 
    /// </summary>
}
