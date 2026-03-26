using UnityEngine;
using UnityEngine.InputSystem; // 新InputSystem！

public class CubeController : MonoBehaviour
{
    public float rotateSpeed = 90f;

    private Vector3 leftPivot;
    private Vector3 rightPivot;
    private float halfWidth;

    void Start()
    {
        Debug.Log("transform.position = " + transform.position);

        // transform.right は Rotation から一意に決まる方向ベクトル（向きが参照できる）
        // Rotation(0,0,0)のときは(1, 0, 0)になる　※回転すると変わる
        Debug.Log("transform.right = " + transform.right);

        // 元のスケールが(4,1,1)だから半分でx=2となる
        halfWidth = transform.localScale.x / 2f;

        leftPivot = transform.position - transform.right * halfWidth;
        rightPivot = transform.position + transform.right * halfWidth;

        Debug.Log("leftPivot = " + leftPivot);
        Debug.Log("rightPivot = " + rightPivot);
    }

    void Update()
    {
        halfWidth = transform.localScale.x / 2f;

        leftPivot = transform.position - transform.right * halfWidth;
        rightPivot = transform.position + transform.right * halfWidth;

        // Eキー：左側面を軸にZ回転（Cube右側アップ）
        if (Keyboard.current.eKey.isPressed)
        {
            transform.RotateAround(leftPivot, Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        // Dキー：左側面を軸にZ逆回転（Cube右側ダウン）
        if (Keyboard.current.dKey.isPressed)
        {
            transform.RotateAround(leftPivot, Vector3.forward, -rotateSpeed * Time.deltaTime);
        }

        // Qキー：右側面を軸にZ回転（Cube左側アップ）
        if (Keyboard.current.qKey.isPressed)
        {
            transform.RotateAround(rightPivot, Vector3.forward, -rotateSpeed * Time.deltaTime);
        }

        // Aキー：右側面を軸にZ逆回転（Cube左側ダウン）
        if (Keyboard.current.aKey.isPressed)
        {
            transform.RotateAround(rightPivot, Vector3.forward, rotateSpeed * Time.deltaTime);
        }

        // Sキー：PositionとRotationをリセット
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            transform.position = Vector3.zero;
            // Rotation(0,0,0)に戻す
            transform.rotation = Quaternion.identity;
        }
    }
}