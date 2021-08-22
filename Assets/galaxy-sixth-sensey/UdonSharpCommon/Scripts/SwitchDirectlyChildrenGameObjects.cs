using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;
using VRC.Udon.Common;
using VRC.Udon;

namespace UdonSharpCommon {
  public class SwitchDirectlyChildrenGameObjects : UdonSharpBehaviour {
    [SerializeField]
    private Transform root;

    [SerializeField]
    private bool runOnInteract = true;

    [SerializeField]
    private bool runOnPickupUseUp = true;

    [SerializeField]
    private bool isWorkingOnlyOnLocal = false;

    public override void Interact() {
      if (this.runOnInteract) {
        this.Call();
      }
    }

    public override void OnPickupUseUp() {
      if (this.runOnPickupUseUp) {
        this.Call();
      }
    }

    public void Exec() {
      var targets = this.GetChildren();

      for (var i = 0; i < targets.Length - 1; i++) {
        if (targets[i] == null) {
          Debug.LogError("SwitchDirectlyChildrenGameObjects: A target is null. Skip.");
          continue;
        }

        if (targets[i].activeSelf) {
          this.InactiveAll(targets);
          Networking.SetOwner(Networking.LocalPlayer, targets[i + 1]);
          targets[i + 1].SetActive(true);
          return;
        }
      }

      // if no one is active || the last is active
      this.InactiveAll(targets);
      Networking.SetOwner(Networking.LocalPlayer, targets[0]);
      targets[0].SetActive(true);
    }

    private void Call() {
      if (this.root == null) {
        Debug.LogError("SwitchDirectlyChildrenGameObjects: The root is null. Exit.");
        return;
      }

      if (this.isWorkingOnlyOnLocal) {
        this.Exec();
      } else {
        this.SendCustomNetworkEvent(NetworkEventTarget.All, "Exec");
      }
    }

    private void InactiveAll(GameObject[] targets) {
      foreach (var target in targets) {
        Networking.SetOwner(Networking.LocalPlayer, target);
        target.SetActive(false);
      }
    }

    private GameObject[] GetChildren() {
      var result = new GameObject[this.root.childCount];
      var i = 0;

      foreach (Transform x in this.root) {
        result[i] = x.gameObject;
        i++;
      }

      return result;
    }
  }
}
