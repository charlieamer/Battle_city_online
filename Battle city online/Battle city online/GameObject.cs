using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Battle_city_online
{
    abstract class GameObject
    {
        protected ContentManager ContentManager;
        public Vector2 Position = new Vector2(0, 0);
        public virtual void LoadContent(ContentManager ContentManager)
        {
            this.ContentManager = ContentManager;
        }
        public virtual void UnloadContent()
        {
            //this.ContentManager.Unload();
        }
        public virtual void Update(GameTime time)
        {
        }
        public virtual void Draw(SpriteBatch batch)
        {
        }
    }
}
