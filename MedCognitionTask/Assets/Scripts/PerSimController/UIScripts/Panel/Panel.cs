using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PublicCommons;

public class Panel : MonoBehaviour, IPanel
{
    #region Unity Fields
    [SerializeField]
    PanelType panelType;
    [SerializeField]
    int index;
    #endregion
    #region Properties
    public PublicCommons.PanelType PanelType { get => this.panelType; set => this.panelType = value; }
    public int Index { get => this.index; set => this.index = value; }
    public string Name { get => this.gameObject.name; set => this.gameObject.name = value; }
    #endregion
    #region Public Methods
    public void SetActive(bool isactive)
    {
        this.gameObject.SetActive(isactive);
    }
    #endregion

}
