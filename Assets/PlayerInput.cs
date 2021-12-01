using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public DiabloCharacter myCharacter;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            IDiabloInteractive clickedObject = hit.collider.GetComponent<IDiabloInteractive>();
            if (clickedObject != null)
            {
                myCharacter.SetDestination(clickedObject);
            }
            else
            {
                myCharacter.SetTargetPoint(hit.point);
            }
        }
    }
}
