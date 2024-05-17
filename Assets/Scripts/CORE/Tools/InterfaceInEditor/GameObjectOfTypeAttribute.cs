using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectOfTypeAttribute : PropertyAttribute
{
    public Type Type { get;}
    public bool AllowSceneObjects { get;}

    public GameObjectOfTypeAttribute(Type requiredType, bool allowSceneObjects = true)
    {
        Type = requiredType;
        AllowSceneObjects = allowSceneObjects;
    }


}
