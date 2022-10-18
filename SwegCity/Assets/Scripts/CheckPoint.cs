using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private LayerMask racerLayer;
    [SerializeField] private int checkPointPos;
    public int CheckPointPos { get { return checkPointPos; } }

    private CheckPointManager checkPointManager;

    private void Awake()
    {
        checkPointManager = GetComponentInParent<CheckPointManager>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (racerLayer == (1 << collider.gameObject.layer))
        {
            checkPointManager.UpdateCheckPointInPlayerDataList(collider.GetComponent<Player>(), checkPointPos);
        }
    }
}
