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
    public class SplashScreen : Screen
    {
        SpriteObject splashImg;
        TextObject textObj;

        public SplashScreen () : base()
        {
            textObj = new TextObject("test");
            textObj.Position = new Vector2(20, 100);
            textObj.Text = "Vidis da radi buhahaahaha :P";
            this.splashImg = new SpriteObject();
        }

        public override void LoadContent()
        {
            base.LoadContent();
            this.splashImg.LoadContent(this.ContentManager, "workdir/slike/podovi");
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            this.splashImg.Draw(batch);
            this.textObj.Draw(batch);
        }

        public override void Update(GameTime time)
        {
            base.Update(time);

            if(time.TotalGameTime.Seconds > 3)
            {
                ScreenManager.Instance.SetNewScreen(new TransitionScreen());
            }
        }

    }
}
