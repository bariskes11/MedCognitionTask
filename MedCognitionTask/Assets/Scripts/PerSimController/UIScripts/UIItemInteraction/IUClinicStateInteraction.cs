﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicEnums;

public class IUClinicStateInteraction : ItemInfo
{
    protected override void Start()
    {
        base.Start();
        
    }
    protected override void ItemSelected()
    {
        base.ItemSelected();
        EventManager.OnSelectedItem.Invoke(this.currentIndex, PanelType.SelectGenderPanel);

    }
}