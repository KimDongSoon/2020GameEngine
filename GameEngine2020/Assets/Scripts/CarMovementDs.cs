﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementDs : MonoBehaviour
{
    //public WheelCollider[] wheels = new WheelCollider[4]; //휠 콜라이더를 받아온다.

    //public Transform[] tires = new Transform[4]; //바퀴가 돌아가는 걸 표현하기위한 메쉬를 받아온다.



    //public float maxF = 50.0f; //자동차바퀴를 돌리는 힘

    //public float power = 3000.0f; //자동차를 밀어주는 힘(바퀴만으로는 너무 느리다..)

    //public float rot = 45;



    //Rigidbody rb;



    //void Start()

    //{

    //    rb = GetComponent<Rigidbody>(); //리지드바디를 받아온다.



    //    for (int i = 0; i < 4; i++)

    //    {

    //        wheels[i].steerAngle = 0; //만약 바퀴와 휠콜라이더의 방향이 교차한다면 90으로 설정해주자.

    //        wheels[i].ConfigureVehicleSubsteps(5, 12, 13);

    //    }

    //    rb.centerOfMass = new Vector3(0, 0, 0); //무게중심을 가운데로 맞춰서 안정적으로 주행하도록 한다.

    //}



    //private void Update()
    //{
    //    UpdateMeshesPostion(); //바퀴가 돌아가는게 보이도록 함
    //}



    //void FixedUpdate()
    //{

    //    float a = Input.GetAxis("Vertical");

    //    rb.AddForce(transform.rotation * new Vector3(0, 0, a * power)); //뒤에서 밀어준다.

    //    for (int i = 0; i < 4; i++)
    //    {
    //        wheels[i].motorTorque = maxF * a; //바퀴를 돌린다.
    //    }

    //    float steer = rot * Input.GetAxis("Horizontal");

    //    for (int i = 0; i < 2; i++) //앞바퀴만 회전한다.
    //    {
    //        wheels[i].steerAngle = steer; //여기도 바퀴와 콜라이더가 직각인사람은 + 90을 해줘야한다.
    //    }

    //}



    //void UpdateMeshesPostion()
    //{
    //    for (int i = 0; i < 4; i++)
    //    {
    //        Quaternion quat;

    //        Vector3 pos;

    //        wheels[i].GetWorldPose(out pos, out quat);

    //        tires[i].position = pos;
    //        tires[i].rotation = quat;
    //    }
    //}

    public Transform[] wheels;
    public float motorPower = 150.0f;
    public float maxTurn = 25.0f;

    float instantPower = 0.0f;
    float brake = 0.0f;
    float wheelTurn = 0.0f;

    Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = this.gameObject.GetComponent<Rigidbody>();
        myRigidbody.centerOfMass = new Vector3(0, -0.5f, 0.3f);
    }

    void Update()
    {
        instantPower = Input.GetAxis("Vertical") * motorPower * Time.deltaTime;
        wheelTurn = Input.GetAxis("Horizontal") * maxTurn;
        //brake = Input.GetKeyDown("Space") ? myRigidbody.mass * 0.1f : 0.0f;

        //turn collider
        GetCollider(0).steerAngle = wheelTurn;
        GetCollider(1).steerAngle = wheelTurn;

        //turn wheels
        wheels[0].localEulerAngles = new Vector3(wheels[0].localEulerAngles.x, 
            GetCollider(0).steerAngle - wheels[0].localEulerAngles.z + 90, wheels[0].localEulerAngles.z);
        wheels[1].localEulerAngles = new Vector3(wheels[1].localEulerAngles.x,
            GetCollider(1).steerAngle - wheels[1].localEulerAngles.z + 90, wheels[0].localEulerAngles.z);

        // spin wheels
        wheels[0].Rotate(0, -GetCollider(0).rpm / 60 * 360 * Time.deltaTime, 0);
        wheels[1].Rotate(0, -GetCollider(0).rpm / 60 * 360 * Time.deltaTime, 0);
        wheels[2].Rotate(0, -GetCollider(0).rpm / 60 * 360 * Time.deltaTime, 0);
        wheels[3].Rotate(0, -GetCollider(0).rpm / 60 * 360 * Time.deltaTime, 0);

        // brakes
        if(brake > 0.0f)
        {
            GetCollider(0).brakeTorque = brake;
            GetCollider(1).brakeTorque = brake;
            GetCollider(2).brakeTorque = brake;
            GetCollider(3).brakeTorque = brake;

            GetCollider(2).brakeTorque = 0.0f;
            GetCollider(3).brakeTorque = 0.0f;
        }
        else
        {
            GetCollider(0).brakeTorque = 0.0f;
            GetCollider(1).brakeTorque = 0.0f;
            GetCollider(2).brakeTorque = 0.0f;
            GetCollider(3).brakeTorque = 0.0f;

            GetCollider(2).brakeTorque = instantPower;
            GetCollider(3).brakeTorque = instantPower;
        }
    }

    WheelCollider GetCollider(int n)
    {
        return wheels[n].gameObject.GetComponent<WheelCollider>();

    }
}
