using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

public class UIClinicStateInteraction : ItemInfo
{
    
    #region Protected Methods
    protected override void ItemSelected()
    {
        base.ItemSelected();
        EventManager.OnSelectedItem.Invoke(this.patientGender,this.patientClinicIssue);
    }
    #endregion
}
