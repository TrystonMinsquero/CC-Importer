using System;
using System.IO;
using System.Threading.Tasks;
using API.Models;
using UnityEngine;
using Client = Supabase.Client;

namespace API
{
    public class SupabaseNotConnectedException : Exception
    {
        public override string Message => "Client has not been connected to supabase yet";
    }

    public struct BucketAsset
    {
        public readonly string BucketName;
        public readonly string FilePath;

        public BucketAsset(string bucketName, string filePath)
        {
            this.BucketName = bucketName;
            this.FilePath = filePath;
        }

        public BucketAsset(ICrownUEntity entity, string fileName)
        {
            this.BucketName = entity.Type.BucketName();
            this.FilePath = $"{entity.Id}/{fileName}";
        }
    }
    
    public static partial class SupabaseUtility
    {
        public static Client? Supabase => SupabaseContainer.Instance.Supabase;

        public static bool Initialized => (SupabaseContainer.Instance != null);

        public static bool TryGetSupabase(out Client supabase)
        {
            supabase = Supabase;
            return supabase != null;
        }

        public static string? AccessToken => Supabase?.Auth.CurrentSession?.AccessToken;

        #region Edge Functions
        
        public static async Task<CrownUInventory> GetInventory()
        {
            if (Supabase == null) throw new SupabaseNotConnectedException();
            var response = await Supabase!.Functions.Invoke<CrownUInventoryResponse>("getInventory", token: SupabaseUtility.AccessToken);
            return response?.Inventory;
        }
        
        public static async Task<CrownUOpenPackResponse> OpenPack(int packId)
        {
            if (Supabase == null) throw new SupabaseNotConnectedException();
            var options = new Supabase.Functions.Client.InvokeFunctionOptions()
            {
                Body = { { "packId", packId } }
            };
            return await Supabase!.Functions.Invoke<CrownUOpenPackResponse>("openPack", token: AccessToken, options);
        }

        #endregion

        #region Donwloading Assets

        #region Donwload Model

        // public static void DownloadModel(BucketAsset asset, Action<GameObject, AnimationClip[]> onComplete, ImportSettings settings = null, EventHandler<float> onProgress = null)
        // {
        //     try
        //     {
        //         void OnDownload(byte[] data)
        //         {
        //             settings ??= new ImportSettings();
        //             Importer.ImportGLBAsync(data, settings, onComplete);
        //         }
        //
        //         DownloadAssetFromBucket(asset, OnDownload, onProgress);
        //     }
        //     catch (Exception e)
        //     {
        //         Debug.LogException(e);
        //         onComplete.Invoke(null, null);
        //     }
        //     
        // }
        //
        // public static void DownloadModel(ICrownUEntity entity, Action<GameObject, AnimationClip[]> onDownloaded, ImportSettings settings = null, EventHandler<float> onProgress = null)
        // {
        //     if(!entity.GlbModel)
        //     {
        //         Debug.LogWarning($"CrownUEntity {entity.GetName()} ({entity.Id}) does not have a glb file");
        //         onDownloaded.Invoke(null, null);
        //         return;
        //     }
        //     DownloadModel(entity.ModelAsset(), onDownloaded, settings, onProgress);
        // }
        
        #endregion
        
        #region Download Texture
        
        public static void DownloadTexture(BucketAsset asset, Action<Texture2D> onComplete,
            EventHandler<float> onProgress = null)
        {
            try
            {
                void OnDownload(byte[] data) => onComplete.Invoke(CreateTexture(data));
                DownloadAssetFromBucket(asset, OnDownload, onProgress);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                onComplete.Invoke(null);
            }
        }

        public static void DownloadTexture(ICrownUBaseObject baseObject, Action<Texture2D> onComplete,
            EventHandler<float> onProgress = null)
        {
            DownloadTexture(new BucketAsset(baseObject, baseObject.ImageData), onComplete, onProgress);
        }

        public static void DownloadTexture(ICrownUPack pack, Action<Texture2D> onComplete, 
            EventHandler<float> onProgress = null)
        {
            DownloadTexture(pack.ImageAsset(), onComplete, onProgress);
        }
        
        static Texture2D CreateTexture(byte[] data)
        {
            var tex = new Texture2D(0, 0);
            tex.LoadImage(data);
            return tex;
        }

        #endregion

        #region Download Sprite
        
        public static void DownloadSprite(BucketAsset asset, Action<Sprite> onComplete,
            EventHandler<float> onProgress = null)
        {
            void OnDownload(Texture2D texture2D) =>
                onComplete.Invoke(Sprite.Create(texture2D, Rect.zero, new Vector2(.5f, .5f)));
            DownloadTexture(asset, OnDownload, onProgress);
        }

        public static void DownloadSprite(ICrownUBaseObject baseObject, Action<Sprite> onComplete,
            EventHandler<float> onProgress = null)
        {
            DownloadSprite(baseObject.ImageAsset(), onComplete, onProgress);
        }

        public static void DownloadSprite(ICrownUPack pack, Action<Sprite> onComplete,
            EventHandler<float> onProgress = null)
        {
            DownloadSprite(pack.ImageAsset(), onComplete, onProgress);
        }

        #endregion
        
        #region Bucket Getters
        
        static BucketAsset ModelAsset(this ICrownUEntity entity) => new (entity, entity.AssetData);
        
        static BucketAsset ImageAsset(this ICrownUPack pack)
        {
            var fileName = pack.AssetData.StartsWith("https://") ? Path.GetFileName(pack.AssetData) : pack.AssetData;
            return new BucketAsset(pack, fileName);
        }
        
        static BucketAsset ImageAsset(this ICrownUBaseObject obj) => new (obj, obj.ImageData);

        #endregion
        
        static async Task<byte[]> DownloadAssetFromBucket(BucketAsset asset, EventHandler<float> onProgress = null)
        {
            if (Supabase == null) throw new SupabaseNotConnectedException();
            return await Supabase.Storage.From(asset.BucketName).Download(asset.FilePath, onProgress);
        }
        
        static async void DownloadAssetFromBucket(BucketAsset asset, Action<byte[]> onComplete, EventHandler<float> onProgress = null)
        {
            var data = await DownloadAssetFromBucket(asset, onProgress);
            onComplete.Invoke(data);
        }

        #endregion
    }
}