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
    public class BasketBall : TexturedPrimitive
    {
        private Vector2 mDeltaPosition; // Change current position by this amount
        private const float kIncreaseRate = 1.001f;
        private Vector2 kInitSize = new Vector2(5, 5);
        private const float kFinalSize = 15f;
        public BasketBall(Vector2 position, float diameter) :
        base(Game1.sContent.Load<Texture2D>("BasketBall"), position, new Vector2(diameter, diameter))
        {
            mDeltaPosition.X = (float)(Game1.sRan.NextDouble()) * 2f - 1f;
            mDeltaPosition.Y = (float)(Game1.sRan.NextDouble()) * 2f - 1f;
        }
        public bool UpdateAndExplode()
        {
            mSize *= kIncreaseRate;
            return mSize.X > kFinalSize;
        }
    }
}
