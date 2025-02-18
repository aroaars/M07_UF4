using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    public bool canMove = true;
    public Vector3 externalMoveSpeed;

    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private bool Grounded;

    [SerializeField] private AudioSource walk;

    private float _maxFallSpeed = 20f;
    private float _currentFallSpeed = 0f;

    private CharacterController _controller;
    [SerializeField] public Vector3 _moveDirection = Vector3.zero;
    public float _vertical;
    public float _horizontal;

    public bool inWater;

    private float _coyoteTime = 0.4f;
    private float _jumpingTime = 1.40f;
    private float _timeSinceGrounded;
    private bool slope = false;

    public float input;
    private bool jumping;



    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        jumping = false;

    }

    private void FixedUpdate()
    {
        Grounded = _controller.isGrounded;
        if(canMove)
        {

        
        _vertical = _joystick.Vertical;// + Input.GetAxis("Vertical");
        _horizontal = _joystick.Horizontal;

        input = Mathf.Abs(_vertical) + Mathf.Abs(_horizontal);

        //Vector3 cameraForward = Vector3.Scale(_cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        //Vector3 moveDirection = _vertical * cameraForward + _horizontal * _cameraTransform.right;
        //Vector3 = (0,0,0), 3 direccions; x,y,z. Calcula la posició segons la direcció on anem?
        Vector3 moveDirection = _vertical * _cameraTransform.forward + _horizontal * _cameraTransform.right; //anar en vertical multiplicat pel davant de la càmera pq el personatge (player) vagi cap al davant de la càmera. La posició que es "davant" per la càmera.

 
        _moveDirection.x = moveDirection.x * _moveSpeed; _moveDirection.z = moveDirection.z * _moveSpeed;
        }
        


        if (_controller.isGrounded)
        {
            if (_jumpingTime < 0) jumping = false; //no preguntarà salt.
            _currentFallSpeed = 0f;
            _timeSinceGrounded = 0f;

        }
        else
        {
            _timeSinceGrounded += Time.deltaTime;
            _moveDirection.x *= 0.7f; _moveDirection.z *= 0.7f;

            if (_moveDirection.y < -_maxFallSpeed) _moveDirection.y = -_maxFallSpeed;
            else
            {
                _currentFallSpeed += Time.deltaTime * 20f;
                _moveDirection.y -= _currentFallSpeed * Time.deltaTime;
            }
        }

        if ((_horizontal != 0 || _vertical != 0)) // línies 81-83: ROTACIÓ DE PERSONATGE.
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(_moveDirection.x, 0, _moveDirection.z)); //al transform rotation del personatge li assigno el moviment de la càmera. li posem el nostre moviment de manera que la rotació s'adapti al moviment.
        }

        //Fall out with angle
        /*if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
        {
            if (hit.normal.y < Mathf.Cos(50 * Mathf.Deg2Rad))
            {
                var slideDirection = new Vector3(hit.normal.x, -hit.normal.y, hit.normal.z);
                slope = true;
                _controller.Move(slideDirection * Time.fixedDeltaTime);
            }
            else
            {
                slope = false;
            }
        }*/
        if(!_animator.GetBool("Jump")) //Si jo estic saltant, no vull que es mogui el personatge a menys que tambe mogui el joystick (línia següent: externalMoveSpeed)
            _controller.Move(_moveDirection * Time.deltaTime + externalMoveSpeed * Time.deltaTime);

       // if (transform.position.y < -100) Control.Death();

    }
    private void Update()
    {
        if(canMove)
        {
            if (_jumpingTime > 0) _jumpingTime -= Time.deltaTime; //saltar
            //if (Input.GetKeyDown(KeyCode.Space) && !jumping) jump();
            if (Input.GetKeyDown(KeyCode.Space) && _animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Jump") jump();
            foreach (Touch t in Input.touches) if (t.tapCount == 2 && _animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Jump") jump(); //doble salt em mòbil: no tenim tecla SPACE.
           //CheckPlayerTouch();
        }
        
    }

    private void LateUpdate()
    {
        animate();
    }
    private void animate() //Animator, animacions
    {

        _animator.SetBool("Grounded", !jumping && (_controller.isGrounded || _timeSinceGrounded < _coyoteTime)); //grounded aqui i a animator MATEIX NOM!!
        //_animator.SetBool("InWater", inWater);s

        if (_controller.isGrounded)
        {

            //if (_jumpingTime < 0) _animator.SetBool("Jumping", false);

            if (_horizontal != 0 || _vertical != 0) // != (diferent) Tot es cert a menys que tant vertical com horitzontal siguin falses -> Horiz.= 0, Vert.= 0 => NO MOC JOYSTICK.
            {
                _animator.speed = Mathf.Min(Mathf.Max(Mathf.Abs(_vertical), Mathf.Abs(_horizontal)) + 0.1f, 1); //Canvi de velocitat de l'animació. = Valor Speed al Inspector de cada animació. Es va multiplicant de manera progressiva a mida que movem el joystick-> Joystick full a una direcció -> més ràpid que si està gairebé al centre.
                _animator.SetBool("Walk", true);
            }
            else
            {
                _animator.speed = 1; //no tenim cas de velocitat en variables com a jump.
                _animator.SetBool("Walk", false);
            }

        }
        else
        {
            _animator.speed = 1;
            //jumping = true;
        }
    }
    private void jump() //no preguntarà.
    {

        if (slope) return;
        //if (inWater) return;
        if (_timeSinceGrounded > _coyoteTime) return;

        //GetComponent<Animator>().Play("Jumping", -1, 0);
        jumping = true;
        _timeSinceGrounded = 1;
        _currentFallSpeed = 3;
        //_jumpingTime = 0.5f;
        //AudioManager.PlayJump();
        _animator.SetBool("Jump", true);
        StartCoroutine(StopJumping());
    }
    public IEnumerator StopJumping() // no preguntarà pero basicament això fa que el personatge no es mogui mentres es prepara pel salt. 
    {
        yield return new WaitForSeconds(0.7f);
        _animator.SetBool("Jump", false);
        _moveDirection.y = _jumpForce;
        yield return new WaitForSeconds(_jumpingTime - 0.75f);
        jumping = false;

    }

}