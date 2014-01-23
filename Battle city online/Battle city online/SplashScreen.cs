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

        public SplashScreen () : base()
        {
            

        }

        public override void LoadContent()
        {
            base.LoadContent();
            splashImg = new SpriteObject ();
            splashImg.LoadContent(this.ContentManager, "workdir/slike/podovi");
        }
        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            splashImg.Draw(batch);
        }

        public override void Update(GameTime time)
        {
            base.Update(time);
            if(time.ElapsedGameTime.Seconds > 3)
            {
                ScreenManager.Instance.SetNewScreen(new TestScreen());
                Console.WriteLine("hepek");
            }
        }

    }
}
