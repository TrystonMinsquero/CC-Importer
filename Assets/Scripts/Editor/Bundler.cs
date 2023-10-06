using System.IO;
using UnityEditor;
using UnityEngine;


public class Bundler
{
    
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, 
            BuildAssetBundleOptions.None, 
            BuildTarget.StandaloneWindows);
        
    }

    [MenuItem("Assets/LoadAssetBundle")]
    static void LoadAsset()
    {
        foreach(var guid in Selection.assetGUIDs)
        {
            var bundle = AssetBundle.LoadFromFile(AssetDatabase.GUIDToAssetPath(guid)).LoadAllAssets();
            foreach (var obj in bundle)
            {
                
                Debug.Log(obj);
            }
        }
    }
    
}
