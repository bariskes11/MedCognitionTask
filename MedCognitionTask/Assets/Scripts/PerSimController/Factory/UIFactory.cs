using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicEnums;

public abstract class UIFactory : MonoBehaviour
{
    public abstract ResourceItem Name { get; }
    
    public virtual void CreateUI()
    {
        GameObject gmObj = Resources.Load(this.Name.ToString()) as GameObject;
        Instantiate(gmObj);
        gmObj.transform.position = Vector3.zero;
    }
}
