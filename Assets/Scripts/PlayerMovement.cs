using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    protected Rigidbody2D _rdb2D;
    private Animator _animator;
    private GameObject box;
    public MainGame _mg;
    private GameObject gameObj;
    public CompanionMovement companion;

    //Variáveis;
    public float xmove;    //direção no eixo x;
    [SerializeField]
    private float speed = 0; //velocidade do player;
    [SerializeField]
    private float jumpForce = 400f; //determina o valor da força do pulo;
    public bool facingRight; //determinar qual direção o player está virado;
    public bool grounded;   
    public bool jump;
    public Transform groundCheck;
    public float distance = 1f;
    public LayerMask boxMask;
    public bool inventory;
    public bool oil, coal, toolbox, wheel, pickaxe, mirror;
    public bool action;
    public bool grab;
    public float ladoCaixa;
    public AudioSource audioS;
    public AudioClip[] clip = new AudioClip[1];

	// Use this for initialization
	void Start () {

        _rdb2D = GetComponent<Rigidbody2D>();   //pega o rigidbody do gameobject;

        facingRight = transform.localScale.x > 0;

        _animator = GameObject.Find("LIP").GetComponent<Animator>();

        

	}

    void Awake()
    {
        groundCheck = transform.Find("groundCheck");
    }
	
	// Update is called once per frame
    void Update()
    {
        Companion();

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Boxes"));
        

        if (Input.GetButtonDown("Jump") && grounded)
        {

            jump = true;

        }



        

    }

	void FixedUpdate () {

        

        xmove = Input.GetAxis("Horizontal");

        action = Input.GetKey(KeyCode.X);



        AnimationLayerControl();

        Movement(xmove);

        ChangeDirection(xmove);

        Jump();

        Fall();

        Grab();
                
	}

    /// <summary>
    /// Função para movimentação do player no eixo x;
    /// </summary>
    /// <param name="x"></param>
    protected void Movement(float x)
    {

        _rdb2D.velocity = new Vector2(x*speed, _rdb2D.velocity.y);    //movimenta o player no eixo x;

        _animator.SetFloat("velocity", Mathf.Abs(x));

    }

    /// <summary>
    /// Função para mudança da direção do player;
    /// </summary>
    /// <param name="x"></param>
    protected void ChangeDirection(float x)
    {
        if (!grab)
        {
            if (x > 0 && !facingRight || x < 0 && facingRight)
            {

                facingRight = !facingRight;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
        }
        

    }

    /// <summary>
    /// Função para o pulo do player;
    /// </summary>
    private void Jump()
    {
        
        if (jump)
        {

            _rdb2D.AddForce(new Vector2(0, jumpForce));
            _animator.SetTrigger("jump");
            jump = false;
        }

    }

    /// <summary>
    /// Função para acionar animação de queda;
    /// </summary>
    private void Fall()
    {

        if (!grounded && _rdb2D.velocity.y < 0)
        {

            _animator.SetBool("fall", true);
            _animator.ResetTrigger("jump");

        }
        else if (grounded)
        {
            _animator.SetBool("fall", false);
        }

    }

    /// <summary>
    /// Função para segurar as caixas;
    /// </summary>
    private void Grab()
    {

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKey(KeyCode.X))
        {
            
            grab = true;
            _animator.SetBool("grab", true);
            box = hit.collider.gameObject;
            box.GetComponent<HingeJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<HingeJoint2D>().enabled = true;
            box.GetComponent<BoxMovement>().grabed = true;
            ladoCaixa = this.transform.position.x - box.transform.position.x;
            if (ladoCaixa < -0.7f)
            {
                if (xmove < -0.01f)
                {
                    _animator.SetBool("pull", true);
                    _animator.SetBool("push", false);
                }
                else if (xmove > 0.01f)
                {
                    _animator.SetBool("push", true);
                    _animator.SetBool("pull", false);
                }
            }
            else if (ladoCaixa > 0.7f)
            {
                if (xmove > -0.01f)
                {
                    _animator.SetBool("pull", true);
                    _animator.SetBool("push", false);
                }
                else if (xmove < 0.01f)
                {
                    _animator.SetBool("push", true);
                    _animator.SetBool("pull", false);
                }
            }
            if (xmove == 0)
            {
                _animator.SetBool("push", false);
                _animator.SetBool("pull", false);
            }
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {

            grab = false;
            _animator.SetBool("grab", false);
            box.GetComponent<HingeJoint2D>().enabled = false;
            box.GetComponent<BoxMovement>().grabed = false;
            
        }

        if(grab && Mathf.Abs(xmove) > 0.1f)
        {
          if (!audioS.isPlaying)
            {
                audioS.PlayOneShot(clip[1]);
            }
        }
        else if (grab)
        {
            audioS.Stop();
        }
        
    }

    /// <summary>
    /// Função para coletar os itens;
    /// </summary>
    /// <param name="collision"></param>
    void PickUp(Collider2D collision)
    {

        if (!inventory && !grab)
        {

            if (collision.gameObject.tag == "Pickup")
            {
                audioS.PlayOneShot(clip[0]);

                if (collision.gameObject.name.Contains("oil"))
                {

                    oil = true;
                    inventory = true;
                    Destroy(collision.gameObject);

                }
                else if (collision.gameObject.name.Contains("toolbox"))
                {

                    toolbox = true;
                    inventory = true;
                    gameObj = GameObject.Find("energybox");
                    Destroy(gameObj);

                }
                else if (collision.gameObject.name.Contains("coal"))
                {

                    coal = true;
                    inventory = true;
                    gameObj = GameObject.Find("coal");
                    Destroy(gameObj);

                }
                else if (collision.gameObject.name.Contains("wheel"))
                {
                    wheel = true;
                    inventory = true;
                    Destroy(collision.gameObject);
                }
                else if (collision.gameObject.name.Contains("pickaxe"))
                {
                    pickaxe = true;
                    inventory = true;
                    Destroy(collision.gameObject);
                }
            }

        }

    }

    /// <summary>
    /// Função para interagir com os objetos;
    /// </summary>
    /// <param name="collision"></param>
    void Interact(Collider2D collision)
    {

        if (collision.gameObject.tag == "Interactable")
        {

            if (collision.gameObject.name.Contains("forge") && coal)
            {

                _mg.forge = true;
                coal = false;
                inventory = false;

            }
            else if (collision.gameObject.name.Contains("lever") && oil)
            {

                _mg.lever = true;
                oil = false;
                inventory = false;

            }
            else if (collision.gameObject.name.Contains("wire") && toolbox)
            {

                _mg.wire = true;
                toolbox = false;
                inventory = false;

            }
            else if (collision.gameObject.name.Contains("rock") && pickaxe)
            {
                if (!audioS.isPlaying)
                {
                    audioS.PlayOneShot(clip[3]);
                }
                _mg.rock = true;
                pickaxe = false;
                inventory = false;
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.name.Contains("wheel") && wheel)
            {
                if (!audioS.isPlaying)
                {
                    audioS.PlayOneShot(clip[2]);
                }
                _mg.wheel = true;
                wheel = false;
                inventory = false;
            }
            else if (collision.gameObject.name.Contains("maquinista") && coal)
            {
                _mg.load = true;
                coal = false;
                inventory = false;
            }
            
        }

    }

    private void Companion()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (companion.move)
            {
                audioS.PlayOneShot(clip[4]);
            }
            else if (!companion.move)
            {
                audioS.PlayOneShot(clip[5]);
            }
            companion.move = !companion.move;
        }
        
    }

    /// <summary>
    /// Função para controlar os pesos das layers da animação;
    /// </summary>
    private void AnimationLayerControl()
    {

        
        if (grab)
        {
            _animator.SetLayerWeight(1, 1);
        }
        else
        {
            _animator.SetLayerWeight(1, 0);
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (action)
        {
            PickUp(collision);

            Interact(collision);
        }
        

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
