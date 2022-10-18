using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode keyToBePressed;
    [SerializeField] private Transform tfPlayer;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material firstPlaceColor;
    [SerializeField] private Material wrongWayColor;
    [SerializeField] private Material normalColor;

    public bool IsDrivingWrongWay = false;

    private int currentPos;

    private void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(keyToBePressed)) tfPlayer.localPosition += new Vector3(0, 0, -0.03f);
        else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(keyToBePressed)) tfPlayer.localPosition += new Vector3(0, 0, 0.03f);

        if (!IsDrivingWrongWay && currentPos == 1) meshRenderer.material = firstPlaceColor;
        else if (!IsDrivingWrongWay && currentPos > 1) meshRenderer.material = normalColor;
        else if (IsDrivingWrongWay) meshRenderer.material = wrongWayColor;
    }

    public void SetCurrentPos(int currentPos)
    {
        this.currentPos = currentPos;
    }
}
