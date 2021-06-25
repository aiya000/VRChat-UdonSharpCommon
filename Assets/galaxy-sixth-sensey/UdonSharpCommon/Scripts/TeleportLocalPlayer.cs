using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonSharpCommon {
  /// <summary>
  /// Interactしたユーザーを、指定したオブジェクトの位置にワープさせます。
  /// </summary>
  public class TeleportLocalPlayer : UdonSharpBehaviour {
    [SerializeField]
    private Transform teleportedPoint;

    public override void Interact() {
      if (this.teleportedPoint == null) {
        Debug.LogError("TeleportLocalPlayer: .teleportedPoint has not set");
        return;
      }

      Networking.LocalPlayer.TeleportTo(
        this.teleportedPoint.position,
        this.teleportedPoint.rotation
      );
    }
  }
}
