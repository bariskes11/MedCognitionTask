using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;
/// <summary>
/// Main class to Call UI Items from Generator
/// </summary>
public abstract class UIGenerateBase : MonoBehaviour
{
    #region Unity Fields
    [SerializeField]
    TextMeshProUGUI txtHeader;
    #endregion
    #region Fields
  protected  UIFactory uiObject;
    #endregion

    private void Start()
    {
        FactoryGenerator<UIFactory>.InitializeFactoryGenerator();
        SetUI();
    }

    protected virtual void SetUI()
    {
        /// content of method changes by Inherited class
    }
}
