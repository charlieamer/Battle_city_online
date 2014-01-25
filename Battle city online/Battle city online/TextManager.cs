using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Battle_city_online
{
    class TextManager
    {
        private static TextManager instance;
        private XmlReader reader;
        private Dictionary<string, FontData> fonts = new Dictionary<string,FontData>();
        private Dictionary<string, Texture2D> textures = new Dictionary<string,Texture2D>();
        private ContentManager contentManager;
        public static TextManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TextManager();
                }
                return instance;
            }
        }
        private TextManager()
        {
            this.contentManager = new ContentManager(ScreenManager.Instance.ServiceProvider);
            this.LoadFont("workdir/fontovi/cells.xml");
        }

        private FontData ReadFont(FontData data)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "font")
                    {
                        data = ReadFontData(data);
                    }
                }
            }
            return data;
        }

        private FontData ReadFontData(FontData data)
        {
            data.name = reader.GetAttribute("name");
            data.texture = reader.GetAttribute("texture");
            while (reader.NodeType != XmlNodeType.EndElement ||reader.Name != "font")
            {
                reader.Read();
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "spacing")
                    {
                        data = ReadFontSpacing(data);
                    }
                    if (reader.Name == "characters")
                    {
                        data.characterMap += reader.GetAttribute("value");
                    }
                }
            }
            return data;
        }

        private FontData ReadFontNormalSpacing(FontData data)
        {
            while (reader.NodeType != XmlNodeType.EndElement || reader.Name != "spacing")
            {
                reader.Read();
                if (reader.Name == "x")
                {
                    while (reader.NodeType != XmlNodeType.Text) reader.Read();
                    data.spacingX = int.Parse(reader.Value);
                    while (reader.NodeType != XmlNodeType.EndElement) reader.Read();
                }
                if (reader.Name == "y")
                {
                    while (reader.NodeType != XmlNodeType.Text) reader.Read();
                    data.spacingX = int.Parse(reader.Value);
                    while (reader.NodeType != XmlNodeType.EndElement) reader.Read();
                }
            }
            return data;
        }

        private FontData ReadFontSpacing(FontData data)
        {
            if (reader.GetAttribute("type") == "Constant Number")
            {
                data.spacing = FontData.Spacing.CONSTANT_NUMBER;
                data = ReadFontNormalSpacing(data);
            }
            if (reader.GetAttribute("type") == "Constant Dimension")
            {
                data.spacing = FontData.Spacing.CONSTANT_DIMENSION;
                data = ReadFontNormalSpacing(data);
            }
            return data;
        }

        public void LoadFont(string path)
        {
            Console.Write("Loading font '" + path + "' ... ");
            this.reader = XmlReader.Create(path);
            FontData data = new FontData();
            data = this.ReadFont(data);
            this.fonts[data.name] = data;
            if (!this.textures.ContainsKey(data.texture))
            {
                this.textures[data.texture] = this.contentManager.Load<Texture2D>(data.texture);
            }
            Console.WriteLine("ok");
        }
        
        public void Draw(string fontName, string text, Vector2 position, SpriteBatch batch)
        {
            Draw(fontName, text, position, batch, Color.White);
        }

        public void Draw(string fontName, string text, Vector2 position, SpriteBatch batch, Color color)
        {
            FontData font = this.fonts[fontName];
            Texture2D texture = this.textures[font.texture];
            int width = font.spacingX;
            int height = font.spacingY;
            Rectangle rect = new Rectangle();
            Vector2 currentPosition = new Vector2();
            currentPosition.X = position.X;
            currentPosition.Y = position.Y;
            if (font.spacing == FontData.Spacing.CONSTANT_NUMBER)
            {
                width = texture.Width / font.spacingX;
                height = texture.Width / font.spacingX;
            }
            int index=-1;
            if (font.spacing == FontData.Spacing.CONSTANT_NUMBER)
            {
                rect.Width = width - 2;
                rect.Height = height - 2;
            }
            foreach (char c in text)
            {
                index++;
                int pos = font.characterMap.IndexOf(c);
                if (pos == -1) continue;
                if (font.spacing == FontData.Spacing.CONSTANT_NUMBER)
                {
                    rect.X = (pos % (texture.Width / width)) * width + 1;
                    rect.Y = (pos / (texture.Width / width)) * width + 1;
                }
                currentPosition.X += rect.Width;
                batch.Draw(texture, currentPosition, rect, color);
            }
        }

        public Vector2 GetSize(string fontName, string text)
        {
            FontData font = this.fonts[fontName];
            Texture2D texture = this.textures[font.texture];
            int width, height;
            if (font.spacing == FontData.Spacing.CONSTANT_NUMBER)
            {
                width = texture.Width / font.spacingX;
                height = texture.Width / font.spacingX;
                return new Vector2(width * text.Length, height);
            }
            return Vector2.Zero;
        }
    }
}
