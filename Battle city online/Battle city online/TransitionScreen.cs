using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Battle_city_online
{
    public class TransitionScreen : Screen
    {
        MovableObject upper;
        MovableObject lower;
        long time = 0;

        public TransitionScreen () : base()
        {

            this.upper = new MovableObject();
            this.lower = new MovableObject();
        }
        public override void LoadContent()
        {
            base.LoadContent();
            
            this.upper.LoadContent(this.ContentManager, "workdir/slike/tranPic");
            this.upper.Movement.Direction = Movement.DIRECTION.DOWN;
            this.upper.Position = new Vector2(0, 0 - ScreenManager.Instance.Dimensions.Y / 2);

            this.lower.LoadContent(this.ContentManager, "workdir/slike/tranPic");
            this.lower.Movement.Direction = Movement.DIRECTION.UP;
            this.lower.Position = new Vector2(0, ScreenManager.Instance.Dimensions.Y);
        }
        override public void Update(GameTime time)
        {
            this.time = (long)time.TotalGameTime.TotalMilliseconds / 10;
            if(this.time > (int)ScreenManager.Instance.Dimensions.Y / 2)
            {
                this.upper.Movement.Speed = 0;
                this.lower.Movement.Speed = 0;
            }
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            base.Draw(batch);

            upper.Draw(batch, time);
            lower.Draw(batch, time);

        }


    }
}