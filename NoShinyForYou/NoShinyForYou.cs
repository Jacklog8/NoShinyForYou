using QModManager.API.ModLoading;
using Harmony;
using System;
using UnityEngine;
using System.Linq;
using System.Reflection;
namespace NoShinyForYou
{
    [QModCore]
    public class Entry
    {
        [QModPatch]
        public static void Patch()
        {
            try
            {
                var harmony = HarmonyInstance.Create("Cookie.NoShinyForYou");
                    harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
        }
    }

    [HarmonyPatch(typeof(SeaMonkeyStealShiny))]
    [HarmonyPatch(nameof(SeaMonkeyStealShiny.Evaluate))]
    class SeaMonkeyStealShiny_Evaluate_Patch
    {
        public static void Postfix(ref float __result)
        {
            __result = 0f;
        }
    }
    
    
    [HarmonyPatch(typeof(SeaMonkeyBringGift)]
    [HarmonyPatch(nameof(SeaMonkeyBringGift.Evaluate))]
    class Gift_Evaluate_Patch
    {
        public static void Postfix(ref float __result)
        {
            __result = 0f;
        }
    }
