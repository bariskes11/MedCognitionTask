using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;
/// <summary>
/// Main abstract class for Factory system
/// </summary>
public abstract class UIFactory : MonoBehaviour
{
    public abstract string Name { get; }

    public virtual GameObject CreateUI(Transform parent = null)
    {
        GameObject gmObj = Resources.Load(this.Name) as GameObject;
        GameObject gmcreated = Instantiate(gmObj);
        if (parent != null)
        {
            gmcreated.transform.SetParent(parent);
            gmcreated.transform.localScale = Vector3.one;
        }
        gmObj.transform.position = Vector3.zero;

        return gmcreated;
    }
}
