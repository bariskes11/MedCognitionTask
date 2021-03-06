using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

public interface IPanel
{
    PanelType PanelType { get; set; }
    int Index { get; set; }
    string Name { get; set; }
    void SetActive(bool isactive);
}
