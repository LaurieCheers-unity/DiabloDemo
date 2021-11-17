using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiabloCharacter : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public TargetPoint myTargetPoint;
    IDiabloInteractive destination;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            IDiabloInteractive clickedObject = hit.collider.GetComponent<IDiabloInteractive>();
            if (clickedObject != null)
            {
                destination = clickedObject;
            }
            else
            {
                myTargetPoint.transform.position = hit.point;
                destination = myTargetPoint;
            }
        }

        if (destination != null)
        {
            Vector3 offset = destination.GetPosition() - transform.position;
            if (offset.magnitude < destination.GetInteractRange())
            {
                destination.Interact();
                destination = null;
            }
            else
            {
                Vector3 move = (destination.GetPosition() - transform.position).normalized * speed;
                controller.Move(move * Time.deltaTime);
            }
        }
    }
}
