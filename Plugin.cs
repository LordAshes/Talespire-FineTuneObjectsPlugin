using BepInEx;
using BepInEx.Configuration;
using System.Collections;
using UnityEngine;


namespace LordAshes
{
    [BepInPlugin(Guid, Name, Version)]
    [BepInDependency(LordAshes.StatMessaging.Guid)]
    public partial class FineTuneObjectPlugin : BaseUnityPlugin
    {
        // Plugin info
        public const string Name = "Fine Tune Object Plug-In";              
        public const string Guid = "org.lordashes.plugins.finetuneobjects";
        public const string Version = "1.1.0.0";                    

        // Configuration
        private ConfigEntry<KeyboardShortcut>[] triggerKeys { get; set; }
        private bool active = false;

        void Awake()
        {
            UnityEngine.Debug.Log("Fine Tune Object Plugin: Active.");

            triggerKeys = new ConfigEntry<KeyboardShortcut>[]
            {
                Config.Bind("Hotkeys", "Tilt Up", new KeyboardShortcut(KeyCode.Home, KeyCode.RightControl)),
                Config.Bind("Hotkeys", "Tilt Down", new KeyboardShortcut(KeyCode.End, KeyCode.RightControl)),
                Config.Bind("Hotkeys", "Tilt Left", new KeyboardShortcut(KeyCode.PageUp, KeyCode.RightControl)),
                Config.Bind("Hotkeys", "Tilt Right", new KeyboardShortcut(KeyCode.PageDown, KeyCode.RightControl)),
                Config.Bind("Hotkeys", "Shift Forward", new KeyboardShortcut(KeyCode.Home, KeyCode.RightShift)),
                Config.Bind("Hotkeys", "Shift Back", new KeyboardShortcut(KeyCode.End, KeyCode.RightShift)),
                Config.Bind("Hotkeys", "Shift Left", new KeyboardShortcut(KeyCode.PageUp, KeyCode.RightShift)),
                Config.Bind("Hotkeys", "Shift Right", new KeyboardShortcut(KeyCode.PageDown, KeyCode.RightShift)),
                Config.Bind("Hotkeys", "Shift Up", new KeyboardShortcut(KeyCode.Insert, KeyCode.RightShift)),
                Config.Bind("Hotkeys", "Shift Down", new KeyboardShortcut(KeyCode.Home, KeyCode.RightShift)),
                Config.Bind("Hotkeys", "Manual Re-Tune Objects", new KeyboardShortcut(KeyCode.F, KeyCode.RightControl))
            };

            StatMessaging.Subscribe(FineTuneObjectPlugin.Guid, HandleRequest);

            Utility.PostOnMainPage(this.GetType());
        }

