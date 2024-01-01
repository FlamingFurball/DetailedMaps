using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Il2Cpp;
using HarmonyLib;
using UnityEngine;
using Stream = System.IO.Stream;
using StreamReader = System.IO.StreamReader;
using MelonLoader;

namespace DetailedMaps
{
    internal class Patches
    {

        [HarmonyPatch(typeof(FogOfWar),nameof(FogOfWar.MaybeLoadTextureAsset))]
        internal class FogOfWar_LoadTextureAsset
        {
            private static void Postfix(FogOfWar __instance)
            {
                Texture2D MapToLoad = Implementation.MapsAssetBundle.LoadAsset<Texture2D>(__instance.m_MapBackgroundFilename + "_new");

                if (MapToLoad != null) {
                    __instance.m_MapBackground = MapToLoad;
                    __instance.m_MapDetails = Implementation.MapsAssetBundle.LoadAsset<Texture2D>("map_details_blank");
                }
            }
        }
    }
}
