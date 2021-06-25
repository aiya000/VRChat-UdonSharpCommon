# :diamond_shape_with_a_dot_inside: UdonSharpCommon :diamond_shape_with_a_dot_inside:

This is an asset of UdonSharp script sets.

To support making your VRChat world with UdonSharp :tada::sparkles:

(Udon#, U#)

:gift: **PullRequests are welcome** :gift:

## Requirements

- VRCSDK3-WORLD (recommended `VRCSDK3-WORLD-2021.06.03.14.57_Public`)
- UdonSharp (recommended `UdonSharp_v0.19.2`)

## Reference

Everything of UdonSharpCommon can work as both local (not to sync) and global (to sync for users on the world)!

<details>
<summary>Reference</summary>

# Classes

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->
**Table of Contents**  *generated with [DocToc](https://github.com/thlorenz/doctoc)*

- [Classes](#classes)
  - [Activate](#activate)
  - [ChangeActiveOnStarted](#changeactiveonstarted)
  - [ChangeLocalPlayerMovingStrengthOnInteract](#changelocalplayermovingstrengthoninteract)
  - [FlyByToggling](#flybytoggling)
  - [FlyByUsingDown](#flybyusingdown)
  - [SwitchGameObjects](#switchgameobjects)
  - [TeleportLocalPlayer](#teleportlocalplayer)
  - [TeleportObjects](#teleportobjects)
  - [ToggleAllGameObjects](#toggleallgameobjects)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## Activate

Interact時に、指定された全てのGameObjectを有効化します。
次にInteractされても、オブジェクトを再度無効化する等はしません。

```cs
[SerializeField]
private GameObject[] targets;

[SerializeField]
private bool isWorkingOnlyOnLocal = false;
```

## ChangeActiveOnStarted

Start時（ワールドが初期化されたとき）に、
指定された全てのGameObjectを有効化・無効化します。

ワールド編集時には非表示にしたくないけど、
ワールド初期状態で無効状態にしておきたいとき・
またはその逆のときに便利です。

```cs
[SerializeField]
private GameObject[] targetsToActivate;

[SerializeField]
private GameObject[] targetsToInactivate;

[SerializeField]
private bool isWorkingOnlyOnLocal = false;
```

## ChangeLocalPlayerMovingStrengthOnInteract

Interactしたユーザーのジャンプ力・歩く速さ・走る速さを、指定されたものに変更します。

```cs
[SerializeField]
private int jumpImpulse = 5;

[SerializeField]
private int walkSpeed = 4;

[SerializeField]
private int runSpeed = 8;
```

## FlyByToggling

これのUdonBehaviorがコンポーネントとして設定されたオブジェクトをUseしたときに、
プレイヤーを飛行させます。
もう一度Useすると、飛行を停止します。

```cs
[SerializeField]
private float flappingStrength = 5.0f;
```

## FlyByUsingDown

これのUdonBehaviorがコンポーネントとして設定されたオブジェクトをUseしたときに、
プレイヤーを一瞬、ふわりと浮遊させます。

```cs
[SerializeField]
private float flappingStrength = 7.0f;
```

## SwitchGameObjects

指定された全てのGameObjectのうち、1つのみを有効化します。

新しく有効化されるGameObjecは、配列上で現在有効になっているGameObjectの次に設定されたものです。
もし有効化されているGameObjectが最後の要素である場合、次に最初のものを有効化します。

このスクリプトは、
例えばLightを「暗い・普通・明るい」等、順番に切り替えたいときなどに便利です。

```cs
[SerializeField]
private GameObject[] targets;

[SerializeField]
private bool runOnInteract = true;

[SerializeField]
private bool runOnPickupUseUp = true;

[SerializeField]
private bool isWorkingOnlyOnLocal = false;
```

- `runOnInteract`
    - オブジェクトをUseしたときに処理を実行するか否か
    - オブジェクトをピックアップしたときにも実行されるようになります

- `runOnPickupUseUp`
    - オブジェクトをPickupしていて、かつUseしたときに処理を実行するか否か

PickupオブジェクトのUse時のみに実行したい場合
（例えば傘を持った状態でトリガーを引いたときに、傘を開きたい場合）
は、`runOnInteract`をfalseに・`runOnPickupUseUp`をtrueにするとうまくいくはずです。

## TeleportLocalPlayer

Interactしたユーザーを、指定したオブジェクトの位置にワープさせます。

```cs
[SerializeField]
private Transform teleportedPoint;
```

## TeleportObjects

- TODO: Currently teleporting via network is not work well

Interactしたとき、オブジェクトを対応する位置に移動させます。

targets[0]の「対応する位置」はpoints[0]です。
その他の要素についても番号で対応します。

対応するpoints要素のないtargetsの要素は移動されません。

```cs
[SerializeField]
private GameObject[] targets;

[SerializeField]
private Transform[] points;

[SerializeField]
private bool isWorkingOnlyOnLocal = false;
```

## ToggleAllGameObjects

Targetsに指定された全てのGameObjectの有効・無効をトグル（反転）させます。

```cs
[SerializeField]
private GameObject[] targets;

[SerializeField]
private bool isWorkingOnlyOnLocal = false;
```

</details>

Please also see ['VRChat-UdonSharpCommon/Assets/galaxy-sixth-sensey/UdonSharpCommon - GitHub'](https://github.com/aiya000/VRChat-UdonSharpCommon/tree/main/Assets/galaxy-sixth-sensey/UdonSharpCommon).

## About this development
### Prepare to build

This project is including a world to test U# scirpts.

Before run (please see below 'Run' section), we must import below assets yourself.
(To avoid infringing the licenses.)

### Run

We can check the world by 2 ways.

1. Run by unity (via CyanEmu)
2. `Build & Test` by VRChat SDK tab

## NOTE

This readme is build with [README.mdpp](./README.mdpp) and [MarkdownPP](https://github.com/jreese/markdown-pp).
