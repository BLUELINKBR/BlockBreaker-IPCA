using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class SoccerBall : TexturedPrimitive
    {
        private Vector2 mDeltaPosition; // Change current position by this amount

        public SoccerBall(Vector2 position, float diameter) :
        base(Game1.sContent.Load<Texture2D>("Soccer"), position, new Vector2(diameter, diameter))
        {
            mDeltaPosition.X = (float)(Game1.sRan.NextDouble()) * 2f - 1f;
            mDeltaPosition.Y = (float)(Game1.sRan.NextDouble()) * 2f - 1f;
        }
        public float Radius
        {
            get { return mSize.X * 0.5f; }
            set { mSize.X = 2f * value; mSize.Y = mSize.X; }
        }

        public void Update()
        {
            Camera.CameraWindowCollisionStatus status =
            Camera.CollidedWithCameraWindow(this);
            switch (status)
            {
                case Camera.CameraWindowCollisionStatus.CollideBottom:
                case Camera.CameraWindowCollisionStatus.CollideTop:
                    mDeltaPosition.Y *= -1;
                    break;
                case Camera.CameraWindowCollisionStatus.CollideLeft:
                case Camera.CameraWindowCollisionStatus.CollideRight:
                    mDeltaPosition.X *= -1;
                    break;
            }
            mPosition += mDeltaPosition;
        }
    }
}
