using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingMonsterAI : MonoBehaviour
{
    public DiabloCharacter myCharacter;
    Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        if(!myCharacter.HasDestination)
        {
            Vector3 currentPos = transform.position;
            myCharacter.SetTargetPoint(new Vector3(startingPos.x + Random.Range(-5, 5), startingPos.y, startingPos.z + Random.Range(-5, 5)));
        }
    }
}
