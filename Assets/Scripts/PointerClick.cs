using UnityEngine;
using UnityEngine.InputSystem;

public class PointerClick : MonoBehaviour
{
    public GameObject prefab;
    Vector3 test;

    Vector3 dir;
    public void OnClick(InputAction.CallbackContext context)
    {
        
        if (context.started)
        {
            Ray mouseRay= new();
            mouseRay= Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<S_GridManager>(out S_GridManager grid))
                {
                    Debug.Log(hit.point);
                    grid.CreateTileAtPosition(hit.point, prefab);
                    return;
                }

            }
        }
    }
    
}
