using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static PublicCommons;

public class UIManager : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    Button btnBack;
    #endregion
    #region Fields
    List<IPanel> panels = new List<IPanel>();
    #endregion

    #region  Unity Methods
    private void Start()
    {
        panels = this.GetComponentsInChildren<IPanel>().ToList();
#if UNITY_EDITOR
        if (btnBack == null)
            Debug.Log($"<color=red> THERE IS NO BACK BUTTON ASSIGNED!!</color>");
#endif
        SetCurrentPanel(PanelType.SelectGenderPanel); // activates selected panel
        EventManager.OnSelectedItem.AddListener(SendDataToClient);
        btnBack.onClick.RemoveAllListeners();
        btnBack.onClick.AddListener(ReturnToFirstPanel); // return to first panel on button click
    }
    private void SendDataToClient(PatientGender gender, PatientClinicIssueType clinicIssueType)
    {
        if (clinicIssueType == PatientClinicIssueType.None) // clinicIssue not selected.
        {
            SetCurrentPanel(PanelType.SelectClinicStatePanel);
        }
    }
    #endregion
    #region Private Methods
    void SetCurrentPanel(PanelType panelType)
    {
        this.panels.ForEach(p => p.SetActive(false));
        this.panels.Where(x => x.PanelType == panelType).FirstOrDefault().SetActive(true);
    }


    void ReturnToFirstPanel()
    {
        SetCurrentPanel(PanelType.SelectGenderPanel); // activates selected panel
    }
    #endregion

}
