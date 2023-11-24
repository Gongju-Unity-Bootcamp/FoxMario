using Ending;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_2 : MonoBehaviour
{
    public float maxSpeed = 0.06f;
    bool isJump;
    public float jump;
    public bool longJump = false;
    public bool isDied;

    private EndingUI ending = new EndingUI();
    public GameObject Player;
    SpriteRenderer renderer;
    Animator anime;
    Rigidbody2D rigid;
    string[] sceneNames = new string[3] { "Stage1 JH", "stage2_gang", "ending" };
    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }
    private void Update()
    {
        //플레이어 move -> 좌우 이동, 점프, 애니메이션?, 


        //플레이어 이동 좌표
        float Player = Input.GetAxisRaw("Horizontal");
        Vector2 newPosition = new Vector2(Player * maxSpeed, 0);
        transform.Translate(newPosition);

        //플레이어 이동 및 모션
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigid.AddForce(Vector2.left, ForceMode2D.Impulse);
            renderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid.AddForce(Vector2.right, ForceMode2D.Impulse);
            renderer.flipX = Input.GetAxisRaw("Horizontal") == 0;
        }

        //점프

        if (rigid.velocity.x < -maxSpeed)
        {
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
        }
        else if (rigid.velocity.x > maxSpeed)
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jump);

        }
        if (longJump && rigid.velocity.y > 0)
        {
            rigid.gravityScale = 1.0f;
        }
        else
        {
            rigid.gravityScale = 4f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            longJump = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            longJump = false;
        }
        if (Mathf.Abs(Player) > 0f)
        {
            anime.SetBool("isRun", true);
        }
        else
        {
            anime.SetBool("isRun", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("NextScene"))
        {
            NextScene();
        }
    }
    public void Die()
    {
        Debug.Log("Player Die...!"); 
        //사망시 EndingUI 스크립트 실행
        //ending.Start();
        Respawn();
    }
    private void Respawn()
    {
        isDied = true;
        PlayerPrefs.SetString("PrevSceneName", SceneManager.GetActiveScene().name);
        // 2초 딜레이 예정
        //SceneManager.LoadScene("Die");
    }
    private void NextScene()
    {
        string realScene = SceneManager.GetActiveScene().name;

        for (int index = 0; index < sceneNames.Length; index++)
        {
            if (sceneNames[index] == realScene)
            {
                SceneManager.LoadScene(sceneNames[index + 1]);
            }
        }
    }
}
