using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_ToolBar : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabList = new();
    PointerClick pointer;

    private void Start()
    {
        pointer = GetComponent<PointerClick>();
    }
    public void ToolSelect(InputAction.CallbackContext ctx)
    {
        int value = (int)ctx.ReadValue<float>();
        if (ctx.started && value < prefabList.Count)
        {
            pointer.prefab = prefabList[value];
        }
    }
}
