using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.HID;

public class PointerClick : MonoBehaviour
{
    [SerializeField] GameObject aaa;
    Vector3 test;

    Vector3 dir;
    public void OnClick(InputAction.CallbackContext context)
    {
        
        if (context.started)
        {
            Ray mouseRay= Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<S_GridManager>(out S_GridManager grid))
                {
                    grid.CreateTileAtPosition(hit.point, aaa);
                    return;
                }

            }
        }
        
    }
}
