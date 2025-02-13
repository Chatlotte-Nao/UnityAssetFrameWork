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
}
