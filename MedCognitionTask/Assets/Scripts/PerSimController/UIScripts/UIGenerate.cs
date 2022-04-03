using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static PublicEnums;

public class UIGenerate : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    TextMeshProUGUI txtHeader;
    [SerializeField]
    PanelUIInfo panelUIInfo;
    [SerializeField]
    Transform parentTransform;
    #endregion
    #region Fields
    UIFactory uiObject;
    #endregion

    private void Start()
    {
        FactoryGenerator<UIFactory>.InitializeFactoryGenerator();

        SetUI();
    }

    private void SetUI()
    {
        txtHeader.text = this.panelUIInfo.PanelHeader;
        int index = 1; // starts from one as Items starts from one
        foreach (var item in this.panelUIInfo.PanelItemList)
        {
            uiObject = FactoryGenerator<UIFactory>.CreateObject(ResourceItem.UIGenderItem);
           var result=  uiObject.CreateUI(this.parentTransform);
            if (result.TryGetComponent<ItemInfo>(out var iteminfo))
            {
                iteminfo.SetItemInfo(index,item);
                index++;
            }
        }
    }
}
