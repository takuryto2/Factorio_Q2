using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class S_ChangeMode : MonoBehaviour
{
    public GameObject prefab;
    public Action<RaycastHit> modeAction;

    private void Start()
    {
        modeAction = PlaceTile;
    }
    public void ChangeMode(InputAction.CallbackContext ctx)
    {
        if (modeAction != PlaceTile)
        {
            modeAction = PlaceTile;
            return;
        }
        modeAction=RemoveTile;
    }
    public void PlaceTile(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<S_GridManager>(out S_GridManager grid))
        {
            Debug.Log(hit.point);
            grid.CreateTileAtPosition(hit.point, prefab);
            return;
        }
    }
    public void RemoveTile(RaycastHit hit)
    {
        if (!hit.collider.TryGetComponent<S_GridManager>(out S_GridManager grid))
        {
            Destroy(hit.collider.gameObject);
        }
    }

}
