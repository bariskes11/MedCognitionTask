using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

public class UIGender : UIGenerateBase
{
    #region Unity Fields
    [SerializeField]
    GenderPanelData genderPanelData;
    #endregion
    #region Protected Methods
    protected override void SetUI()
    {
        foreach (var item in this.genderPanelData.GenderPanelItems)
        {
            uiObject = FactoryGenerator<UIFactory>.CreateObject(ResourceItem.UIGenderItem);
            var result = uiObject.CreateUI(this.transform);
            if (result.TryGetComponent<ItemInfo>(out var iteminfo))
            {
                iteminfo.SetItemInfo(item.ItemIndex, item.GenderText, PatientClinicIssueType.None, item.gender);
            }
        }
    }
    #endregion


}
