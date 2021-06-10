using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;
using VRC.Udon;

/// <summary>
/// Targetsに指定された全てのGameObjectの有効・無効をトグル（反転）させます。
/// </summary>
public class ToggleAllGameObjects : UdonSharpBehaviour {
  [SerializeField]
  private GameObject[] targets;

  [SerializeField]
  private bool isWorkingOnlyOnLocal = false;

  public override void Interact() {
    if (this.targets == null) {
      Debug.LogError("ToggleAllGameObjects: The targets has not set.");
      return;
    }

    if (this.isWorkingOnlyOnLocal) {
      this.ToggleActivityAll();
    } else {
      this.SendCustomNetworkEvent(NetworkEventTarget.All, "ToggleActivityAll");
    }
  }

  public void ToggleActivityAll() {
    foreach (var target in this.targets) {
      if (target == null) {
        Debug.LogError("ToggleAllGameObjects: ToggleActivityAll(): A target is null. Skip.");
        continue;
      }
      target.SetActive(!target.activeSelf);
    }
  }
}
