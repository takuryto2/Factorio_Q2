using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_Rotate : MonoBehaviour
{
    public void RotatePrefab(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            gameObject.GetComponent<S_ChangeMode>().prefab.transform.Rotate(new Vector3(0, 90, 0));
        }
    }
}
