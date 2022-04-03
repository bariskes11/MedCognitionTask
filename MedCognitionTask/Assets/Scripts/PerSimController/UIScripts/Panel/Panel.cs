using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicEnums;

public class Panel : MonoBehaviour, IPanel
{
    #region Unity Fields
    [SerializeField]
    PanelType panelType;
    [SerializeField]
    int index;
    #endregion
    #region Properties
    public PublicEnums.PanelType PanelType { get => this.panelType; set => this.panelType = value; }
    public int Index { get => index; set => index = value; }
    public string Name { get => this.gameObject.name; set => this.gameObject.name = value; }
    #endregion
    #region Public Methods
    public void SetActive(bool isactive)
    {
        this.SetActive(isactive);
    }
    #endregion

}
