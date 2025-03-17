using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BundleModuleConfig : OdinEditorWindow
{
    [PropertySpace( spaceAfter:5,spaceBefore:5)]
    [Required("请输入资源模块名称")]
    [GUIColor(0.3f ,0.8f,0.8f,1f)]
    [LabelText("资源模块名称:")]
    public string moduleName;

    [ReadOnly]
    [HideLabel]
    [TabGroup("预制体包")]
    [DisplayAsString]
    public string prefabTabel = "该文件夹下的所有预制体都会单独打成一个AssetBundle";

    [ReadOnly]
    [HideLabel]
    [TabGroup("文件夹子包")]
    [DisplayAsString]
    public string rootFolderSubBundle = "该文件夹下的所有子文件夹都会单独达成一个AssetBundle";

    [ReadOnly]
    [HideLabel]
    [TabGroup("单个补丁包")]
    [DisplayAsString]
    public string signBundle = "指定的文件夹会单独打成一个AssetBundle";


    [FolderPath]
    [TabGroup("预制体包")]
    [LabelText("预制体资源路径配置")]
    public string[] prefabPathArr = new string[] { "Path..." };


    [FolderPath]
    [TabGroup("文件夹子包")]
    [LabelText("文件夹子包路径配置")]
    public string[] rootFolderPathArr = new string[] {};

    [TabGroup("单个补丁包")]
    [LabelText("单个补丁包路径配置")]
    public BundleFileInfo[] signFolderPathArr = new BundleFileInfo[] {};

    public static void ShowWindow(string moduleName)
    {
        BundleModuleConfig window = GetWindowWithRect<BundleModuleConfig>(new Rect(0,0,600,600));
        window.Show();
    }
}
