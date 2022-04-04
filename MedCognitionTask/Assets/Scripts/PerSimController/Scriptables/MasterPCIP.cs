using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds Master PC configuration Data
/// </summary>
[CreateAssetMenu(fileName ="MasterPCIP",menuName ="Assets/Create/CreateMaster")]
public class MasterPCIP : ScriptableObject{

    public string MasterIp;
    public int MasterPort;
}
