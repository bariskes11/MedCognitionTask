using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    #endregion

    #region Public Methods
    /// <summary>
    /// Set Item Info
    /// </summary>
    /// <param name="txtNumber"></param>
    /// <param name="itemtext"></param>
    public void SetItemInfo(int index, string itemtext)
    {
        this.currentIndex = index;
        this.txtNumber.text = index.ToString();
        this.txtItemtext.text = itemtext;
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
        Debug.Log($"Clicked On Item {this.currentIndex} {this.txtItemtext.text}", this);
#endif
    }
    #endregion



}
