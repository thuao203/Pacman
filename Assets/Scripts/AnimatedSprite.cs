using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))] //dinh kem tp spriterendere voi gameobject
    /* requirecomponent : ycau 1 ot nhieu tp dinh kem gameobject
       typeof(..) lay dl spriterendere (hien thi sprite 2D)
    */
public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] sprites;
    public float animationTime = 0.25f;
    public int animationFrame {get; private set; }
    public bool loop = true; 

    private void Awake() //Awake: khoi tao tac vu script truoc khi cac script khac duoc chay
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }   /* getcomponent : truy cap thanh phan spriterender duoc dinh kem gameobject o tren
        gia tri tra ve getcomponent gan cho bien spriterenderer
        */
    
    private void Start()
    { 
        InvokeRepeating(nameof(Advance), this.animationTime, this.animationTime);
    }   /*goi 1 tg tre nhung lap nhieu lan
        nameof(Advance) : chuen ham thanh chuoi
        this.animationTime dau tien: delay cua advance dau
        this.animationTime thu 2: delay cua advance thu 2, hay giua cac advance voi nhau
        */

    private void Advance()
    {
        if(!this.spriteRenderer.enabled){
            return;
        }
        this.animationFrame++;

        if(this.animationFrame >= this.sprites.Length && this.loop) {
            this.animationFrame = 0;
        }
        // Vong tro lai frame 0 khi frame max

        if ( this.animationFrame >= 0 && this.animationFrame < this.sprites.Length){
            this.spriteRenderer.sprite = this.sprites[this.animationFrame];
        }
    }
    public void Restart()
    { 
        this.animationFrame = -1; /* -1 khong nam trong sprite nhung day chi la dau hieu
        de cbi cho frame 0, vi khi k hop le thì k can kiem tra, va tiep tuc goi advance,
        frame + 1= 0 vay lai nhu ban dau */
        Advance(); 
    }
}

