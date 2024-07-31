using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Collider2D))]
public class Pellet : MonoBehaviour
{
    public int points = 10; 

    protected virtual void Eat()
    {
      FindObjectOfType<GameManager>().PelletEaten(this);  
    }

    private void OnTriggerEnter2D(Collider2D other)
        /*Đây là một hàm callback collision (va chạm) của Unity
         tự động gọi khi có vật thể khác đi vào vùng trigger 
         (kích hoạt va chạm) của đối tượng game.*/
    {   
        if ( other.gameObject.layer == LayerMask.NameToLayer("Pacman")){
            
            Eat();
        }
        /*Hàm OnTriggerEnter2D kiểm tra xem đối tượng va chạm có phải là Pacman 
        hay không và gọi hàm Eat() để xử lý sự kiện ăn vật phẩm.*/
    }
    
}
