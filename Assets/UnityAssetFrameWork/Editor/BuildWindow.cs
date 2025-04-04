using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

public class BuildWindow : OdinMenuEditorWindow
{
    [SerializeField]
    public BuildBundleWindow buildBundleWindow = new BuildBundleWindow();
    
    [SerializeField]
    public BuildHotPatchWindow buildHotWindow = new BuildHotPatchWindow();
    
    [MenuItem("AB/AssetBundle")]
    public static void ShowAssetBundleWindow()
    {
        BuildWindow window = GetWindow<BuildWindow>();
        window.position = GUIHelper.GetEditorWindowRect().AlignCenter(980, 612);
        window.ForceMenuTreeRebuild();
    }
    
    protected override OdinMenuTree BuildMenuTree()
    {
        buildBundleWindow.Initzation();
        buildHotWindow.Initzation();
        OdinMenuTree menuTree = new OdinMenuTree(supportsMultiSelect: false)
        {
            {"Build",null,EditorIcons.House},
            { "Build/AssetBundle",buildBundleWindow,EditorIcons.UnityLogo},
            { "Build/HotPatch",buildHotWindow,EditorIcons.UnityLogo}
        };
        return menuTree;
    }
}
