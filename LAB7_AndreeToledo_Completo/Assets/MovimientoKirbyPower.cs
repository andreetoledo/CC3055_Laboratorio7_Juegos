using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoKirbyPower : MonoBehaviour
{
    public float velMax = 5f;
    bool derecha = true;
    public float velSalto = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();


        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * velSalto;
        }
    }

    private void FixedUpdate()
    {





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
        if (other.tag == "enemigo")
        {
            Destroy(other.gameObject);
        }
        
    }
}
