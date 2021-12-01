using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour, IDiabloInteractive
{
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Interact()
    {
    }

    public float GetInteractRange()
    {
        return 0.1f;
    }
}
