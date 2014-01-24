using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
namespace Battle_city_online
{
    class SpriteObject:GameObject
    {
        protected Rectangle SourceRect;
        protected Texture2D Texture;

        public Vector2 Scale { get; set; }

        public SpriteObject() : base()
        {
            this.Scale = new Vector2(1.0f, 1.0f);
        }

        private void Load(ContentManager ContentManager, string Path)
        {
            Console.Write("Loading texture '" + Path + "' ... ");
            base.LoadContent(ContentManager);
            this.Texture = this.ContentManager.Load<Texture2D>(Path);
            Console.WriteLine("ok");
        }

        public void LoadContent(ContentManager ContentManager, string Path)
        {
            this.Load(ContentManager, Path);
            this.SourceRect = this.Texture.Bounds;
        }

        public void LoadContent(ContentManager ContentManager, string Path, Rectangle SourceRect)
        {
            this.Load(ContentManager, Path);
            this.SourceRect = SourceRect;
        }

        override public void Draw(SpriteBatch SpriteBatch)
        {
            SpriteBatch.Draw(this.Texture, this.Position, this.SourceRect, Color.White, 0.0f, Vector2.Zero, this.Scale, SpriteEffects.None, 0.0f);
        }

    }
}
