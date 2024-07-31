using UnityEngine;

public class Passage : MonoBehaviour
{
    /*Đối tượng được dịch chuyển ngay lập tức 
đến vị trí của cổng đích khi đi qua vùng trigger.*/
    
    
    public Transform connection;
    /*lưu trữ tham chiếu đến vị trí của 
    cổng đích mà đối tượng sẽ được dịch chuyển đến*/


   private void OnTriggerEnter2D(Collider2D other)
   {
        Vector3 position = other.transform.position;
        position.x = this.connection.position.x;
     /*Gán giá trị tọa độ X của vị trí cổng đích (this.connection.position.x) 
     vào tọa độ X của biến position.*/
      
        position.y = this.connection.position.y;
     /*Gán giá trị tọa độ Y của vị trí cổng đích (this.connection.position.y) 
     vào tọa độ Y của biến position.*/
      
        other.transform.position = position; 
     //Thiết lập lại vị trí của đối tượng đã va chạm 

   }
}
