using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PublicCommons
{
    
    public const string anim_MotionSwicher = "MotionSwitcher";
    // Prefab Name for generalresources 
    
    public enum ResourceItem
    {
        UIGenderItem,
        UIClinicalStateItem
    }
    //Panel Types
    public enum PanelType
    {
        SelectGenderPanel,
        SelectClinicStatePanel
    }
    //Gender Selection
    public enum PatientGender
    {
        None,
        Male,
        Female,
    }

    //clinical Issues
    public enum PatientClinicIssueType
    {
        None,
        ModerateRespiratoryDistress,
        SevereRespiratoryDistressOne,
        ChestPainThree,
        SevereRespiratoryDistessTwo,
        CoughtingWithHands,
    }
}
