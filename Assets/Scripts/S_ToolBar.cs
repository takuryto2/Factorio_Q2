using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class S_ToolBar : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabList = new();
    [SerializeField] List<Image> imageList = new();
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
            for (int i = 0; i <= imageList.Count-1; i++)
            {
                
                if (imageList[i] == imageList[value])
                {
                    Debug.Log(imageList[value]);
                    Debug.Log(imageList[i]);
                    imageList[value].color = new Color(1, 0.92f, 0.13f);
                }
                else 
                {
                    imageList[i].color = Color.white;
                }
            }
        }
    }
}
