using System;
using UnityEngine;

public class FallingScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private KeyCode keyToBePressed;

    private int currentPos;

    private void Update()
    {
        if (Input.GetKeyDown(keyToBePressed)) rb.useGravity = true;
    }

    public void SetCurrentPos(int currentPos)
    {
        this.currentPos = currentPos;
    }
}
