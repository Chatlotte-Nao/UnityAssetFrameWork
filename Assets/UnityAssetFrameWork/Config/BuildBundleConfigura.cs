using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
[CreateAssetMenu(menuName = "AssetBundle",fileName = "BuildBundleConfigura",order = 4)]
public class BuildBundleConfigura : ScriptableObject
{
    private static BuildBundleConfigura _instance;

    public static BuildBundleConfigura Instance
    {
        get
        {
            if (_instance == null)
            {
                //AssetDatabase加载需要传入后缀名，为绝对路径
                _instance = AssetDatabase.LoadAssetAtPath<BuildBundleConfigura>("Assets/UnityAssetFrameWork/Config/BuildBundleConfigura.asset");
            }

            return _instance;
        }
    }
    /// <summary>
    /// 模块资源配置
    /// </summary>
    [SerializeField]
    public List<BundleModuleData> AssetBundleConfig = new List<BundleModuleData>();
    
    /// <summary>
    /// 根据模块名称获取模块数据
    /// </summary>
    /// <param name="moduleName"></param>
    /// <returns></returns>
    public BundleModuleData GetBundleDataByName(string moduleName)
    {
        foreach (var item in AssetBundleConfig)
        {
            if (string.Equals(item.moduleName,moduleName))
            {
                return item;
            }
        }
        return null;
    }
    /// <summary>
    /// 通过模块名称移除模块资源
    /// </summary>
    /// <param name="moduleName"></param>
    public void RemoveModuleByName(string moduleName)
    {
        for (int i = 0; i < AssetBundleConfig.Count; i++)
        {
            if (AssetBundleConfig[i].moduleName==moduleName)
            {
                AssetBundleConfig.Remove(AssetBundleConfig[i]);
                break;
            }
        }

    }
    /// <summary>
    /// 储存新的模块资源
    /// </summary>
    /// <param name="moduleData"></param>
    public void SaveModuleData(BundleModuleData moduleData)
    {
        if (AssetBundleConfig.Contains(moduleData))
        {
            for (int i = 0; i < AssetBundleConfig.Count; i++)
            {
                if (AssetBundleConfig[i]==moduleData)
                {
                    AssetBundleConfig[i] = moduleData;
                    break;
                }
            }
        }
        else
        {
            AssetBundleConfig.Add(moduleData);
        }
     
        Save();
    }
    public void Save()
    {
#if UNITY_EDITOR
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
#endif
    }
}
