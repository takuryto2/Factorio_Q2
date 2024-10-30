using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDriller
{
    ItemType ressourceFound{ get; set; }
    bool TryFindRessources();
    IEnumerator Harvest();

    List<ItemType> EndHarvesting();

}
