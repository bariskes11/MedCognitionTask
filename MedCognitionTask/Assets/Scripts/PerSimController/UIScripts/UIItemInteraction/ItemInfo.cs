using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static PublicCommons;

public abstract class ItemInfo : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    TextMeshProUGUI txtNumber;
    [SerializeField]
    TextMeshProUGUI txtItemtext;
    [SerializeField]
    Button btnItem;
    #endregion
    #region Fields
    protected int currentIndex;
    protected PatientClinicIssueType patientClinicIssue;
    protected PatientGender patientGender;
    #endregion

    #region Public Methods
    /// <summary>
    /// Set Item Info
    /// </summary>
    /// <param name="txtNumber"></param>
    /// <param name="itemtext"></param>
    public void SetItemInfo(int index, string itemtext,PatientClinicIssueType clinicissue,PatientGender gender)
    {
        this.currentIndex = index;
        this.txtNumber.text = index.ToString();
        this.txtItemtext.text = itemtext;
        this.patientGender = gender;
        this.patientClinicIssue = clinicissue;
    }
    #endregion
    #region Unity Methods
    protected virtual void Start()
    {
        btnItem.onClick.RemoveAllListeners();
        btnItem.onClick.AddListener(ItemSelected);
    }
    #endregion
    #region  Protected  Methods
    protected virtual void ItemSelected()
    {
#if UNITY_EDITOR    
        Debug.Log($"Selected Item All INfo {this.currentIndex} {this.patientGender} {this.patientClinicIssue}");
#endif
    }
    #endregion



}
