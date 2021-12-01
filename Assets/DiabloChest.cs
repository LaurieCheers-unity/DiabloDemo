using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiabloChest : MonoBehaviour, IDiabloInteractive
{
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Interact(DiabloCharacter interactor)
    {
        GameObject.Destroy(gameObject);
    }

    public float GetInteractRange()
    {
        return 2.0f;
    }
}
