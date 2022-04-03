using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIFactory : MonoBehaviour
{
    public abstract string Name { get; }
    
    public virtual void CreateUI()
    {
        GameObject gmObj = Resources.Load(this.Name) as GameObject;
        Instantiate(gmObj);
        gmObj.transform.position = Vector3.zero;
    }
}
