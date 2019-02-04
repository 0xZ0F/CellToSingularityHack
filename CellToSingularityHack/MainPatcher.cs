using Harmony;
using System;
using System.Reflection;
using UnityEngine;

namespace CellToSingularityHack
{
    public class MainPatcher
    {
        public static UnityEngine.GameObject cheatObject;
        private static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.z0f.TheForestMod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            cheatObject = new UnityEngine.GameObject();
            cheatObject.AddComponent<CellToSingularityHack.Manager>();
            UnityEngine.Object.DontDestroyOnLoad(cheatObject);

            //Debug log.
            FileLog.Log("\n------" + DateTime.Now.ToString("MMM ddd d hh:mm:ss yyyy") + "------" + "\n-Log for Cell To Singularity cheat-\nCheat made by Z0F using Harmony.");
        }
    }
}
