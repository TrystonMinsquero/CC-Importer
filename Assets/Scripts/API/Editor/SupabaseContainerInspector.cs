using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Supabase.Storage;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Directory = System.IO.Directory;
using File = System.IO.File;

namespace API.Editor
{
    
    
    [CustomEditor(typeof(SupabaseContainer))]
    public class SupabaseContainerInspector : UnityEditor.Editor
    {
        SupabaseContainer _main;
        int index = 0;
        List<Bucket> buckets = new List<Bucket>();
        
        void OnEnable()
        {
            _main = target as SupabaseContainer;
            GetBuckets();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.LabelField(_main.Supabase != null ? "Connected" : "Not Connected");
            if (GUILayout.Button("Refresh Connection"))
            {
                AssetDatabase.Refresh();
            }

            
            var files = Directory.GetFiles("Assets/AssetBundles", "*", SearchOption.AllDirectories);
            files = files.Where(file => !file.Contains('.') && File.Exists(file))
                .Select(file => file.Remove(0, "Assets/AssetBundles/".Length).Replace('\\', '/'))
                .Prepend("All")
                .ToArray();
            index = EditorGUILayout.Popup(index, files);
            foreach (var bucket in buckets)
            {
                EditorGUILayout.Foldout(true, bucket.Name);
                if(bucket.AllowedMimes == null) continue;
                foreach (var mime in bucket.AllowedMimes)
                {
                    EditorGUILayout.LabelField(mime);
                }
                
            }
        }

        async void GetBuckets()
        {
            if(_main.Supabase != null)
                buckets = await _main.Supabase.Storage.ListBuckets();
        }
    }
}