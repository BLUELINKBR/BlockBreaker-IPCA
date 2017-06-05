using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class BlocoAmarelo : TexturedPrimitive
    {
        private Vector2 mDeltaPosition; // Change current position by this amount
        public bool existe;
        public BlocoAmarelo(Vector2 position, Vector2 size) :
        base(Game1.sContent.Load<Texture2D>("Block Breaker Bloco Amarelo"), position, size)
        {
            mDeltaPosition = position;
            mSize = size;
            existe = true;
        }

        public Rectangle GetBounds()
        {
            return new Rectangle(
            (int)mPosition.X,
            (int)mPosition.Y,
            10,
            5);
        }

        public bool CheckCollision(Esfera esfera)
        {
            if (existe && esfera.GetBounds().Intersects(this.GetBounds()))
            {
                Game1.score += 200;
                existe = false;
                esfera.Deflection(this.GetBounds());
                return true;
            }
            return false;
        }

        public void Draw2()
        {
            if (existe)
            {
                Rectangle destRect = Camera.ComputePixelRectangle(mPosition, mSize);
                Game1.sSpriteBatch.Draw(mImage, destRect, Color.White);
            }
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
        }
    }
}