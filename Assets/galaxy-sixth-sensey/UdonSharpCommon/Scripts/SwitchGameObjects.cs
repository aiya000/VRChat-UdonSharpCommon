using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;
using VRC.Udon.Common;
using VRC.Udon;

namespace UdonSharpCommon {
  /// <summary>
  /// 指定された全てのGameObjectのうち、1つのみを有効化します。
  ///
  /// 新しく有効化されるGameObjecは、配列上で現在有効になっているGameObjectの次に設定されたものです。
  /// もし有効化されているGameObjectが最後の要素である場合、次に最初のものを有効化します。
  ///
  /// このスクリプトは、
  /// 例えばLightを「暗い・普通・明るい」等、順番に切り替えたいときなどに便利です。
  ///
  /// - runOnInteract:
  ///     オブジェクトをUseしたときに処理を実行するか否か。
  ///     （オブジェクトをピックアップしたときにも実行されるようになります）
  ///
  /// - runOnPickupUseUp
  ///     オブジェクトをPickupしていて、
  ///     かつUseしたときに処理を実行するか否か
  ///
  /// PickupオブジェクトのUse時のみに実行したい場合
  /// （例えば傘を持った状態でトリガーを引いたときに、傘を開きたい場合）
  /// は、runOnInteractをfalseに・runOnPickupUseUpをtrueにするとうまくいくはずです。
  /// </summary>
  public class SwitchGameObjects : UdonSharpBehaviour {
    [SerializeField]
    private GameObject[] targets;

    [SerializeField]
    private bool runOnInteract = true;

    [SerializeField]
    private bool runOnPickupUseUp = true;

    [SerializeField]
    private bool isWorkingOnlyOnLocal = false;

    public override void Interact() {
      if (this.runOnInteract) {
        this.CallSwitchGameObjects();
      }
    }

    public override void OnPickupUseUp() {
      if (this.runOnPickupUseUp) {
        this.CallSwitchGameObjects();
      }
    }

    public void DoSwitchGameObjects() {
      for (var i = 0; i < this.targets.Length - 1; i++) {
        if (this.targets[i] == null) {
          Debug.LogError("SwitchGameObjects: A target is null. Skip.");
          continue;
        }

        if (this.targets[i].activeSelf) {
          this.InactiveAll();
          this.targets[i + 1].SetActive(true);
          return;
        }
      }

      // if no one is active || the last is active
      this.InactiveAll();
      this.targets[0].SetActive(true);
    }

    private void CallSwitchGameObjects() {
      if (this.targets == null) {
        Debug.LogError("SwitchGameObjects: this.targets has not set. Exit.");
        return;
      }

      if (this.isWorkingOnlyOnLocal) {
        this.DoSwitchGameObjects();
      } else {
        this.SendCustomNetworkEvent(NetworkEventTarget.All, "DoSwitchGameObjects");
      }
    }

    private void InactiveAll() {
      foreach (var target in this.targets) {
        target.SetActive(false);
      }
    }
  }
}
