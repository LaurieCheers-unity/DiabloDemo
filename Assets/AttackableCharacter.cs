using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableCharacter : MonoBehaviour, IDiabloInteractive
{
    public float GetInteractRange()
    {
        return 2.0f;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void Interact(DiabloCharacter interactor)
    {
        GetComponent<DiabloCharacter>().SetTargetPoint(interactor.transform.position);
    }
}
