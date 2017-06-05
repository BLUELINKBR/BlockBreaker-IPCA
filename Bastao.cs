
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Bastao : TexturedPrimitive
    {
        private Vector2 mDeltaPosition; // Change current position by this amount

        public Bastao(Vector2 position, Vector2 size) :
        base(Game1.sContent.Load<Texture2D>("Block Breaker Bastao"), position, size)
        {
            mPosition = position;
            mDeltaPosition = position;
            mSize = size;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(
            (int)mPosition.X - 13,
            (int)mPosition.Y,
            35,
            3);
        }

        public void Update()
        {
            /*Camera.CameraWindowCollisionStatus status =
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
            mPosition += mDeltaPosition;*/
            Camera.CameraWindowCollisionStatus status =
            Camera.CollidedWithCameraWindow(this);
            switch (status)
            {
                case Camera.CameraWindowCollisionStatus.CollideLeft:
                    mPosition.X *= -1;
                    mPosition.X += 61;
                    break;
                case Camera.CameraWindowCollisionStatus.CollideRight:
                    mPosition.X -= 119;
                    break;
            }
            this.Update2(InputWrapper.ThumbSticks.Left);
        }
    }
}
