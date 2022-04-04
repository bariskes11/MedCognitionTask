using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

public class UIClinicIssue : UIGenerateBase
{
    #region Unity Fields
    [SerializeField]
    ClinicPanelData clinicPanelData;
    #endregion
    #region Protected Methods
    protected override void SetUI()
    {
        foreach (var item in this.clinicPanelData.ClinicPanelItems)
        {
            uiObject = FactoryGenerator<UIFactory>.CreateObject(ResourceItem.UIClinicalStateItem);
            var result = uiObject.CreateUI(this.transform);
            if (result.TryGetComponent<ItemInfo>(out var iteminfo))
            {
                iteminfo.SetItemInfo(item.ItemIndex, item.ItemText, item.ClinicIssueType, PatientGender.None);
            }
        }
    }
}

