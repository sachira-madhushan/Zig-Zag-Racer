using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    public float playerSpeed;
    Rigidbody rb;
    bool movingLeft = true;
    private bool playing;
    bool firstInput = true;
    public GameObject[] cars;
    public AudioClip coin;
    public AudioClip fail;
    private AudioSource audioSource;
    public TextMeshProUGUI coinText;
    int coins = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        coinText.text=coins.ToString();

    }

    // Start is called before the first frame update
    void Start()
    {
        cars[PlayerPrefs.GetInt("selectedCar")].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coins.ToString();
        /* if (!GameManager.instance.gameStarted)
         {
             if (Input.GetMouseButtonDown(0))
             {
                 playing = true;
             }
         }

         else if (playing)
         {
             CheckInput();
             Move();
         }*/

        if (GameManager.instance.gameStarted)
        {
            
            Move();
            CheckInput();
        }

        if(transform.position.y <= -2)
        {
            
            if (transform.position.y <= -4) {

                playing = false;
                GameManager.instance.GameOver();
            }
            
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Home");
        }
        
    }

    private void FixedUpdate()
    {
        if (playing)
        {
            //Move();
        }
        
    }

    void CheckInput()
    {
        if (firstInput) {

            firstInput = false;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    void Move()
    {
        //rb.velocity = transform.forward * playerSpeed;

        transform.position += transform.forward * playerSpeed * Time.deltaTime;
    }

    void ChangeDirection()
    {
        if (movingLeft)
        {
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0, 90f, 0);
            

        }
        else
        {
            movingLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //started = false;
        //rb.isKinematic = false;
        //rb.velocity = Vector3.down * 20f;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coins++;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 0) +1);
            Destroy(collision.gameObject);
            audioSource.clip = coin;
            audioSource.Play();
        }
    }

}
