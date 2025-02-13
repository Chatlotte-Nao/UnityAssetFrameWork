using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BundleModuleData
{
    //AsseBundle模块ID
    public long BundleId;
    //模块名称
    public string ModuleName;
    //是否打包
    public bool IsBuild;
    //上一次点击按钮的时间
    public float LastClickBtnTime;
}
