using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SkateController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float AirjumpForce = 6f;
    private bool isJumping = false;
    private bool isDead = false;
    public GameObject gameOverScreen; 
    public GameObject winScreen; 
    private bool hasWon = false;
    public pauseMenu PauseMenu;

    public Rigidbody2D rb;
    public Animator animator;

    public TimerController timerController; // Arraste o objeto TimerController para este campo no Inspector

    public void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        FindObjectOfType<AudioManager>().Play("TrilhaSonora");       
        timerController.StartTimer();
    }

    void Update()
    {
        if (isDead) return; // Não permitir movimentação se o jogador estiver morto

        // Pular
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1") && !isJumping)
        {
            Jump();
        }
        // Atualizar o parâmetro de animação "Speed" com base na velocidade horizontal
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    void FixedUpdate()
    {
        if (isDead) return; // Não permitir movimentação se o jogador estiver morto

        // Movimentação automática para a direita
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar se o personagem está tocando no chão
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("Jump", false); 
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Vector2 contactPoint = collision.contacts[0].normal;
            if (contactPoint.y < 0.5f)
            {
                Die();
            }
            else
            {
                isJumping = false;
            }
        }

        if (collision.gameObject.CompareTag("Damage"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("Finish") && !hasWon)
        {
            hasWon = true;
            winScreen.SetActive(true);
            Time.timeScale = 0f; // Pausa o jogo
            PauseMenu.pauseButton.SetActive(false); 

            // Parar a música da fase
            FindObjectOfType<AudioManager>().Stop("TrilhaSonora");
            
            // Iniciar a música de vitória
            FindObjectOfType<AudioManager>().Play("Win");       
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("autoJump"))
        {
            AutoJump();
        }
        
   }

    public void Jump()
    {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("Jump", true); 
    }

    public void AutoJump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        isJumping = true;
        animator.SetBool("Jump", true); 
    }

    public void AutoJumpAir()
    {
        rb.AddForce(new Vector2(0f, AirjumpForce), ForceMode2D.Impulse);
        isJumping = true;
        animator.SetBool("Jump", true); 
    }

    public void Flip()
    {
        animator.SetTrigger("flip");
    }

    public void ShoveIt()
    {
        animator.SetTrigger("shoveit");
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        Invoke("GameOverDelayed", 0.3f);
    }

    void GameOverDelayed()
    {
        // Para a música da fase
        FindObjectOfType<AudioManager>().Stop("TrilhaSonora");

        // Inicia a música de Game Over
        FindObjectOfType<AudioManager>().Play("GameOver");  

        // Ativa o painel de Game Over
        gameOverScreen.SetActive(true);

        // Para o timer ou qualquer outra lógica que você deseja executar após a morte do jogador
        timerController.StopTimer();

        // Desativa o botão de pausa (se necessário)
        PauseMenu.pauseButton.SetActive(false);  
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reinicia a cena atual
    }
}