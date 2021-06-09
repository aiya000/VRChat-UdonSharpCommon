# :diamond_shape_with_a_dot_inside: UdonSharpCommon :diamond_shape_with_a_dot_inside:

This is an asset of UdonSharp script sets.

To support making your VRChat world with UdonSharp :tada::sparkles:

(Udon#, U#)

:gift: **PullRequests are welcome** :gift:

## Examples

Everything of UdonSharpCommon can work as both local (not to sync) and global (to sync for users on the world)!

- - -

- `TeleportLocalPlayer`: Moves a local player to a specified point when interacted

- `ToggleAllGameObjects`: Toggles (Enables/Disables) specified GameObjects when interacted
    - Make disabled objects to enable
    - Make enabled objects to disable

- `SwitchGameObjects`: Activates only a GameObjects of next of current activated GameObject when interacted
    - Activates only the 2nd object if the 1st object is active
    - Activates only the 3rd object if the 2nd object is active
    - ...
    - Activates only the 1st object if the last object is active
    - **!** This is useful for switching lights to dark, usual, and brilliant

- `ChangeActiveOnStarted`: Activates or Inactivates objects when your world initialized

- `ChangeLocalPlayerMovingStrengthOnInteract`: Changes jumping power, walk speed, and run speed of a local user when interacted

- `Activate`: Only activates specified GameObjects when interacted. Doesn't disable objects.

```cs
[SerializeField]
private GameObject[] targetsToActivate;

[SerializeField]
private GameObject[] targetsToInactivate;
```

- - -

Please see `*.cs` on ['VRChat-UdonSharpCommon/Assets/galaxy-sixth-sensey/UdonSharpCommon - GitHub'](https://github.com/aiya000/VRChat-UdonSharpCommon/tree/main/Assets/galaxy-sixth-sensey/UdonSharpCommon)

## About this development
### Prepare to build

This project is including a world to test U# scirpts.

Before run (please see below 'Run' section), we must import below assets yourself.
(To avoid infringing the licenses.)

- VRCSDK3-WORLD (Currently recommended `VRCSDK3-WORLD-2021.06.03.14.57_Public`)

### Run

We can check the world by 2 ways.

1. Run by unity (via CyanEmu)
2. `Build & Test` by VRChat SDK tab
