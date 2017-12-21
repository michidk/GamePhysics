﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Physics
{
    public class Spring : MonoBehaviour
    {

        public MassPoint Point1;
        public MassPoint Point2;
        public float Stiffness = 25.0f;


        private float initialLength;
        private float currentLength;


        void Awake()
        {
            Simulator.Instance.RegisterSpring(this);
        }

        void Start()
        {
            
        }

#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Gizmos.color = Color.Lerp(Color.blue, Color.red, currentLength / initialLength);
            Gizmos.DrawLine(Point1.Position, Point2.Position);
        }
#endif

        public void ApplyElasticForces()
        {
            Vector3 distance = Point1.Position - Point2.Position;
            currentLength = distance.magnitude;
 
            Vector3 force = distance * (-Stiffness * (currentLength - initialLength) / currentLength);
            Point1.Force += force;
            Point2.Force -= force;
        }

    }

}