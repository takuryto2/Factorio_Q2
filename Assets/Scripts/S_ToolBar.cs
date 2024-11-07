using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_ToolBar : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabList = new();
    S_ChangeMode prefabToPlace;

    private void Start()
    {
        prefabToPlace = GetComponent<S_ChangeMode>();
    }
    public void ToolSelect(InputAction.CallbackContext ctx)
    {
        int value = (int)ctx.ReadValue<float>();
        if (ctx.started && value < prefabList.Count)
        {
            prefabToPlace.prefab = prefabList[value];
        }
    }
}
