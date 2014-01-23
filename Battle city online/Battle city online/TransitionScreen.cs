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

        public TransitionScreen () : base()
        {

            this.upper = new MovableObject();
            this.lower = new MovableObject();
        }
        public override void LoadContent()
        {
            base.LoadContent();
            this.upper.LoadContent(this.ContentManager, "workdir/slike/tranPic");
            this.lower.LoadContent(this.ContentManager, "workdir/slike/tranPic");
        } 
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            base.Draw(batch);






        }


    }
}