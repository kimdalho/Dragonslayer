using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevSettingManager : MonoBehaviour
{
    private void Awake()
    {
        Global.SetUp();
        TableContainer.Instance.Setup();
    }
}
