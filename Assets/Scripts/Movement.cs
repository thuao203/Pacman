using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
    /*  RequireComponent: yc 1 or nhieu tp dinh kem vs gameobject
        typeof(Rigidbody2D): lay dl Rigidbody2D: mo phong vat ly 2D
    */
public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public Vector2 initialDirection;
    public LayerMask obstacleLayer;

    public new Rigidbody2D rigidbody {get; private set;}
    public Vector2 direction {get; private set;}
    public Vector2 nextDirection {get; private set;}
    public Vector3 startingPosition {get; private set;}

    private void Awake() //Awake: khoi tao tac vu script truoc khi cac script khac duoc chay
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.startingPosition = this.transform.position;
    }   /* getcomponent : truy cap thanh phan Rigidbody2D duoc dinh kem gameobject o tren
        gia tri tra ve getcomponent gan cho bien rigidbody
        this.transform.position: tra ve vi tri hien tai, k thay dôi vi awake chi duoc goi 1 lan trong gameobject
        */

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero; // k xac dinh huong tiep theo
        this.transform.position = this.startingPosition;
        this.rigidbody.isKinematic = false; 
        /*isKinematic: quyet dinh gameobject có tac dong vat ly k
            isKinematic = true : khong td vly
            isKinematic = false : co td vly, tuong tac cac doi tuong khac
        */
        this.enabled = true;

    }

    private void Update()
    {
        if(this.nextDirection != Vector2.zero) {
            SetDirection(this.nextDirection);
        } // neu trong scripte dinh huong san thi goi, con k thi thoi
    }

    private void FixedUpdate() 
    {
        Vector2 position = this.rigidbody.position; //Vi tri hien tai
        Vector2 translation = this.direction * this.speed * this.speedMultiplier * Time.fixedDeltaTime;    
        //tinh vecto dich chuyen
        this.rigidbody.MovePosition(position + translation);
        // MovePosition: dich chuyen doi tuong den vi tri moi
    }
    public void SetDirection(Vector2 direction, bool forced = false)
            /* forced : co nen ap dung huong di chuyen moi khi vị tri do da bi chiem k
                false: k
                true: co
                Occupied: kiem tra vi tri do bi chiem hay chua
            */
    {
        if ( forced || !Occupied(direction)) //forced true hoac occupied false
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;

        }
        else //forced false, ...true
        {
            this.nextDirection = direction; //luu lai chua dung, sau nay trong thi dung
        }
    }

    public bool Occupied(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction,1.5f, this.obstacleLayer );
        return hit.collider != null;
    }
}
