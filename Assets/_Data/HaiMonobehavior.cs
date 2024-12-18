using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaiMonobehavior : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void Start()
    {
        //for overide
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {
        //
    }

    protected virtual void LoadComponents()
    {
        //
    }
    protected virtual void OnEnable()
    {
        //
    }
    protected virtual void OnDisable()
    {
        //
    }
}
