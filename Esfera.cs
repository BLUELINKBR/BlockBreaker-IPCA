
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    public class Esfera : TexturedPrimitive
    {
        public Vector2 mDeltaPosition; // Change current position by this amount
        bool colisao;
        public Esfera(Vector2 position, Vector2 size) :
        base(Game1.sContent.Load<Texture2D>("Block Breaker Esfera"), position, size)
        {
            mDeltaPosition.X = 0.8f;
            mDeltaPosition.Y = 0.8f;

        }
        /*public float Radius
        {
            get { return mSize.X * 0.5f; }
            set { mSize.X = 2f * value; mSize.Y = mSize.X; }
        }*/

        public Rectangle GetBounds()
        {
            return new Rectangle(
            (int)mPosition.X,
            (int)mPosition.Y,
            6,
            6);
        }

        public void colisaoBastao(Rectangle bastaoLocation)
        {
            Rectangle ballLocation = new Rectangle(
            (int)mPosition.X,
            (int)mPosition.Y,
            6,
            6);
            if (bastaoLocation.Intersects(ballLocation))
            {
                mDeltaPosition.Y *= -1;
                mPosition += mDeltaPosition;
                mPosition.Y += 1;
            }
        }

        public void Deflection(Rectangle bloco)
        {
            Rectangle ballLocation = new Rectangle(
            (int)mPosition.X,
            (int)mPosition.Y,
            6,
            6);
            if (!colisao)
            {
                int XOverlap;
                int YOverlap;

                if (ballLocation.Center.X < bloco.Center.X)
                {
                    XOverlap = (ballLocation.X + ballLocation.Width) - bloco.X;
                }
                else
                {
                    XOverlap = (bloco.X + bloco.Width) - ballLocation.X;
                }

                if (ballLocation.Center.Y < bloco.Center.Y)
                {
                    YOverlap = (ballLocation.Y + ballLocation.Height) - bloco.Y;
                }
                else
                {
                    YOverlap = (bloco.Y + bloco.Height) - ballLocation.Y;
                }


                if (XOverlap == YOverlap)
                {
                    mDeltaPosition.X *= -1;
                    mDeltaPosition.Y *= -1;
                }
                else if (XOverlap < YOverlap)
                {
                    mDeltaPosition.X *= -1;
                }
                else
                {
                    mDeltaPosition.Y *= -1;
                }
                colisao = true;
            }
        }

        public void Update()
        {
            colisao = false;
            Camera.CameraWindowCollisionStatus status =
            Camera.CollidedWithCameraWindow(this);
            switch (status)
            {
                case Camera.CameraWindowCollisionStatus.CollideBottom:
                    mPosition.X = 30;
                    mPosition.Y = 30;
                    mDeltaPosition.X = 1;
                    mDeltaPosition.Y *= -1;
                    Game1.vida--;
                    //Game1.lifeLost.Play();
                    break;
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
