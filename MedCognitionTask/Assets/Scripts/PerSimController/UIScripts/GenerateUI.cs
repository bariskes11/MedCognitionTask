using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicEnums;

public class GenerateUI : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    PanelText panelText;
    #endregion

    private void Start()
    {
        FactoryGenerator<UIFactory>.InitializeFactoryGenerator();
        UIGenderItem uIGenderItem = FactoryGenerator<UIGenderItem>.CreateObject(ResourceItem.UIGenderItem);
        uIGenderItem.CreateUI();

    }

}
