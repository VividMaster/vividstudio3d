﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.Texture;
using Vivid.App;
using Vivid.Draw;
namespace Vivid.UI
{
    public class UISkin
    {
        public VTex2D But_Norm;
        public VTex2D But_Hover;
        public VTex2D But_Press;
        public UISkin()
        {
            InitSkin();
        }
        public virtual void InitSkin()
        {

        }
        public virtual void DrawButton(float x, float y, float w,float h,ButState bs)
        {

        }
        public VTex2D StateImg(ButState bs)
        {
            VTex2D bi = null;
            switch (bs)
            {
                case ButState.Norm:
                    bi = But_Norm;
                    break;
                case ButState.Hover:
                    bi = But_Hover;
                    break;
                case ButState.Press:
                    bi = But_Press;
                    break;
            }

            return bi;
        }
    }
    public enum ButState
    {
        Norm,Hover,Press
    }
}