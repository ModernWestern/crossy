using System;
using UnityEngine;

public class FroggerPoolObject : FroggerObject
{
    public event Action<FroggerPoolObject> OnInvisible;

    public Vector3 Position
    {
        get => transform.localPosition;

        set => transform.localPosition = value;
    }

    public Quaternion Rotation
    {
        get => transform.localRotation;

        set => transform.localRotation = value;
    }

    public override void OnBecameInvisible()
    {
        transform.position = Vector3.zero;

        OnInvisible?.Invoke(this);
    }

    public void SetActive(bool value)
    {
        transform.position = Vector3.zero;

        gameObject.SetActive(value);
    }
}