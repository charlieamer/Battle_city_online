using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
namespace Battle_city_online
{
    class Movement
    {
        public enum DIRECTION
	    {
            UP,
            DOWN,
            LEFT,
            RIGHT
	    }
        public long TimeInitiated { get; set; }
        public DIRECTION Direction { get; set; }
        public float Speed { get; set; }

        public Movement(long timeInitiated = 0, DIRECTION direction = DIRECTION.UP, float speed = 1.0f)
        {
            this.Direction = direction;
            this.TimeInitiated = timeInitiated;
            this.Speed = speed;
        }

        public Vector2 GetDisplacement(long currentTime)
        {
            float len = (float)(currentTime - TimeInitiated) * Speed;
            switch (Direction)
            {
                case DIRECTION.UP:
                    return new Vector2(0.0f, -len);
                case DIRECTION.DOWN:
                    return new Vector2(0.0f, len);
                case DIRECTION.LEFT:
                    return new Vector2(-len, 0.0f);
                case DIRECTION.RIGHT:
                    return new Vector2(len, 0.0f);
            }
            return new Vector2();
        }

        public Vector2 GetCurrentPosition(Vector2 position, long currentTime)
        {
            return GetDisplacement(currentTime) + position;
        }
    }
}
