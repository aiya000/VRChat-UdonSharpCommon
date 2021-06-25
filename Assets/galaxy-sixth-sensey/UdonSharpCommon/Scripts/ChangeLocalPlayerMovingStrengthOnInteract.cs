using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonSharpCommon {
  /// <summary>
  /// Interactしたユーザーのジャンプ力・歩く速さ・走る速さを、
  /// 指定されたものに変更します。
  /// </summary>
  public class ChangeLocalPlayerMovingStrengthOnInteract : UdonSharpBehaviour {
    [SerializeField]
    private int jumpImpulse = 5;

    [SerializeField]
    private int walkSpeed = 4;

    [SerializeField]
    private int runSpeed = 8;

    public override void Interact() {
      var player = Networking.LocalPlayer;
      player.SetJumpImpulse(this.jumpImpulse);
      player.SetWalkSpeed(this.walkSpeed);
      player.SetRunSpeed(this.runSpeed);
    }
  }
}
