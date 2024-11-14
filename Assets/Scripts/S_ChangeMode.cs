using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class S_ChangeMode : MonoBehaviour
{
    public GameObject prefab;
    public Action<RaycastHit> modeAction;
    [SerializeField]private Image image;

    private void Start()
    {
        modeAction = PlaceTile;
    }
    public void ChangeMode(InputAction.CallbackContext ctx)
    {
        if (modeAction != PlaceTile)
        {
            modeAction = PlaceTile;
            image.color = Color.white;
            return;
        }
        modeAction=RemoveTile;
        image.color = new Color(1, 0.92f, 0.13f);
    }

    private void PlaceTile(RaycastHit hit)
    {
        if (hit.collider.TryGetComponent<S_GridManager>(out S_GridManager grid))
        {
            Debug.Log(hit.point);
            grid.CreateTileAtPosition(hit.point, prefab);
            return;
        }
    }

    private void RemoveTile(RaycastHit hit)
    {
        if (!hit.collider.TryGetComponent<S_GridManager>(out S_GridManager grid))
        {
            Destroy(hit.collider.gameObject);
        }
    }
}
