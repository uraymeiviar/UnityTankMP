﻿using UnityEngine;namespace UniTank{    public class TankKinematicController : TankController    {        public float moveSpeed = 10.0f;        public float turnSpeed = 100.0f;        protected Rigidbody body;        protected TankDriveController driveController;        public override void Reset()        {            base.Reset();            this.body.velocity = Vector3.zero;            this.body.angularVelocity = Vector3.zero;            this.gameObject.transform.position = this.GetGame().arena.GetTankSpawnPoint(this.tank).position;            this.gameObject.transform.rotation = this.GetGame().arena.GetTankSpawnPoint(this.tank).rotation;        }        public override void Init(Tank tank)        {            base.Init(tank);            this.body = this.gameObject.GetComponent<Rigidbody>();            this.driveController = this.tank.gameObject.GetComponent<TankDriveController>();        }        protected void FixedUpdate()        {            Transform transform = body.gameObject.transform;            float moveFactor = Mathf.MoveTowards(this.driveController.currentMoveValue, 0.0f, 0.1f * Mathf.Abs(this.driveController.currentTurnValue));            Vector3 movement = transform.forward * moveFactor * this.moveSpeed * Time.fixedDeltaTime;            this.body.MovePosition(transform.position + movement);            float turnMovement = this.driveController.currentTurnValue * this.turnSpeed * Time.deltaTime;            float turnFactor = Mathf.MoveTowards(turnMovement, 0.0f, 0.1f * Mathf.Abs(this.driveController.currentMoveValue));            Quaternion turnRotation = Quaternion.Euler(0f, turnFactor, 0f);            this.body.MoveRotation(transform.rotation * turnRotation);        }    }}