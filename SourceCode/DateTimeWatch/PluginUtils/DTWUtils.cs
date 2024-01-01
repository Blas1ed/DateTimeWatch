using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace DateTimeWatch.PluginUtils
{
    public static class DTWUtils
    {
        public static TextMeshPro GetTextFromParent(string TextName, Transform Parent)
        {
            foreach (Transform child in Parent)
            {
                if (child.name == TextName)
                {
                    return child.GetComponent<TextMeshPro>();
                }
            }
            return null;
        }

        public static Transform FindInParent(string ChildName, Transform Parent)
        {
            foreach (Transform child in Parent)
            {
                if (child.name == ChildName)
                {
                    return child;
                }
            }

            return null;
        }

        public static void SetupAssetBundle()
        {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DateTimeWatch.Resources.timewatch");
            DateTimeWatch.MainBundle = AssetBundle.LoadFromStream(stream);
            DateTimeWatch.WatchPrefab = DateTimeWatch.MainBundle.LoadAsset<GameObject>("TimeWatch");

                GameObject obj = UnityEngine.Object.Instantiate(DateTimeWatch.WatchPrefab, GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L").transform);
            DateTimeWatch.timetext = GetTextFromParent("Time", FindInParent("Watch", obj.transform));
            DateTimeWatch.datetext = GetTextFromParent("Date", FindInParent("Watch", obj.transform));
            obj.AddComponent<DTWScript>();
            DateTimeWatch.ActiveWatchPrefab = obj;

            
        }
    }
}
