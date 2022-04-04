using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;


public class UIGenderInteraction : ItemInfo
{
    private PatientGender gender;
    protected override void Start()
    {
        base.Start();
    }
    protected override void ItemSelected()
    {
        base.ItemSelected();
        if (this.currentIndex == 1)
            gender = PatientGender.Male;
        else
            gender = PatientGender.Female;
        
        EventManager.OnSelectedItem.Invoke(gender, PatientClinicIssueType.None);
    }
}
