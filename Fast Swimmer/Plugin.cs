using BepInEx;
using BepInEx.Configuration;
using GorillaLocomotion;
using UnityEngine;
using System.IO;

namespace FastSwimmer
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin("com.notfishvr.gorillatag.fastswimmer", "FastSwimmer", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private ConfigEntry<float> swimMultiplier;
        private void Awake()
        {
            string configFilePath = Path.Combine(Paths.ConfigPath, "Config.txt");

            if (File.Exists(configFilePath))
            {
                ConfigFile configFile = new ConfigFile(configFilePath, true);
                swimMultiplier = configFile.Bind("Swimming", "SwimMultiplier", 1.4f, "Multiplier for swimming speed");
            }
            else
            {
                swimMultiplier = Config.Bind("Swimming", "SwimMultiplier", 1.4f, "Multiplier for swimming speed");

                ConfigFile defaultConfigFile = new ConfigFile(configFilePath, true);
                defaultConfigFile.Bind("Swimming", "SwimMultiplier", 1.4f, "Multiplier for swimming speed");
                defaultConfigFile.Save();
            }
        }
        private void FixedUpdate()
        {
            if (Player.Instance.InWater)
            {
                Player.Instance.GetComponent<Rigidbody>().velocity *= swimMultiplier.Value;
            }
        }
        private void Update()
        {
            if (Player.Instance.InWater)
            {
                Player.Instance.GetComponent<Rigidbody>().velocity *= swimMultiplier.Value;
            }
        }
    }
}