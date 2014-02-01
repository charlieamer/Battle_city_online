using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Battle_city_online
{
    class MovableObject:SpriteObject
    {
        public MovableObject(long timeInitiated = 0) : base()
        {
            this.Movement = new Movement(timeInitiated);
        }
        public Movement Movement { get; set; }
        public void Draw(SpriteBatch SpriteBatch, long currentTime)
        {
            Vector2 oldPos = this.Position;
            this.Position = this.Movement.GetCurrentPosition(this.Position, currentTime);
            /*if (this.visible)
            SpriteBatch.Draw(this.Texture, this.Movement.GetCurrentPosition(this.Position, currentTime), this.SourceRect, Color.White, 0.0f, Vector2.Zero, this.Scale, SpriteEffects.None, 0.0f);*/
            base.Draw(SpriteBatch);
            this.Position = oldPos;
        }
    }
}
