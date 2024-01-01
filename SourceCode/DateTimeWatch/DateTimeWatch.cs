using BepInEx;
using BepInEx.Configuration;
using DateTimeWatch.PluginUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Utilla;
using PluginInfo = BepInEx.PluginInfo;
using ComputerPlusPlus;

namespace DateTimeWatch
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [BepInDependency("com.kylethescientist.gorillatag.computerplusplus", "1.0.1")]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.11")]
    public class DateTimeWatch : BaseUnityPlugin
    {
        public static TextMeshPro datetext;
        public static TextMeshPro timetext;
        public static AssetBundle MainBundle;
        public static GameObject WatchPrefab;
        public static GameObject ActiveWatchPrefab;
        bool PluginEnabled = true;

        public void Start()
        {
            Events.GameInitialized += OnInitiated;
        }

        public void OnInitiated(object sender, EventArgs e)
        {
            DTWUtils.SetupAssetBundle();
            var value = Plugin.Instance.Config.Bind("EnabledMods", PluginInfo.Name, true);
            PluginEnabled = value.Value;

            if (!PluginEnabled)
            {
                ActiveWatchPrefab.SetActive(false);
            }
        }

        public void Awake()
        {

            
        }

        public void OnEnable()
        {
            Logger.LogDebug("EnableDTW");
            ActiveWatchPrefab.SetActive(true);
            
        }

        public void OnDisable()
        {
            Logger.LogDebug("DisableDTW");
                ActiveWatchPrefab.SetActive(false);
            
        }

    }
}
