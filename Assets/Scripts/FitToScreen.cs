using UnityEngine;

public class FitToScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private bool reSizeOnStart;
    void Start()
    {
        if (reSizeOnStart)
        {
            Resize();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FitObjectToScreen()
    {
        Camera cam = Camera.main;

        // 1. หาความสูงของหน้าจอในหน่วย Unity Unit
        // สูตร: Orthographic Size * 2
        float screenHeight = cam.orthographicSize * 2.0f;

        // 2. หาความกว้างของหน้าจอโดยคำนวณจาก Aspect Ratio (สัดส่วนจอ)
        float screenWidth = screenHeight * cam.aspect;

        // 3. ปรับ Scale ของ Object (ถ้าเป็น Sprite หรือ Plane ปกติจะใช้ค่านี้ได้เลย)
        transform.localScale = new Vector3(screenWidth, screenHeight, 1);

        // วางตำแหน่งให้อยู่ตรงกลางกล้อง
        transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, 0);
    }

    [ContextMenu("Resize Now")] // สามารถคลิกขวาที่ชื่อ Component ใน Inspector เพื่อกดรันได้
    void Resize()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        // 1. หาความสูงและความกว้างของจอในหน่วย Unity Unit
        float screenHeight = 2f * cam.orthographicSize;
        float screenWidth = screenHeight * cam.aspect;

        // 2. ปรับ Scale ของ Plane 
        // เนื่องจาก Plane มาตรฐานมีขนาด 10x10 units เราจึงต้องหารด้วย 10
        // ถ้าคุณใช้ Sprite หรือ Quad ให้เปลี่ยนจาก 10f เป็น 1f
        transform.localScale = new Vector3(screenWidth / 10f, 1f, screenHeight / 10f);

        // หมุนให้หันหน้ามาหา Camera (สำหรับ 2D)
        transform.rotation = Quaternion.Euler(-90f, 180f, 0f);
    }
}
