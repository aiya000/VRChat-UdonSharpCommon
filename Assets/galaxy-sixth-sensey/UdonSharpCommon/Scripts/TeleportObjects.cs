using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;
using VRC.Udon;
using System;

namespace UdonSharpCommon {
  // TODO: Currently teleporting via network is not work well
  /// <summary>
  /// Interactしたとき、オブジェクトを対応する位置に移動させます。
  ///
  /// targets[0]の「対応する位置」はpoints[0]です。
  /// その他の要素についても番号で対応します。
  ///
  /// 対応するpoints要素のないtargetsの要素は移動されません。
  /// </summary>
  public class TeleportObjects : UdonSharpBehaviour {
    [SerializeField]
    private GameObject[] targets;

    [SerializeField]
    private Transform[] points;

    [SerializeField]
    private bool isWorkingOnlyOnLocal = false;

    public override void Interact() {
      if (this.targets == null) {
        Debug.LogError("TeleportObjects: .targets has not set.");
        return;
      }

      if (this.points == null) {
        Debug.LogError("TeleportObjects: .points has not set.");
        return;
      }

      if (this.isWorkingOnlyOnLocal) {
        this.DoTeleportObjects();
      } else {
        Debug.LogError("TeleportObjects: Currently teleporting via network is not work well. Continue.");
        this.SendCustomNetworkEvent(NetworkEventTarget.All, "DoTeleportObjects");
      }
    }

    public void DoTeleportObjects() {
      for (var i = 0; i < this.targets.Length; i++) {
        var target = this.targets[i];

        if (i >= this.points.Length) {
          Debug.LogError($"TeleportObjects: A point of this.targets[{i}] has not set. Exit.");
          return;
        }
        var point = this.points[i];

        target.transform.position = point.position;
        target.transform.rotation = point.rotation;
      }
    }
  }
}
