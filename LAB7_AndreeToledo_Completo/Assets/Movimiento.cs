using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    private SpriteRenderer elRender;
    private Sprite kirbySprite, linkSprite;
    public float velMax = 5f;
    bool derecha = true;
    public float velSalto = 5f;
    public bool esMamado;

    private bool enSuelo;
    public Transform groundCheck;
    public float checkRadio;
    public LayerMask whatisGround;
    private int extra;
    public int extraVal;

    // Start is called before the first frame update
    void Start()
    {
        extra = extraVal;
        esMamado = false;
        elRender = GetComponent<SpriteRenderer>();
        kirbySprite = Resources.Load<Sprite>("kirby");
        linkSprite = Resources.Load<Sprite>("KirbyLink");
        elRender.sprite = kirbySprite;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (enSuelo == true){
            extra = extraVal;
        }
        if (Input.GetKey(KeyCode.Space) && extra > 0)
        {
            SoundManager.PlaySound("Salto");
            rb.velocity = Vector2.up * velSalto;
            extra--;

        }else if (Input.GetKeyDown(KeyCode.Space) && extra == 0 && enSuelo == true)
        {
            
            rb.velocity = Vector2.up * velSalto;
        }


        
           
        
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(groundCheck.position, checkRadio, whatisGround);
            
            
        

        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * velMax, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !derecha)
            Volteo();

        else if (move < 0 && derecha)
            Volteo();
    }

    private void Volteo()
    {
        derecha = !derecha;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pawah")
        {
            SoundManager.PlaySound("Zelda");
            Destroy(other.gameObject);
            elRender.sprite = linkSprite;
            esMamado = true;

            
        }else if (other.tag == "enemigo")
        {
            if (esMamado == true)
            {
                SoundManager.PlaySound("muerteEnemy");
                SoundManager.PlaySound("GolpeEnemy");
                Destroy(other.gameObject);
               
            }
        }

        if (other.tag == "enemigo")
        {
            if (esMamado == false)
            {
                SoundManager.PlaySound("Golpe");
                Destroy(gameObject);

            }
        }




    }
}
