using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class S_RessourceBehaviour : MonoBehaviour
{
    Queue<Vector3> allTargetPos= new();
    Vector3 originalPos;
    Vector3 posCheck1;
    Vector3 posCheck2;
    float timer = 0;
    bool isCoroutineRunning=false;
    public ItemType ressourceType=ItemType.IRONORE;
    private void Start()
    {
        StartCoroutine(IsMoving());
    }

    public void SetRessourceValue(ItemType ressourceToSet, Vector3 initialPos)
    {
        Instantiate(gameObject, initialPos, Quaternion.identity);
        ressourceType = ressourceToSet;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<S_BeltBehaviour>(out S_BeltBehaviour belt))
        {
            allTargetPos.Enqueue(belt.transform.position + (belt.direction * 0.8f));
            if (!isCoroutineRunning) { StartCoroutine(SlerpToPos()); }
            return;
        }
        
        if(other.TryGetComponent<S_CrafterBehaviour>(out S_CrafterBehaviour crafter))
        {
            if (crafter.TryStoreRessource(ressourceType))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<S_BeltBehaviour>(out S_BeltBehaviour belt))
        {
            StartCoroutine(IsMoving());
        }
    }
    private IEnumerator SlerpToPos()
    {
        timer = 0;
        isCoroutineRunning = true;
        originalPos = transform.position;
        Vector3 targetPos=allTargetPos.Dequeue();
        while (true)
        {
            transform.position = Vector3.Slerp(originalPos, targetPos, timer);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            
            if (timer > 0.95f)
            {
                timer = 0;

                if (!allTargetPos.TryDequeue(out targetPos)) { break; }

                originalPos = transform.position;
            }
        }
        isCoroutineRunning = false;
        yield return null;
    }

    private IEnumerator IsMoving()
    {
        yield return new WaitForSeconds(2f);
        posCheck1 = gameObject.transform.localPosition;
        yield return new WaitForSeconds(5f);
        posCheck2 = gameObject.transform.localPosition;
        if (posCheck1 == posCheck2)
        {
            Destroy(gameObject);
        }
    }
}
