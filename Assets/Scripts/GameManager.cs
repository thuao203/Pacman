using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //
    public GameOverScreen GameOverScreen;
    
    public ScoreManager ScoreManager;
    public Hello Hello;
    
    AudioManager audioManager;
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;
    
    public int ghostMultiplier{get; private set; } = 1;

    private int score = 0 ;
   
    private int lives  = 3 ;
    
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if ( this.lives <= 0 && Input.anyKeyDown ){
            NewGame();
        }
    }
    private void NewGame()
    {
        
        SetScore(0);
        SetLives(3);
        //NewRound();
    }
    
    
    //ResetState();


    /*private void NewRound()
    {
        foreach( Transform pellet in this.pellets )
        {
            pellet.gameObject.SetActive(true);
        }
        ResetState();
    }*/
    private void ResetState() //dat lai trang thai cho ghost va pacman
    {
        
        ResetGhostMultiplier();

        for (int i  =  0; i < this.ghosts.Length; i++){
            this.ghosts[i].ResetState();
        }
        this.pacman.ResetState();
    }

    public void GameOver() //bien mat pacman và ghost
    {
        for (int i  =  0; i < this.ghosts.Length; i++){
            this.ghosts[i].gameObject.SetActive(false); //ghost bien mat
        }
        this.pacman.gameObject.SetActive(false); //pavman bien mat
        audioManager.PlaySFX(audioManager.PacmanDeath);
        //
        this.ScoreManager.gameObject.SetActive(false); 
        GameOverScreen.Setup(score);
    }
    //
    public void GameWin() //bien mat pacman và ghost
    {
        for (int i  =  0; i < this.ghosts.Length; i++){
            this.ghosts[i].gameObject.SetActive(false); //ghost bien mat
        }
        this.pacman.gameObject.SetActive(false); //pavman bien mat
        audioManager.PlaySFX(audioManager.PacmanEaten);
        //
        this.ScoreManager.gameObject.SetActive(false); 
        Hello.Setup(score);
        ScoreManager.AddPointLives();
        ScoreManager.AddPointScore(score);
    }
    
    private void SetScore( int score)
    {
        
        this.score = score; 
    }

    private void SetLives( int lives)
    {
       
        this.lives = lives;
    }
    

    public void GhostEaten ( Ghost ghost )
    {
        audioManager.PlaySFX(audioManager.GhostEaten);
        int points = ghost.points * this.ghostMultiplier;
        
        SetScore(this.score + points );
        ScoreManager.instance.AddPointScore(score); 
        this.ghostMultiplier++;
        // ham nay chi duoc goi khi va chi khi ham powerpelleteaten thuc thi, con cac truong hop khac pacman k the an ghost duoc
    }

    public void PacmanEaten()
    {
        this.pacman.gameObject.SetActive(false); //gameobject pacman bien mat ~ pacman bien mat
        audioManager.PlaySFX(audioManager.PacmanEaten);
        SetLives(this.lives - 1 );
        //
        ScoreManager.instance.AddPointLives();
        if ( this.lives > 0 ) {
            Invoke(nameof(ResetState), 3.0f ); //Invoke : tri hoan viec goi ham sau 1 khoang tg
        } else {
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet)
    {
        //audioManager.PlaySFX(audioManager.Victory);
        pellet.gameObject.SetActive(false); //gameobject pellet bien mat
        
        
        SetScore(this.score + pellet.points);
        ScoreManager.instance.AddPointScore(score);

        if (!HasRemainingPellets())
        { 
            this.pacman.gameObject.SetActive(false);
            
            audioManager.PlaySFX(audioManager.Victory);
            GameWin();
            //SceneController.instance.NextLevel();
            //Invoke(nameof(NewRound), 3.0f );
        }

        //Check xem con bi tren map k,  tra ve false la het thì pacman bien mat, qua man khac
        
    }
    
    
    public void PowerPelletEaten ( PowerPellet pellet)
    {
        audioManager.PlaySFX(audioManager.PowerPelletEaten);
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].frightened.Enable(pellet.duration);
        }
        PelletEaten (pellet);
        CancelInvoke(nameof(ResetGhostMultiplier));
        //CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier),pellet.duration);
        
    }

    public void Present ( Present pellet)
    {
        audioManager.PlaySFX(audioManager.PowerPelletEaten);
        for (int i = 0; i < this.ghosts.Length; i++) {
            this.ghosts[i].frightened.Enable(pellet.duration);
        }
        PelletEaten (pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier),pellet.duration);
        
    }

    private bool HasRemainingPellets()
    {
        foreach( Transform pellet in this.pellets )
        {
            if(pellet.gameObject.activeSelf) { //activeSelf kiem tra gameobject pellet có con hien tren scene hay k 
                return true; //Hay kiem tra su hoạt dong vien thuoc con ton tai hay 0
            }
        }

        return false; 
    }

    private void ResetGhostMultiplier()
    {
        this.ghostMultiplier = 1;
    }

}

