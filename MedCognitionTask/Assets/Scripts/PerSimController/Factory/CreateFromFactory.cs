using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicEnums;

public class CreateFromFactory : MonoBehaviour
{
    private void Start()
    {
        FactoryGenerator<UIFactory>.InitializeFactoryGenerator();
    }
    public void CreateUIItem()
    {
        this.CreateFactory(ResourceItem.UIGenderItem);
    }
    private void CreateFactory(ResourceItem name)
    {
        UIFactory rslt = FactoryGenerator<UIFactory>.CreateObject(name);
        rslt.CreateUI();
    }

}
