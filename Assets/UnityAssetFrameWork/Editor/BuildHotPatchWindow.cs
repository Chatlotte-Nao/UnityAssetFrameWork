using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildHotPatchWindow : BundleBehaviour
{
    protected string[] buildButtonsNameArr = new string[] { "打包热更", "上传资源" };
    
    //热更描述 热更公告
    [HideInInspector]public string patchDes = "输入本次热更描述...";
    //热更补丁版本
    [HideInInspector] public string hotVersion = "1";
    
    public override void Initzation()
    {
        base.Initzation();
    }
    
    public override void OGUI()
    {
        base.OGUI();
        //GUILayout.BeginArea(new Rect(0,400,800,600));

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("请输入本次热更公告");
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        patchDes= GUILayout.TextField(patchDes,GUILayout.Width(800),GUILayout.Height(80));
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        hotVersion = EditorGUILayout.TextField( "热更资源版本:", hotVersion, GUILayout.Width(800), GUILayout.Height(24));
        GUILayout.EndHorizontal();

        //GUILayout.EndArea();
        
    }
    
    /// <summary>
    /// 绘制添加资源模块的按钮
    /// </summary>
    public override void DrawAddModuleButton()
    {
        base.DrawAddModuleButton();

        GUIContent addContent = EditorGUIUtility.IconContent("CollabCreate Icon".Trim(), "");
        if (GUILayout.Button(addContent, GUILayout.Width(130), GUILayout.Height(170)))
        {
            //TODO  编写添加模块的代码
           // BundleModuleConfig.ShowWindow("");
        }
    }

    public override void DrawBuildButtons()
    {
        base.DrawBuildButtons();
        //GUILayout.BeginArea(new Rect(0, 555, 800, 600));
        GUILayout.BeginHorizontal();
        for (int i = 0; i < buildButtonsNameArr.Length; i++)
        {
            GUIStyle style = UnityEditorUility.GetGUIStyle("PreButtonBlue");
            style.fixedHeight = 55;
            if (GUILayout.Button(buildButtonsNameArr[i],style,GUILayout.Height(400),GUILayout.ExpandWidth(true)))
            {
                if (i==0)
                {
                    //打包AssetBundle按钮事件
                    BuildBundle();
                }
                else
                {
                    CopyBundleToStreamingAssetsPath();
                }
            }
        }
        GUILayout.EndHorizontal();
        //GUILayout.EndArea();
    }

    public override void BuildBundle()
    {
        base.BuildBundle();
        foreach (var item in moduleDataList)
        {
            if (item.isBuild)
            {
                //BuildBundleCompiler.BuildAssetBundle(item);
            }
        }
    }

    /// <summary>
    /// 内嵌资源
    /// </summary>
    public void CopyBundleToStreamingAssetsPath()
    {
        foreach (var item in moduleDataList)
        {
            if (item.isBuild)
            {
                //BuildBundleCompiler.CopyBundleToStramingAssets(item);
            }
        }
    }
}
