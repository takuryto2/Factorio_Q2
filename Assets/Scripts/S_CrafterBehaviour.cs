using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CrafterBehaviour : S_Buildings, ICrafting
{
    protected override void Start()
    {
        base.Start();
    }

    public SO_Crafts recipeSelected;

    public void BeginningCraft(SO_Crafts recipe)
    {
        StartCoroutine(Crafting(recipe));
        return;
    }
    public IEnumerator Crafting(SO_Crafts recipe)
    {
        while (true)
        {
            yield return new WaitForSeconds(recipe.time / CooldownTime);
        }
    }
    public List<ItemType> EndCrafting(SO_Crafts recipe)
    {
        return recipeSelected.outputType;
    }



}
