using UnityEngine;
using UnityEngine.InputSystem;

public class S_Rotate : MonoBehaviour
{
    public void RotatePrefab(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            gameObject.GetComponent<S_ChangeMode>().prefab.transform.Rotate(new Vector3(0, 90, 0));
            gameObject.GetComponent<S_ChangeMode>().arrowPreview.transform.rotation = gameObject.GetComponent<S_ChangeMode>().prefab.transform.rotation;
        }
    }
}
