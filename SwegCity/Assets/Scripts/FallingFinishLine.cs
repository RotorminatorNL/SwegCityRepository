using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class FallingFinishLine : MonoBehaviour
{
    [SerializeField] private LayerMask racerLayer;
    private int racerEntryNumber;

    private void OnTriggerEnter(Collider collider)
    {
        if (racerLayer == (1 << collider.gameObject.layer))
        {
            racerEntryNumber++;
            collider.GetComponent<FallingScript>().SetCurrentPos(racerEntryNumber);
        }
    }
}
