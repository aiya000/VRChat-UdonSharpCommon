using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;
using VRC.Udon;

/// <summary>
/// 指定された全てのGameObjectのうち、1つのみを有効化します。
///
/// 新しく有効化されるGameObjecは、配列上で現在有効になっているGameObjectの次に設定されたものです。
/// もし有効化されているGameObjectが最後の要素である場合、次に最初のものを有効化します。
///
/// このスクリプトは、
/// 例えばLightを「暗い・普通・明るい」等、順番に切り替えたいときなどに便利です。
/// </summary>
public class SwitchGameObjects : UdonSharpBehaviour {
  [SerializeField]
  private GameObject[] targets;

  [SerializeField]
  private bool isWorkingOnlyOnLocal = false;

  public override void Interact() {
    if (this.targets == null) {
      Debug.Log("SwitchGameObjects: The targets has not set.");
      return;
    }

    if (this.isWorkingOnlyOnLocal) {
      this.SwitchActive();
    } else {
      this.SendCustomNetworkEvent(NetworkEventTarget.All, "SwitchActive");
    }
  }

  public void SwitchActive() {
    for (var i = 0; i < this.targets.Length - 1; i++) {
      if (this.targets[i] == null) {
        Debug.Log("SwitchGameObjects: SwitchActive(): A target is null. Skip.");
        continue;
      }

      if (this.targets[i].activeSelf) {
        this.inactivateAll();
        this.targets[i + 1].SetActive(true);
        return;
      }
    }

    // if no one is active || the last is active
    this.inactivateAll();
    this.targets[0].SetActive(true);
  }

  private void inactivateAll() {
    foreach (var target in this.targets) {
      target.SetActive(false);
    }
  }
}
