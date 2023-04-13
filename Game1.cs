using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lesson_3___Animation
{
    public class Game1 : Game
    {
        Random generator = new Random();

        Texture2D tribbleGreyTexture, tribbleBrownTexture, tribbleCreamTexture, tribbleOrangeTexture;

        Rectangle tribbleGreyRect, tribbleBrownRect, tribbleCreamRect, tribbleOrangeRect;

        Vector2 tribbleGreySpeed, tribbleBrownSpeed, tribbleCreamSpeed, tribbleOrangeSpeed;

        Color backColor;

        int randomX, randomY, randomBrownXSpeed, randomBrownYSpeed;
        int randomGreyX, randomGreyY, randomBrownStartXSpeed, randomBrownStartYSpeed;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            this.Window.Title = "Animation";

            randomX = generator.Next(0, 700);
            randomY = generator.Next(0, 500);

            randomBrownStartXSpeed = generator.Next(1, 5);
            randomBrownStartYSpeed = generator.Next(1, 5);

            tribbleGreyRect = new Rectangle(randomX, randomY, 100, 100);
            tribbleBrownRect = new Rectangle(randomX, randomY, 100, 100);
            tribbleCreamRect = new Rectangle(randomX, randomY, 100, 100);
            tribbleOrangeRect = new Rectangle(randomX, randomY, 100, 100);

            backColor= Color.White;

            tribbleGreySpeed = new Vector2(2, 2);
            tribbleBrownSpeed = new Vector2(randomBrownStartXSpeed, randomBrownStartYSpeed);
            tribbleCreamSpeed = new Vector2(5, 0);
            tribbleOrangeSpeed = new Vector2(0, 3);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // TRIBBLE MOVEMENT
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;

            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;

            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;

            tribbleOrangeRect.X -= (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y -= (int)tribbleOrangeSpeed.Y;

            randomBrownXSpeed = generator.Next(1, 11);
            randomBrownYSpeed = generator.Next(1, 11);

            randomGreyX = generator.Next(1, 700);
            randomGreyY = generator.Next(1, 500);

            // EDGE DETECTION
            //grey
            if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth || tribbleGreyRect.Left < 0)
            {
                tribbleGreyRect.X = randomGreyX;
                tribbleGreyRect.Y = randomGreyY;
                tribbleGreySpeed.X = generator.Next(1, 6);
                tribbleGreySpeed.Y = generator.Next(1, 6);
                tribbleGreySpeed.X *= -1;
                backColor = Color.Gray;
            }
            if (tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleGreyRect.Top < 0)
            {
                tribbleGreyRect.X = randomGreyX;
                tribbleGreyRect.Y = randomGreyY;
                tribbleGreySpeed.X = generator.Next(1, 6);
                tribbleGreySpeed.Y = generator.Next(1, 6);
                tribbleGreySpeed.Y *= -1;
                backColor = Color.Gray;
            }
            //brown
            if (tribbleBrownRect.Left > _graphics.PreferredBackBufferWidth || tribbleBrownRect.Right < 0)
            {
                if (tribbleBrownRect.Left > _graphics.PreferredBackBufferWidth)
                    tribbleBrownRect.X = -100;
                if (tribbleBrownRect.Right < 0)
                    tribbleBrownRect.X = 800;
                tribbleBrownSpeed.X = randomBrownXSpeed;
                backColor = Color.SaddleBrown;
            }
            if (tribbleBrownRect.Top > _graphics.PreferredBackBufferHeight || tribbleBrownRect.Bottom < 0)
            {
                if (tribbleBrownRect.Top > _graphics.PreferredBackBufferHeight)
                    tribbleBrownRect.Y = -100;
                if (tribbleBrownRect.Bottom < 0)
                    tribbleBrownRect.Y = 600;
                tribbleBrownSpeed.Y = randomBrownYSpeed;
                backColor = Color.SaddleBrown;
            }
            //cream
            if (tribbleCreamRect.Right > _graphics.PreferredBackBufferWidth || tribbleCreamRect.Left < 0)
            {
                tribbleCreamSpeed.X *= -1;
                backColor = Color.Beige;
            }
            if (tribbleCreamRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleCreamRect.Top < 0)
            {
                tribbleCreamSpeed.Y *= -1;
                backColor = Color.Beige;
            }
            //orange
            if (tribbleOrangeRect.Right > _graphics.PreferredBackBufferWidth || tribbleOrangeRect.Left < 0)
            {
                tribbleGreySpeed.X *= -1;
                backColor = Color.Gray;
            }
            if (tribbleOrangeRect.Bottom > _graphics.PreferredBackBufferHeight || tribbleOrangeRect.Top < 0)
            {
                tribbleOrangeSpeed.Y *= -1;
                backColor = Color.Orange;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backColor);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}