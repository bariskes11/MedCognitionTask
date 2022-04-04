using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Panel", menuName = "Assets/Create/Create Clinic Issues Panel", order = 2)]
public class ClinicPanelData : PanelBase
{
    public List<ClinicIssue> ClinicPanelItems;
}
