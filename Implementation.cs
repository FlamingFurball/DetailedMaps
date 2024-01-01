using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace DetailedMaps
{
    public class Implementation : MelonMod
    {

        private static AssetBundle? assetBundle;

        internal static AssetBundle MapsAssetBundle
        {
            get => assetBundle ?? throw new System.NullReferenceException(nameof(assetBundle));
        }
            
        public override void OnInitializeMelon()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");           

            assetBundle = LoadAssetBundle("DetailedMaps.detailedmaps");
            //GetAssetNames(assetBundle);

        }

        private static AssetBundle LoadAssetBundle(string path)
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            MemoryStream memoryStream = new MemoryStream((int)stream.Length);
            stream.CopyTo(memoryStream);

            return memoryStream.Length != 0
                ? AssetBundle.LoadFromMemory(memoryStream.ToArray())
                : throw new System.Exception("No data loaded!");
        }
    }
}
