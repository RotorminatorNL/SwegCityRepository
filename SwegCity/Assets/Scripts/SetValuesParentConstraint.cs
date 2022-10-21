using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SetValuesParentConstraint : MonoBehaviour
{
    [SerializeField] private float extraOffsetX;
    [SerializeField] private float extraOffsetZ;
    [SerializeField] private Transform checkpointTransform;
    private Transform parentTransform;
    private ParentConstraint parentConstraint;

    private void Awake()
    {
        parentTransform = gameObject.transform.parent;
        parentConstraint = GetComponent<ParentConstraint>();
    }

    private void Update()
    {
        SetRotationOffset();
        SetTranslationOffset();
    }

    private void SetRotationOffset()
    {
        float newRotationOffsetX = checkpointTransform.localEulerAngles.y - parentTransform.localEulerAngles.y;
        Vector3 newRotationOffset = new Vector3(0, newRotationOffsetX, 0);
        parentConstraint.SetRotationOffset(0, newRotationOffset);
    }

    private void SetTranslationOffset()
    {
        float newTranslationOffsetX = extraOffsetX * GetRotationDifferencePercent();
        Vector3 newTranslationOffset = new Vector3(newTranslationOffsetX, 0, 0);
        parentConstraint.SetTranslationOffset(0, newTranslationOffset);
    }

    private float GetRotationDifferencePercent()
    {
        float actualDifference = Mathf.Abs(checkpointTransform.localEulerAngles.y - parentTransform.localEulerAngles.y);
        float neededDifference = actualDifference;
        float differencePercent = 0f;
        if (neededDifference >= 0 && neededDifference <= 90) differencePercent = 1 - (neededDifference / 90);
        if (neededDifference >= 90 && neededDifference <= 180) differencePercent = 0 - ((neededDifference - 90) / 90);
        if (neededDifference >= 180 && neededDifference <= 270) differencePercent = 1 - ((neededDifference - 180) / 90);
        if (neededDifference >= 270 && neededDifference <= float.MaxValue) differencePercent = 0 - ((neededDifference - 270) / 90);
        print(actualDifference + " " + differencePercent);
        return differencePercent;
    }
}
