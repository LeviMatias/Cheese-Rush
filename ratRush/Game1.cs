using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using rbWhitaker.UI;
using rbWhitaker.World;
using System;

namespace rbWhitaker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D background;
        private Player player;
        private MainMenu mainMenu;

        private readonly LaneManager LaneManager = LaneManager.Instance;
        private int score = 0;
        private SpriteFont font;
        private bool isPlaying = false;

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
            // TODO: Add your initialization logic here
            Window.Title = "Cheese Rush";
            graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 600;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            IsMouseVisible = true;

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

            Texture2D ratTexture = Content.Load<Texture2D>("RatAnim");
            player = new Player(new AnimatedSprite(ratTexture, 1, 4), new Vector2(400, 200));

            background = Content.Load<Texture2D>("Grass");
            font = Content.Load<SpriteFont>("Score");
            mainMenu = new MainMenu(Content, spriteBatch, font);
            mainMenu.playButton.MouseClick += StartGame;
            LaneManager.LoadContent(Content);
            ItemFactory.Instance.LoadItems(Content);
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
            if (isPlaying)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                KeyboardState state = Keyboard.GetState();
                player.Update(state);
                LaneManager.Update();
               // score = score + cheeseManager.PlayerTouchesCheese(player);

                if (RandomNumberGenerator.NumberBetween(0, 60) <= 6)
                {
                    //cheeseManager.CreateNewCheese(Content, 800, 600);
                }
            }
            else
            {
                mainMenu.Update();
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            if (isPlaying)
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
                LaneManager.Draw(spriteBatch);
                player.Draw(spriteBatch);

                spriteBatch.DrawString(font, $"Score {score}", Vector2.Zero, Color.White);
            }
            else
            {
                mainMenu.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void StartGame(object sender, EventArgs args)
        {
            isPlaying = true;
        }
    }
}