        void Update()
        {
            if (Utility.isBoardLoaded())
            {
                if (Utility.StrictKeyCheck(triggerKeys[0].Value))
                {
                    // Tilt Up
                    CreatureBoardAsset asset;
                    CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                    if (asset!=null)
                    {
                        StatMessaging.SetInfo(asset.Creature.CreatureId, FineTuneObjectPlugin.Guid,
                            asset.CreatureLoaders[0].LoadedAsset.transform.position.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.z + ","
                          + (asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.x + 5) + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.z);
                    }
                }
                else if (Utility.StrictKeyCheck(triggerKeys[1].Value))
                {
                    // Tilt Down
                    CreatureBoardAsset asset;
                    CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                    if (asset != null)
                    {
                        StatMessaging.SetInfo(asset.Creature.CreatureId, FineTuneObjectPlugin.Guid,
                            asset.CreatureLoaders[0].LoadedAsset.transform.position.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.z + ","
                          + (asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.x - 5) + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.z);
                    }
                }
                else if (Utility.StrictKeyCheck(triggerKeys[2].Value))
                {
                    // Tilt Left
                    CreatureBoardAsset asset;
                    CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                    if (asset != null)
                    {
                        StatMessaging.SetInfo(asset.Creature.CreatureId, FineTuneObjectPlugin.Guid,
                            asset.CreatureLoaders[0].LoadedAsset.transform.position.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.z + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.y + ","
                          + (asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.z + 5));
                    }
                }
                else if (Utility.StrictKeyCheck(triggerKeys[3].Value))
                {
                    // Tilt Right
                    CreatureBoardAsset asset;
                    CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                    if (asset != null)
                    {
                        StatMessaging.SetInfo(asset.Creature.CreatureId, FineTuneObjectPlugin.Guid,
                            asset.CreatureLoaders[0].LoadedAsset.transform.position.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.z + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.y + ","
                          + (asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.z - 5));
                    }
                }
                else if (Utility.StrictKeyCheck(triggerKeys[4].Value))
                {
                    // Shift Up
                    CreatureBoardAsset asset;
                    CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                    if (asset != null)
                    {
                        StatMessaging.SetInfo(asset.Creature.CreatureId, FineTuneObjectPlugin.Guid,
                            asset.CreatureLoaders[0].LoadedAsset.transform.position.x + ","
                          + (asset.CreatureLoaders[0].LoadedAsset.transform.position.y + 0.1) + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.z + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.z);
                    }
                }
                else if (Utility.StrictKeyCheck(triggerKeys[5].Value))
                {
                    // Shift Down
                    CreatureBoardAsset asset;
                    CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                    if (asset != null)
                    {
                        StatMessaging.SetInfo(asset.Creature.CreatureId, FineTuneObjectPlugin.Guid,
                            asset.CreatureLoaders[0].LoadedAsset.transform.position.x + ","
                          + (asset.CreatureLoaders[0].LoadedAsset.transform.position.y - 0.1) + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.z + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.z);
                    }
                }
                else if (Utility.StrictKeyCheck(triggerKeys[6].Value))
                {
                    // Shift Left
                    CreatureBoardAsset asset;
                    CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                    if (asset != null)
                    {
                        StatMessaging.SetInfo(asset.Creature.CreatureId, FineTuneObjectPlugin.Guid,
                            (asset.CreatureLoaders[0].LoadedAsset.transform.position.x - 0.1) + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.z + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.z);
                    }
                }
                else if (Utility.StrictKeyCheck(triggerKeys[7].Value))
                {
                    // Shift Right
                    CreatureBoardAsset asset;
                    CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                    if (asset != null)
                    {
                        StatMessaging.SetInfo(asset.Creature.CreatureId, FineTuneObjectPlugin.Guid,
                            (asset.CreatureLoaders[0].LoadedAsset.transform.position.x + 0.1) + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.z + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.z);
                    }
                }
                else if (Utility.StrictKeyCheck(triggerKeys[8].Value))
                {
                    // Shift Forward
                    CreatureBoardAsset asset;
                    CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                    if (asset != null)
                    {
                        StatMessaging.SetInfo(asset.Creature.CreatureId, FineTuneObjectPlugin.Guid,
                            asset.CreatureLoaders[0].LoadedAsset.transform.position.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.y + ","
                          + (asset.CreatureLoaders[0].LoadedAsset.transform.position.z + 0.1) + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.z);
                    }
                }
                else if (Utility.StrictKeyCheck(triggerKeys[9].Value))
                {
                    // Shift Backward
                    CreatureBoardAsset asset;
                    CreaturePresenter.TryGetAsset(LocalClient.SelectedCreatureId, out asset);
                    if (asset != null)
                    {
                        StatMessaging.SetInfo(asset.Creature.CreatureId, FineTuneObjectPlugin.Guid,
                            asset.CreatureLoaders[0].LoadedAsset.transform.position.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.position.y + ","
                          + (asset.CreatureLoaders[0].LoadedAsset.transform.position.z  - 0.1)+ ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.x + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.y + ","
                          + asset.CreatureLoaders[0].LoadedAsset.transform.eulerAngles.z);
                    }
                }
                else if (Utility.StrictKeyCheck(triggerKeys[10].Value))
                {
                    // Re-Tune
                    Debug.Log("Fine Tune Objects Plugin: Initiating Fine Tune");
                    active = true;
                    HandleRequest(queue.ToArray());
                    queue.Clear();
                }
            }
        }
    }
}
