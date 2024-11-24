using UnityEngine;
using UnityEngine.InputSystem;

public class S_Rotate : MonoBehaviour
{
    public void RotatePrefab(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            
            gameObject.GetComponent<S_ChangeMode>().arrowPreview.transform.Rotate(0,90,0);
        }
    }
}
