using Date;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public bool startPlay = true;
    public LogicScript logic;
    public bool birdIsAlive;
    public GameObject spawner;
    public GameObject gameOverScreen;
    public AudioSource sound;
    public AudioClip jump;
    public AudioClip dead;
    public AudioClip score;


    void Start()
    {
        birdIsAlive = true;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
        if (GameData.sprite!=null)
            gameObject.GetComponent<SpriteRenderer>().sprite = GameData.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        var touch = false;
        try
        {
            touch = Input.GetTouch(0).phase == TouchPhase.Began;
        }
        catch { }
        if ((touch || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && birdIsAlive)
        {
            sound.PlayOneShot(jump);
            if (startPlay)
            {
                spawner.SetActive(true);
                myRigidbody.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                startPlay = false;
            }
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        sound.PlayOneShot(dead);
        birdIsAlive = false;
        spawner.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sound.PlayOneShot(score);
    }
}
