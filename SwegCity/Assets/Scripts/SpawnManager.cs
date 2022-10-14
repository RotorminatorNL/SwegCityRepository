using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnParent;
    [SerializeField] private GameObject spawnablePrefab;

    private void Start()
    {
        Instantiate(spawnablePrefab, spawnParent.transform);
    }
}
