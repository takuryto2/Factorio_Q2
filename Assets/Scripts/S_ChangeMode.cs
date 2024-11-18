using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class S_ChangeMode : MonoBehaviour
{
    public GameObject prefab;
    public Action<RaycastHit> modeAction;
    [SerializeField]private Image destroyImage;
    [SerializeField] private Image buildImage;
    [SerializeField]
    public GameObject arrowPreview;

    private void Start()
    {
        modeAction = NeutralMode;
    }
    public void DestroyMode(InputAction.CallbackContext ctx)
    {
        if (modeAction == RemoveTile)
        {
            arrowPreview.SetActive(false);
            destroyImage.color = Color.white;
            modeAction = NeutralMode;

            return;
        }
        arrowPreview.SetActive(false);
        modeAction =RemoveTile;
        buildImage.color = Color.white;
        destroyImage.color = new Color(1, 0.92f, 0.13f);
    }
    public void BuildMode(InputAction.CallbackContext ctx)
    {
        if (modeAction == PlaceTile)
        {
            arrowPreview.SetActive(false);
            buildImage.color = Color.white;
            modeAction = NeutralMode;
            
            return;
        }
        arrowPreview.SetActive(true);
        modeAction = PlaceTile;
        destroyImage.color = Color.white;
        buildImage.color = new Color(0.72f, 0.85f, 0.96f); 
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
    private void NeutralMode(RaycastHit hit)
    {
        return;
    }
}
