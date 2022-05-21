using BepInEx;
using System.Collections.Generic;
using UnityEngine;

namespace LordAshes
{
    public partial class FineTuneObjectPlugin : BaseUnityPlugin
    {
        private static List<StatMessaging.Change> queue = new List<StatMessaging.Change>();

        public void HandleRequest(StatMessaging.Change[] changes)
        {
            Debug.Log("Fine Tune Objects Plugin: Received " + changes.Length + " Updates");
            foreach (StatMessaging.Change change in changes)
            {
                if (active)
                {
                    if (change.action != StatMessaging.ChangeType.removed)
                    {
                        Debug.Log("Fine Tune Objects Plugin: " + change.cid + " => " + change.value);
                        CreatureBoardAsset asset;
                        CreaturePresenter.TryGetAsset(change.cid, out asset);
                        if (asset != null && Utility.GetAssetLoader(asset.CreatureId) != null && Utility.GetAssetLoader(asset.CreatureId) != null)
                        {
                            Debug.Log("Fine Tune Objects Plugin: Applying " + change.cid + " => " + change.value);
                            string[] parts = change.value.Split(',');
                            Utility.GetAssetLoader(asset.CreatureId).transform.position = new Vector3(float.Parse(parts[0]), float.Parse(parts[1]), float.Parse(parts[2]));
                            Utility.GetAssetLoader(asset.CreatureId).transform.eulerAngles = new Vector3(float.Parse(parts[3]), float.Parse(parts[4]), float.Parse(parts[5]));
                        }
                        else if (asset != null)
                        {
                            Debug.Log("Fine Tune Objects Plugin: CreautureLoader or LoadedAsset was not ready");
                        }
                    }
                }
                else
                {
                    Debug.Log("Fine Tune Objects Plugin: Queuing Change " + change.cid + " => " + change.value);
                    queue.AddRange(changes);
                }
            }
        }
    }
}
