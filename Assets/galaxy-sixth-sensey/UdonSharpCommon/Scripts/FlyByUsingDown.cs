using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;
using VRC.Udon;

namespace UdonSharpCommon {
  /// <summary>
  /// これのUdonBehaviorがコンポーネントとして設定されたオブジェクトをUseしたときに、
  /// プレイヤーを一瞬、ふわりと浮遊させます。
  /// </summary>
  public class FlyByUsingDown : UdonSharpBehaviour {
    private readonly int FLYING_DISTANCE = 50;

    /// <summary>
    /// Increase this to speed up flying.
    /// </summary>
    [SerializeField]
    private float flappingStrength = 7.0f;

    /// <summary>
    /// The owner of Flyer by pickupping.
    ///
    /// Being null means this object is not picked up now.
    /// </summary>
    private VRCPlayerApi owner;

    /// <summary>
    /// A time count to fix the owner's velocity.
    /// </summary>
    private int countToFly;

    /// <summary>
    /// Initailizes this instance to fly.
    /// </summary>
    public override void OnPickup() {
      this.owner = Networking.LocalPlayer;
      this.countToFly = 0;
    }

    /// <summary>
    /// Initializes this instance to stop.
    /// </summary>
    public override void OnDrop() {
      this.owner = null;
      this.countToFly = 0;
    }

    /// <summary>
    /// Start to fly.
    /// </summary>
    public override void OnPickupUseDown() {
      this.countToFly = FLYING_DISTANCE;
    }

    /// <summary>
    /// Emulates flying the sky :3
    /// </summary>
    public void FixedUpdate() {
      if (this.owner == null || this.countToFly == 0) {
        return;
      }

      this.AffectOnceToFly();
      this.countToFly--;
    }

    /// <summary>
    /// Fix the owner's position to upper.
    ///
    /// Requirement:
    /// - this.owner != null
    /// </summary>
    private void AffectOnceToFly() {
      var movingUp = Vector3.Lerp(
          this.owner.GetVelocity(),
          Vector3.up * this.flappingStrength,
          4 * Time.fixedDeltaTime
          );
      this.owner.SetVelocity(movingUp);
    }
  }
}
