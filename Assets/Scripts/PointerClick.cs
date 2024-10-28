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
        test = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = Camera.main.transform.forward;
        test = test + dir;

        if (Physics.Raycast(test, new Vector3(0,-1,0), out RaycastHit hit, 20))
        {
            

            if (hit.collider.TryGetComponent<S_GridManager>(out S_GridManager grid))
            {
                grid.CreateTileAtPosition(hit.point, aaa);
            }
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(test, dir);
    }

}
