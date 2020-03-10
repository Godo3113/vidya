using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FloatValue inherits from ScriptableObject, meaning than the script cannot be attached to any object
// of the scene (lives out of the scene). The value can be read through multiple scenes.

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver 
{
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }

    public void OnBeforeSerialize(){}

    
}
