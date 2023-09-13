using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Attributes")]
    public float moveSpeed;
    public float cooldown;
    

    [Header("Reference")]
    public GameObject bullet;
    public GameObject aim;
    public GlobalScript globalObj;
    public GameObject textureObj;
    public GameObject explosion;
    public AudioClip deathKnell;
    public GameObject gameOverObj;
    public GameObject restart;

    private bool canShoot;
    private bool canMove;


    void Start()
    {
        canShoot = true;
        canMove = true;
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            // Manipulate ship moves right or left
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                this.gameObject.transform.Translate(new Vector3(moveSpeed, 0, 0));
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                this.gameObject.transform.Translate(new Vector3(-moveSpeed, 0, 0));
            }
        }

    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            //Instantiate the bullet
            GameObject obj = Instantiate(bullet, aim.transform.position, Quaternion.identity) as GameObject;
            canShoot = false;
            StartCoroutine(fireCooldown());
        }
    }
    private IEnumerator fireCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }
    public void playerGetHurt()
    {
        if (globalObj.life > 0)
        {
            globalObj.life -= 1;
            if (globalObj.life <= 0)
            {
                // Game over
                GameOver();
                
            }
            else
            {
                Camera.main.GetComponent<CameraEffect>().StartShake();
                Instantiate(explosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
                AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
                PauseGame();
            }
        }
    }
    private void PauseGame()
    {
        Time.timeScale = 0.01f;
        canMove = false;
        textureObj.GetComponent<MeshRenderer>().enabled = false;
        // pause BGM
        GameObject.Find("bgm").GetComponent<AudioSource>().Stop();
        StartCoroutine(Pause());
        
    }
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        GameObject.Find("bgm").GetComponent<AudioSource>().Play();
        canMove = true;
        textureObj.GetComponent<MeshRenderer>().enabled = true;
    }
    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.02f);
        ResumeGame();
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        canMove = false;
        GameObject.Find("bgm").GetComponent<AudioSource>().Stop();
        gameOverObj.SetActive(true);
        restart.SetActive(true);
    }
}
