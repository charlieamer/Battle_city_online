using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Battle_city_online
{
    class NamedSpriteObject : MovableObject
    {
        Dictionary<string, Rectangle> rectangles;
        public void LoadContent(ContentManager ContentManager, string SheetPath, string XmlPath)
        {
            base.LoadContent(ContentManager, SheetPath);
            this.rectangles = new Dictionary<string,Rectangle>();
            XmlReader reader = XmlReader.Create(XmlPath);
            string name;
            Rectangle rect;
            while (!reader.EOF)
            {
                reader.Read();
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Sprite")
                {
                    name = reader.GetAttribute("name");
                    rect = new Rectangle();
                    while (reader.NodeType != XmlNodeType.EndElement || reader.Name != "Sprite")
                    {
                        reader.Read();
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "x")
                            {
                                while (reader.NodeType != XmlNodeType.Text) reader.Read();
                                rect.X = int.Parse(reader.Value);
                            }
                            if (reader.Name == "y")
                            {
                                while (reader.NodeType != XmlNodeType.Text) reader.Read();
                                rect.Y = int.Parse(reader.Value);
                            }
                            if (reader.Name == "width")
                            {
                                while (reader.NodeType != XmlNodeType.Text) reader.Read();
                                rect.Width = int.Parse(reader.Value);
                            }
                            if (reader.Name == "height")
                            {
                                while (reader.NodeType != XmlNodeType.Text) reader.Read();
                                rect.Height = int.Parse(reader.Value);
                            }
                        }
                    }
                    this.rectangles[name] = rect;
                }
            }
        }
        public void setSprite(string name)
        {
            this.SourceRect = this.rectangles[name];
        }
    }
}
