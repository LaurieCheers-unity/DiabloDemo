using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiabloCharacter : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    TargetPoint myTargetPoint;
    public TargetPoint TargetPointPrefab;
    IDiabloInteractive destination;
    public Animator anim;

    float speedblend;
    public bool HasDestination => destination != null;

    void Update()
    {
        float targetAnimSpeed;
        if (destination != null)
        {
            Vector3 offset = destination.GetPosition() - transform.position;
            offset.y = 0;
            Quaternion facing = Quaternion.LookRotation(offset);
            float oldYaw = transform.eulerAngles.y;
            float newYaw = facing.eulerAngles.y;
            float yawOffset = Mathf.DeltaAngle(oldYaw, newYaw);
            float maxYawSpeed = 15 * 30 * Time.deltaTime;
            yawOffset = Mathf.Clamp(yawOffset, -maxYawSpeed, maxYawSpeed);
            transform.rotation *= Quaternion.Euler(0, yawOffset, 0);

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
            targetAnimSpeed = 6;
        }
        else
        {
            targetAnimSpeed = 0;
        }

        speedblend = Mathf.MoveTowards(speedblend, targetAnimSpeed, Time.deltaTime * 40);
        anim.SetFloat("Speed", speedblend);
    }

    public void SetDestination(IDiabloInteractive newDestination)
    {
        destination = newDestination;
    }

    public void SetTargetPoint(Vector3 targetPosition)
    {
        if(myTargetPoint == null)
        {
            myTargetPoint = GameObject.Instantiate(TargetPointPrefab);
        }
        myTargetPoint.transform.position = targetPosition;
        destination = myTargetPoint;
    }
}
