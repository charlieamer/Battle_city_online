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
        private Screen CurrentScreen, NewScreen;
        long time = 0;

        public TransitionScreen (Screen noviScreen, String text) : base()
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
            this.upper.Scale = new Vector2(ScreenManager.Instance.Dimensions.X, ScreenManager.Instance.Dimensions.Y / 2);

            this.lower.LoadContent(this.ContentManager, "workdir/slike/tranPic");
            this.lower.Movement.Direction = Movement.DIRECTION.UP;
            this.lower.Position = new Vector2(0, ScreenManager.Instance.Dimensions.Y);
            this.lower.Scale = new Vector2(ScreenManager.Instance.Dimensions.X, ScreenManager.Instance.Dimensions.Y / 2);
        }
        override public void Update(GameTime time)
        {
            this.time = (long)time.TotalGameTime.TotalMilliseconds / 2;
            if(this.time > (int)ScreenManager.Instance.Dimensions.Y / 2)
            {
                this.upper.Position = new Vector2(0, 0);
                this.upper.Movement.Speed = 0;

                this.lower.Movement.Speed = 0;
                this.lower.Position = new Vector2(0, 0 + ScreenManager.Instance.Dimensions.Y /2);
            }

    public void UnloadContent()
        {
            this.CurrentScreen.UnloadContent();
        }

            if (this.NewScreen != null)
            {
                if (this.CurrentScreen != null)
                    this.CurrentScreen.UnloadContent();
                this.CurrentScreen = this.NewScreen;
                this.CurrentScreen.LoadContent();
                this.NewScreen = null;
                this.ScreenTime = gameTime.TotalGameTime;
                gameTime.TotalGameTime -= this.ScreenTime;
            }
            if (this.CurrentScreen != null)
            {
                this.CurrentScreen.Update(gameTime);
            }
        }
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            base.Draw(batch);

            upper.Draw(batch, time);
            lower.Draw(batch, time);
            
            if(this.time > (int)ScreenManager.Instance.Dimensions.Y / 2)
            {
                //pokazi text
            }

        }


    }
}