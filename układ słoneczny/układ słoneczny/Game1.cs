using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace układ_słoneczny
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
      
        Matrix worldMatrix;         // macierz świata
        Matrix viewMatrix;          // macierz widoku
        Matrix projectionMatrix;    // macierz projekcji
        SpriteBatch spriteBatch;            // klasa implementująca odpowiednie programy cieniujące
        Cube sun, merkury, wenus, earth, moon,mars;
        KeyboardState keyboardPrevious;
        bool backgroundActive;
        bool netActive;
        float cameraDistance;
        float angleY;
        float angleX;
        NetGenerator net;
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
            sun = new Cube(GraphicsDevice, Color.Yellow, 10, 0.02f,new Vector3(0,0,0),new Vector3(0,0,0));
            merkury = new Cube(GraphicsDevice, Color.Red, 2, 0.01f, new Vector3(0, 0, 0), new Vector3(20, 0, 0));
            wenus = new Cube(GraphicsDevice, Color.OrangeRed, 3, 0.005f, new Vector3(0, 0, 0), new Vector3(20, 0, 0));
            earth = new Cube(GraphicsDevice, Color.LightSeaGreen, 6, 0.003f, new Vector3(0, 0, 0), new Vector3(20, 0, 0));
            moon = new Cube(GraphicsDevice, Color.Gray, 2, 0.008f, earth.basicEffect.World.Translation, new Vector3(10, 0, 0));
            mars = new Cube(GraphicsDevice, Color.Orange, 3, 0.0025f, new Vector3(0, 0, 0), new Vector3(50, 0, 0));
            backgroundActive = true;
            netActive = false;
            cameraDistance = 350f;
            angleY = 0.0f;
            angleX = 0.0f;
            net = new NetGenerator(new Vector2(-80, -80), new Vector2(80, 80));
            // TODO: use this.Content to load your game content here
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
           
            
           
            KeyboardState keyboard = Keyboard.GetState(); // zmienna pomocnicza
            if (keyboard.IsKeyDown(Keys.Escape)) this.Exit();
            if (keyboard.IsKeyDown(Keys.Right))
                angleY++;
            if (keyboard.IsKeyDown(Keys.Left))
                angleY--;
            if (keyboard.IsKeyDown(Keys.Up))
                angleX--;
            if (keyboard.IsKeyDown(Keys.Down))
                angleX++;
            if (keyboard.IsKeyDown(Keys.Q))
                cameraDistance += 0.5f;
            if (keyboard.IsKeyDown(Keys.A))
                cameraDistance -= 0.5f;
            if (keyboard.IsKeyDown(Keys.B) && keyboardPrevious.IsKeyUp(Keys.B))
                backgroundActive = !backgroundActive;
            if (keyboard.IsKeyDown(Keys.X) && keyboardPrevious.IsKeyUp(Keys.X))
                netActive = !netActive;
            viewMatrix = Matrix.CreateLookAt(
                new Vector3(0.0f, 0.0f, cameraDistance),  // położenie kamery (jak na rysunku)
                Vector3.Zero, Vector3.Up);      // cel i orientacja kamery
            viewMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(angleX)) * Matrix.CreateRotationY(MathHelper.ToRadians(angleY))*viewMatrix;
            
            keyboardPrevious = keyboard;

            sun.basicEffect.VertexColorEnabled = true;
            merkury.basicEffect.VertexColorEnabled = true;
            wenus.basicEffect.VertexColorEnabled = true;
            earth.basicEffect.VertexColorEnabled = true;
            moon.basicEffect.VertexColorEnabled = true;
            mars.basicEffect.VertexColorEnabled = true;

            projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(50),
            graphics.GraphicsDevice.Viewport.AspectRatio, 0.1f, 1000.0f);

            sun.update(gameTime, worldMatrix, viewMatrix, projectionMatrix);
            merkury.update(gameTime, worldMatrix, viewMatrix, projectionMatrix);
            wenus.update(gameTime, worldMatrix, viewMatrix, projectionMatrix);
            earth.update(gameTime, worldMatrix, viewMatrix, projectionMatrix);
            moon.rotationCenter = earth.basicEffect.World.Translation;
            moon.update(gameTime, worldMatrix, viewMatrix, projectionMatrix);
            mars.update(gameTime, worldMatrix, viewMatrix, projectionMatrix);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);
            if (netActive) GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, net.GetVertices(), 0, net.GetVerticesLength() / 2);
            sun.Draw();
            merkury.Draw();
            wenus.Draw();
            earth.Draw();
            moon.Draw();
            mars.Draw();
            base.Draw(gameTime);
        }

    }
}
