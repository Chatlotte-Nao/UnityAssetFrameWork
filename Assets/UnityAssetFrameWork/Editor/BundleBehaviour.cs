using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BundleBehaviour
{
    /// <summary>
    /// 模块配置列表
    /// </summary>
    protected List<BundleModuleData> moduleDataList;
    /// <summary>
    /// 模块配置行列表
    /// </summary>
    protected List<List<BundleModuleData>> rowModuleDataList;

    protected string curPlatfam;
    
    public virtual void Initzation()
    {
        //获取多模块资源配置列表
        moduleDataList = BuildBundleConfigura.Instance.AssetBundleConfig;
        rowModuleDataList = new List<List<BundleModuleData>>();

        for (int i = 0; i < moduleDataList.Count; i++)
        {
            //计算模块绘制的行数索引
            int rowIndex = Mathf.FloorToInt(i/6);
            if (rowModuleDataList.Count<rowIndex+1)
            {
                rowModuleDataList.Add(new List<BundleModuleData>());
            }
            //往行列表中添加数据
            rowModuleDataList[rowIndex].Add(moduleDataList[i]);
        }

#if UNITY_IOS
        curPlatfam = "BuildSettings.iPhone";
#else
        curPlatfam = "BuildSettings.Android";
#endif
    }
    //这个标签在窗口打开时会持续得调用OGUI方法
    [OnInspectorGUI]
    public virtual void OGUI()
    {
        if (rowModuleDataList==null)
        {
            return;
        }
        //获取Unity Logo图标
        GUIContent content = EditorGUIUtility.IconContent("SceneAsset Icon".Trim() ,"测试文字显示");
        content.tooltip = "单击可选中和取消\n快速双击可打开配置窗口";
        for (int i = 0; i < rowModuleDataList.Count; i++)
        {
            //开始横向绘制
            GUILayout.BeginHorizontal();
            
            for (int j = 0; j < rowModuleDataList[i].Count; j++)
            {
                BundleModuleData moduleData = rowModuleDataList[i][j];
                //绘制按钮
                if (GUILayout.Button(content, GUILayout.Width(130), GUILayout.Height(170)))
                {
                    moduleData.isBuild = moduleData.isBuild == false ? true : false;
                    //检测按钮是否是双击
                    if (Time.realtimeSinceStartup-moduleData.lastClickBtnTime<=0.18f)
                    {
                        BundleModuleConfig.ShowWindow(moduleData.moduleName);
                    }
                    moduleData.lastClickBtnTime = Time.realtimeSinceStartup;

                }
                GUI.Label(new Rect(((j+1)*20+(j*112))-10,150*(i+1)+(i*20),115,20),moduleData.moduleName,new GUIStyle { alignment =TextAnchor.MiddleCenter});
                //绘制按钮选中的高亮效果
                if (moduleData.isBuild)
                {
                    GUIStyle style= UnityEditorUility.GetGUIStyle("LightmapEditorSelectedHighlight");
                    style.contentOffset = new Vector2(100,-70);
                    GUI.Toggle(new Rect(10+(j*133),-160+1*(i+1)+((i+1)*170),120,160),true,EditorGUIUtility.IconContent("Collab"), style);
                }
            }
            //绘制添加资源模块按钮
            if (i==rowModuleDataList.Count-1)
            {
                DrawAddModuleButton();
            }
            // //结束横向绘制
            GUILayout.EndHorizontal();
        }
        //绘制添加资源模块按钮
        if (rowModuleDataList.Count==0)
        {
            DrawAddModuleButton();
        }
        DrawBuildButtons();
    }
    
    /// <summary>
    /// 绘制打包按钮
    /// </summary>
    public virtual void DrawBuildButtons()
    {

    }

    /// <summary>
    /// 打包资源
    /// </summary>
    public virtual void BuildBundle()
    {

    }
    /// <summary>
    /// 绘制添加资源模块按钮
    /// </summary>
    public virtual void DrawAddModuleButton()
    {

    }
}
