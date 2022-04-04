using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

public class UIClinicStateInteraction : ItemInfo
{
    protected override void Start()
    {
        base.Start();
        
    }
    protected override void ItemSelected()
    {
        base.ItemSelected();
        EventManager.OnSelectedItem.Invoke(PatientGender.Male, PatientClinicIssueType.None);

    }
}
