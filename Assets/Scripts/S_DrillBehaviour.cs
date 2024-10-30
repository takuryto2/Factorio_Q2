using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class S_DrillBehaviour : S_Buildings//, IDriller
{
    ItemType _ressource;
    public ItemType ressourceFound { get { return _ressource; } set { _ressource = value; } }

    //public bool TryFindRessources()
    //{
    //   //List<Collider>colliders = Physics
    //   //     .OverlapBox(transform.position, (new Vector3(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z)))
    //   //     .ToList();
    //   // Collider ressourcesFound = null;
    //   // ressourcesFound=colliders.Where(collider => collider.TryGetComponent<S_Buildings>(out S_Buildings building))
    //   //     .ToList();
    //}
    public List<ItemType> EndHarvesting()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator Harvest()
    {
        throw new System.NotImplementedException();
    }


}
