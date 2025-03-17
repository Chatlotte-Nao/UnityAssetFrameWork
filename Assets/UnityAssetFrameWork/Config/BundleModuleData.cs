using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class BundleModuleData
{
    //AsseBundle模块ID
    public long BundleId;
    //模块名称
    public string moduleName;
    //是否打包
    public bool isBuild;
    //上一次点击按钮的时间
    public float lastClickBtnTime;
}

[System.Serializable]
public class BundleFileInfo
{
    [HideLabel]
    public string abName="AB Name";
    [HideLabel]
    [FolderPath]
    public string bundlePath="BundlePath...";
}