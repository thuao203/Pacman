using UnityEngine;

public class PowerPellet : Pellet 
{
    public float duration = 8.0f;

    protected override void Eat() 
    /* hàm này đang ghi đè lên hàm Eat() của lớp cha, cụ thể là Pellet
    */
    {
      FindObjectOfType<GameManager>().PowerPelletEaten(this);  
    }
    /* hàm Eat() được ghi đè để gọi hàm PowerPelletEaten dành riêng cho 
    vật phẩm đặc biệt này. Điều này cho phép Script GameManager 
    phân biệt giữa các loại vật phẩm và thực hiện các hành động phù hợp.
    */
}
