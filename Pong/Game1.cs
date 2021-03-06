﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Actors;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ABall aBall;
        APlayer aPlayer1;
        APlayer aPlayer2;
        SpriteFont font;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

           
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            aBall = new ABall(graphics, ActorTag.Ball);
            aPlayer1 = new APlayer(graphics, ActorTag.Player1, PlayerIndex.One, new Vector2(graphics.PreferredBackBufferWidth/2, graphics.PreferredBackBufferHeight-20)); 
            aPlayer2 = new APlayer(graphics, ActorTag.Player2, PlayerIndex.Two, new Vector2(graphics.PreferredBackBufferWidth/2, 20));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Pixel");

            Texture2D texBall = Content.Load<Texture2D>("ball");
            Texture2D texPlayer1 = Content.Load<Texture2D>("barP1");
            Texture2D texPlayer2 = Content.Load<Texture2D>("barP2");

            aBall.LoadContent(texBall);
            aPlayer1.LoadContent(texPlayer1);
            aPlayer2.LoadContent(texPlayer2);


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                GameState currentState = StateManager.GetState();

                if (currentState == GameState.PAUSED)
                {
                    StateManager.Play();
                } else if (currentState == GameState.PLAYING)
                {
                    StateManager.Pause();
                }
            }

            // TODO: Add your update logic here
            aBall.Update(gameTime);
            aPlayer1.Update(gameTime);
            aPlayer2.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            string p1ScoreText = $"P1 Score: {StateManager.ScoreP1}";
            string p2ScoreText = $"P2 Score: {StateManager.ScoreP2}";

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.DrawString(font, p1ScoreText, new Vector2(10, graphics.PreferredBackBufferHeight - 30), Color.LimeGreen);
            spriteBatch.DrawString(font, p2ScoreText, new Vector2(10, 10), Color.IndianRed);

            aBall.Draw(spriteBatch);
            aPlayer1.Draw(spriteBatch);
            aPlayer2.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
