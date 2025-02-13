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

        for (int i = 0; i < rowModuleDataList.Count; i++)
        {
            //开始横向绘制
            GUILayout.BeginHorizontal();
            
            for (int j = 0; j < rowModuleDataList[i].Count; j++)
            {
                BundleModuleData moduleData = rowModuleDataList[i][j];
                //绘制按钮
                if (GUILayout.Button("123123", GUILayout.Width(130), GUILayout.Height(170)))
                {
                    
                }
            }
            
            //结束横向绘制
            GUILayout.EndHorizontal();
        }
    }
}
