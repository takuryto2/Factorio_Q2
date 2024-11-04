using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class S_RessourceBehaviour : MonoBehaviour
{
    Queue<Vector3> allTargetPos= new();
    Vector3 originalPos;
    float timer = 0;
    bool isCoroutineRunning=false;


    public void OnTriggerEnter(Collider other)
    {
        S_BeltBehaviour belt = other.GetComponent<S_BeltBehaviour>();
        allTargetPos.Enqueue(belt.transform.position+belt.direction);
        if (!isCoroutineRunning) { StartCoroutine(SlerpToPos()); }
        
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
}
