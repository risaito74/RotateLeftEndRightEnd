# RotateLeftEndRightEnd

重機の作業アーム操縦を想定した原始的なモックとして、**端点を軸にしたCube回転のUnityテストプロジェクト**です。

---

## 🎯 概要

Unityの `RotateAround` を使って、オブジェクトの**左端・右端を回転軸**にした動きを実装しました。

バックホーなどの重機アームを操縦するときの「レバーで腕が上下する」を意識した設計になっています。

---

## 🎮 操作方法

| キー | 動作 |
|------|------|
| `Q` | 右端を軸に **Cube左側 アップ** |
| `A` | 右端を軸に **Cube左側 ダウン** |
| `E` | 左端を軸に **Cube右側 アップ** |
| `D` | 左端を軸に **Cube右側 ダウン** |
| `S` | Position・Rotation を **リセット** |

---

## 🔧 技術ポイント

### RotateAround で端点を回転軸にする

```csharp
float halfWidth = transform.localScale.x / 2f;
Vector3 leftPivot  = transform.position - transform.right * halfWidth;
Vector3 rightPivot = transform.position + transform.right * halfWidth;

transform.RotateAround(leftPivot, Vector3.forward, rotateSpeed * Time.deltaTime);
```

- `transform.right` はオブジェクトの **Rotation から一意に決まる方向ベクトル**
- 回転後も正しい端点座標を追従するため `Vector3.right`（固定値）ではなく `transform.right` を使用

### 新InputSystem対応

```csharp
using UnityEngine.InputSystem;

// 押している間
Keyboard.current.qKey.isPressed

// 押した瞬間だけ（リセット処理に使用）
Keyboard.current.sKey.wasPressedThisFrame
```

---

## 🛠 環境

- Unity 6.4
- Input System パッケージ（新InputSystem）

---

## 📝 関連記事

（note記事URLをここに追加予定）
