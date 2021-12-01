using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDiabloInteractive
{
    public Vector3 GetPosition();
    public float GetInteractRange();
    public void Interact(DiabloCharacter interactor);
}
