using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PonZ.Sprites;

namespace PonZ.Managers
{
    public class AsteroidManager
    {
        private float _timer;

        private List<Texture2D> _textures;

        public bool CanAdd { get; set; }

        public Bullet Bullet { get; set; }

        public int MaxAsteroids { get; set; }

        public float SpawnTimer { get; set; }

        public AsteroidManager(ContentManager content)
        {
            _textures = new List<Texture2D>()
      {
        content.Load<Texture2D>("Obstacles/Asteroid"),
      };

            MaxAsteroids = 5;
            SpawnTimer = 3.5f;
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            CanAdd = false;

            if (_timer > SpawnTimer)
            {
                CanAdd = true;

                _timer = 0;
            }
        }

        public Asteroid GetAsteroid()
        {
            var texture = _textures[Game1.Random.Next(0, _textures.Count)];

            return new Asteroid(texture)
            {
                Colour = Color.Gray,
                Health = 5,
                Layer = 0.3f,
                Position = new Vector2(Game1.ScreenWidth + texture.Width, Game1.Random.Next(0, Game1.ScreenHeight)),
                Speed = 1 + (float)Game1.Random.NextDouble(),
            };
        }
    }
}
