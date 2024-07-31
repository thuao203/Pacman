using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{
    public Movement movement { get;private set; }

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }
    private void Update()
    {
        if ( Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            this.movement.SetDirection(Vector2.up);
        }
        else if ( Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            this.movement.SetDirection(Vector2.down);          
        }
        else if ( Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            this.movement.SetDirection(Vector2.left);           
        }
        else if ( Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            this.movement.SetDirection(Vector2.right);
        }
        float angle = Mathf.Atan2(this.movement.direction.y, this.movement.direction.x);
        /*Tính góc xoay theo hướng this.movement.direction 
            arctan-1= (y/x)
            - Atan2: arctangent (cung tan nghịch) của hai giá trị y và x. 
            y là tọa độ y và x là tọa độ x của hướng di chuyển. Góc được trả về bằng radian.
        */
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
        /* Thiết lập xoay, hằng Mathf.Rad2Deg = 180/Mathf.PI,  
            ảctan-1(y/x) x 180 x pi)  
            - angle * Mathf.Rad2Deg : chuyển radian - > độ
            - Vector3.forward: đại diện cho trục Z, sẽ xoay quanh trục Z.
            - Quaternion.AngleAxis: Hàm này tạo một Quaternion đại diện cho phép quay với một góc
            nhất định quanh một trục.
        */
    }
    public void ResetState() 
    {
        this.movement.ResetState();
        this.gameObject.SetActive(true);
    }
}