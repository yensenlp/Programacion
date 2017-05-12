using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace NaveEspacial
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D naveTextura;
        Texture2D enemigoTextura;
        Texture2D textureMundo;

        Rectangle destRect;
        Rectangle sourceRect;

        float elapsed;
        float delay = 150f;
        int frames = 0;
//        GamePadState gamepadLast;
        KeyboardState keyboardState;
        Vector2 navePosicion;
        Vector2 enemigoPosicion;

        //private Rectangle naveLimite;
        private Rectangle enemigoLimite;
        private Color backgroundColor;

        SoundEffect soundAqua;
        SoundEffect soundExplosion;
        SoundEffectInstance soundEffectUpInstance;
        SoundEffectInstance soundEffectUpInstanceExplosion;

        float retrasoSalir = 150f;
        float tiempoColicion = 150f;
        bool isColiciono;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;            
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 700;
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
            navePosicion = new Vector2(320, 550);
            destRect = new Rectangle(0, 0, 36, 54);
            enemigoPosicion = new Vector2(0, 0);
            isColiciono = false;

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

            naveTextura = Content.Load<Texture2D>(@"Imagenes/Ship_Flying");
            textureMundo = Content.Load<Texture2D>(@"Imagenes/Space Background");
            enemigoTextura = Content.Load<Texture2D>(@"Imagenes/Alien Grabber");

            soundAqua = Content.Load<SoundEffect>(@"Sonidos/14-aquas");
            soundExplosion = Content.Load<SoundEffect>(@"Sonidos/001105163_prev");

            soundEffectUpInstance = soundAqua.CreateInstance();
            soundEffectUpInstanceExplosion = soundExplosion.CreateInstance();
            soundEffectUpInstance.Play();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
        /// 

            
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            

            destRect = new Rectangle((int)navePosicion.X, (int)navePosicion.Y, 36, 54);
            enemigoLimite = new Rectangle((int)enemigoPosicion.X, (int)enemigoPosicion.Y, 60, 60);

            if (enemigoPosicion.X +enemigoTextura.Width < 0) {
                enemigoPosicion.X = 700;
            }

            
            

            if (destRect.Intersects(enemigoLimite))
            {
                Console.WriteLine("coliciono");
                
                soundEffectUpInstanceExplosion.Play();
                tiempoColicion = (float)gameTime.ElapsedGameTime.TotalMilliseconds+3000;
                
                isColiciono = true;
            }

            tiempoColicion -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (isColiciono) {
                if (tiempoColicion <= (float)gameTime.ElapsedGameTime.TotalMilliseconds)
                {
                    Console.WriteLine("salir");
                    UnloadContent();
                    this.Exit();
                }
            }

            keyboardState = Keyboard.GetState();
            

            moverNave(gameTime);
            


            base.Update(gameTime);
        }

        private void moverNave(GameTime gameTime) {

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsed >= delay)
            {
                if (frames >= 3)
                {
                    frames = 0;
                }
                else
                {
                    frames++;
                }
                elapsed = 0;
            }
            sourceRect = new Rectangle(36 * frames, 0, 36, 55);


            // Move threerings based on keyboard input
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Left) || 
                GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed || 
                GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickLeft))
            {
                //mover nave izquiera
                navePosicion.X -= 4f;
            }
            else if (keyboardState.IsKeyDown(Keys.Right) ||
                GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed ||
                GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickRight))
            {
                //mover nave derecha
                navePosicion.X += 4f;
                
            }
            else if (keyboardState.IsKeyDown(Keys.Up) ||
                GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed ||
                GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickUp))
            {
                //moverArriba
                navePosicion.Y -= 4f;
            }
            else if (keyboardState.IsKeyDown(Keys.Down) ||
                GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed ||
                GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickDown))
            {
                //moverAbajo
                navePosicion.Y += 4f;
            }
            else
            {
                //   marioCaminandoDerecha = null;
                //Mario detenido
                //mario.MarioDetener();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            spriteBatch.Begin();

            cargarTexturaNivel();

            spriteBatch.Draw(enemigoTextura, Vector2.Zero, Color.White);
            //spriteBatch.Draw( animacionNave, destRect ,sourceRect, Color.White);
            spriteBatch.Draw(naveTextura, destRect, sourceRect, Color.White);
            spriteBatch.End();

            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        private void cargarTexturaNivel() {
            spriteBatch.Draw(textureMundo, Vector2.Zero,  Color.Blue);
            //spriteBatch.Draw(textureMundo, new Vector2(640,700), Color.Blue);
        }
    }
}
