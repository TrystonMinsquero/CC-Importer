using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;


public class Bundler
{
    
    [MenuItem("Assets/Build AssetBundles/iOS and Android")]
    static void BuildAllAssetBundles()
    {
        BuildAllAssetBundles(BuildTarget.Android);
        BuildAllAssetBundles(BuildTarget.iOS);
    }

    [MenuItem("Assets/Build AssetBundles/Android")]
    static void BuildAndroidAssetBundles() => BuildAllAssetBundles(BuildTarget.Android);

    [MenuItem("Assets/Build AssetBundles/iOS")]
    static void BuildIOSAssetBundles() => BuildAllAssetBundles(BuildTarget.iOS);
    
    [MenuItem("Assets/Build AssetBundles/Windows")]
    static void BuildWindowsAssetBundles() => BuildAllAssetBundles(BuildTarget.StandaloneWindows);
    
    static void BuildAllAssetBundles(BuildTarget target)
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }

        assetBundleDirectory += $"/{target.ToString()}";
        if(!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, 
            BuildAssetBundleOptions.None, 
            target);
    }

    [MenuItem("Assets/LoadAssetBundle")]
    static void LoadAsset()
    {
        AssetBundle.UnloadAllAssetBundles(true);

        foreach(var guid in Selection.assetGUIDs)
        {
            var bundle = AssetBundle.LoadFromFile(AssetDatabase.GUIDToAssetPath(guid)).LoadAllAssets();
            foreach (var obj in bundle)
            {
                GameObject.Instantiate(obj);
            }
        }
    }
    
    
    
}
