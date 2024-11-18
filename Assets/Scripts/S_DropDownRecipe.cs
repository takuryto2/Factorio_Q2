using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_DropDownRecipe : MonoBehaviour
{
    TMP_Dropdown dropdown;
    private S_CrafterBehaviour crafterRef;
    private TextMeshProUGUI recipeText;
    List<SO_Crafts> recipeList = new();

    private void Start()
    {
        recipeText =transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        dropdown = transform.GetChild(1).GetComponent<TMP_Dropdown>();
        gameObject.SetActive(false);
        
    }
    public void ChangeDropdownVisibility(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(!gameObject.activeSelf);
                return;
            }
            crafterRef = null;
            Ray mouseRay = new();
            mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(mouseRay, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<S_CrafterBehaviour>(out crafterRef))
                {
                    dropdown.ClearOptions();
                    AddRecipeToDropdown(crafterRef);
                    gameObject.SetActive(!gameObject.activeSelf);

                }
            }
        }
    }
    private void AddRecipeToDropdown(S_CrafterBehaviour crafter)
    {
        recipeList.Clear();
        recipeList.Add(crafter.allRecipe.Find(x=>x==crafter._recipeSelected));
        foreach(SO_Crafts craft in crafter.allRecipe)
        {
            if (!recipeList.Contains(craft))
            {
                recipeList.Add(craft);
            }
        }

        List<string> recipeName = recipeList.ConvertAll<string>(new System.Converter<SO_Crafts, string>((recipe) => recipe.name));   
        dropdown.AddOptions(recipeName);

        recipeText.text = crafter._recipeSelected.name;
    }

    public void GiveRecipe()
    {

        crafterRef._recipeSelected=recipeList[dropdown.value];
        recipeText.text = crafterRef._recipeSelected.name;
        dropdown.RefreshShownValue();


        crafterRef.UpdateRecipeIngredients();
    }
}