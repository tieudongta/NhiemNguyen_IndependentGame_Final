using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum Axel
{
    Front,
    Rear
}
[Serializable]
public struct Wheel
{
    public GameObject model;
    public WheelCollider collider;
    public Axel axel;
}

public class CarController : MonoBehaviour
{
    [SerializeField]
    private float maxAcceleration = 20.0f;
    [SerializeField]
    private float turnSensitivity = 1.0f;
    //[SerializeField]
    //private float maxSteerAngle = 45.0f;
    [SerializeField]
    private Vector3 _centerOfMass;
    [SerializeField]
    private List<Wheel> wheels;
    [SerializeField]
    private float motorForce = 50f;
    [SerializeField]
    private float brakeForce = 0f;

    [SerializeField]
    private ParticleSystem expParticle;

    [SerializeField]
    private AudioClip crashSound;
    [SerializeField]
    private AudioClip carSound;

    private AudioSource asPlayer;

    private float inputX, inputY;
    private bool isBreaking;
    private Rigidbody _rb;
    public GameController gameCtrl;
    public bool gameOver = false;
    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = _centerOfMass;
        asPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!gameCtrl.gameOver && MailDrop.mailCount > 0)
        {
            AnimateWheels();
            GetInputs();
            //Debug.Log(MailDrop.mailCount);
        }
        else
        {
            isBreaking = true;
            Brake();
        }
        if (transform.position.y < 0)
        {
            gameCtrl.gameOver = true;
        }
    }

    private void LateUpdate()
    {
        if (!gameCtrl.gameOver && MailDrop.mailCount > 0) {
            Move();
            Turn();
            Brake();
        }
    }
    private void Brake()
    {
        brakeForce = isBreaking ? 3000f : 0f;
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                wheel.collider.motorTorque = inputY * motorForce;
            }
            wheel.collider.brakeTorque = brakeForce;
        }
    }
    private void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
        }
    }
    private void GetInputs()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void Turn()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxAcceleration;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.5f);
            }
        }
    }
    private void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 _pos;
            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("House") || other.gameObject.CompareTag("Vehicle"))
        {
            expParticle.Play();
            gameCtrl.gameOver = true;
            Debug.Log(other.gameObject.tag);
            asPlayer.PlayOneShot(crashSound, 1.0f);
        }
        
    }
}
