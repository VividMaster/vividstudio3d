﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using Vivid.App;
namespace Vivid.Scene
{
    public class VCam : VSceneNode
    {
        public Vector3 LR = new Vector3(0, 0, 0);
        public Matrix4 ProjMat
        {
            get
            {
                return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(FOV), AppInfo.RW / AppInfo.RH, MinZ, MaxZ);
            }
        }
        public override void Rot(Vector3 r, Space s)
        {
            LR = r;
            CalcMat();
        }
        public override void Turn(Vector3 t,Space s)
        {
            LR = LR + t;
            LR.Z = 0;
            CalcMat();
        }
        public void CalcMat()
        {
            LR.X = Wrap(LR.X);
            LR.Y = Wrap(LR.Y);
            LR.Z = Wrap(LR.Z);
            var r = LR;
            Matrix4 t = Matrix4.RotateY(MathHelper.DegreesToRadians(r.Y)) * Matrix4.RotateX(MathHelper.DegreesToRadians(r.X)) * Matrix4.RotateZ(MathHelper.DegreesToRadians(r.Z));
            LocalTurn = t;
        }
        public float Wrap(float v)
        {
            if(v<0)
            {
                v = 360 + v;
            }
            if(v>360)
            {
                v = v - 360;
            }
            if (v < 0 || v > 360) return Wrap(v);
            return v;
        }

        public float FOV = 35;
        public bool DepthTest = true;
        public bool AlphaTest = false;
        public bool CullFace = true;
        public float MinZ = 1f, MaxZ = 700;
        public VCam()
        {
           
        }
        public Matrix4 CamWorld
        {
            get
            {

                return World;
            }
        }
    }
}
