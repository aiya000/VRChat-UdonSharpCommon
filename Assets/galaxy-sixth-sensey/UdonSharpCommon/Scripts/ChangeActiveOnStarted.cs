using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;
using VRC.Udon;

namespace UdonSharpCommon {
  /// <summary>
  /// Start時（ワールドが初期化されたとき）に、
  /// 指定された全てのGameObjectを有効化・無効化します。
  ///
  /// ワールド編集時には非表示にしたくないけど、
  /// ワールド初期状態で無効状態にしておきたいとき・
  /// またはその逆のときに便利。
  /// </summary>
  public class ChangeActiveOnStarted : UdonSharpBehaviour {
    [SerializeField]
    private GameObject[] targetsToActivate;

    [SerializeField]
    private GameObject[] targetsToInactivate;

    [SerializeField]
    private bool isWorkingOnlyOnLocal = false;

    public void Start() {
      if (this.targetsToActivate == null) {
        Debug.LogError("ChangeActiveOnStarted: this.targetsToActivate is null. Skip.");
        return;
      }

      if (this.targetsToInactivate == null) {
        Debug.LogError("ChangeActiveOnStarted: this.targetsToInactivate is null. Skip.");
        return;
      }

      if (this.isWorkingOnlyOnLocal) {
        this.SetActiveAll();
        this.SetInactiveAll();
      } else {
        this.SendCustomNetworkEvent(NetworkEventTarget.All, "SetActiveAll");
        this.SendCustomNetworkEvent(NetworkEventTarget.All, "SetInactiveAll");
      }
    }

    public void SetActiveAll() {
      foreach (var target in this.targetsToActivate) {
        if (target == null) {
          Debug.LogError("ChangeActiveOnStarted: target is null. Skip.");
          continue;
        }

        target.SetActive(true);
      }
    }

    public void SetInactiveAll() {
      foreach (var target in this.targetsToInactivate) {
        if (target == null) {
          Debug.LogError("ChangeActiveOnStarted: target is null. Skip.");
          continue;
        }

        target.SetActive(false);
      }
    }
  }
}
