using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;
using VRC.Udon;

namespace UdonSharpCommon {
  /// <summary>
  /// Interact時に、指定された全てのGameObjectを有効化します。
  /// 次にInteractされても、オブジェクトを再度無効化する等はしません。
  /// </summary>
  public class Activate : UdonSharpBehaviour {
    [SerializeField]
    private GameObject[] targets;

    [SerializeField]
    private bool isWorkingOnlyOnLocal = false;

    public override void Interact() {
      if (this.targets == null) {
        Debug.LogError("Activate: this.targets is null. Skip.");
        return;
      }

      if (this.isWorkingOnlyOnLocal) {
        this.DoActivate();
      } else {
        this.SendCustomNetworkEvent(NetworkEventTarget.All, "DoActivate");
      }
    }

    public void DoActivate() {
      foreach (var target in this.targets) {
        if (target == null) {
          Debug.LogError("Activate: target is null. Skip.");
          continue;
        }

        target.SetActive(true);
      }
    }
  }
}
