using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        static public SpriteBatch sSpriteBatch; // Drawing support
        static public ContentManager sContent; // Loading textures
        static public GraphicsDeviceManager sGraphics; // Current display size
        static public Random sRan; // For generating random numbers
        static public int vida;
        static public int score;
        static public int blocosNaTela;
        static public int nivelAtual;
        static public TexturedPrimitive[] placarVida;
        TexturedPrimitive mUWBLogo;
        SoccerBall mBall;
        Esfera mEsfera;
        Bastao mBastao;
        //BlocoAzul mBloco;
        //nivel 1
        BlocoAzul[] mBlocoAzulNivel1;
        //nivel 2
        BlocoAzul[] mBlocoAzulNivel2;
        BlocoAmarelo[] mBlocoAmareloNivel2;
        BlocoAzul[] mBlocoAmareloQuebradoNivel2;
        int[] timerBlocoAmareloNivel2;
        bool[] timerBlocoAmareloNivel2existing;
        //nivel 3
        BlocoAzul[] mBlocoAzulNivel3;
        BlocoAmarelo[] mBlocoAmareloNivel3;
        BlocoAzul[] mBlocoAmareloQuebradoNivel3;
        int[] timerBlocoAmareloNivel3;
        bool[] timerBlocoAmareloNivel3existing;
        //nivel 4
        BlocoAzul[] mBlocoAzulNivel4;
        BlocoAmarelo[] mBlocoAmareloNivel4;
        BlocoAzul[] mBlocoAmareloQuebradoNivel4;
        int[] timerBlocoAmareloNivel4;
        bool[] timerBlocoAmareloNivel4existing;
        BlocoMarrom[] mBlocoMarromNivel4;
        BlocoAmarelo[] mBlocoMarromQuebradoNivel4;
        int[] timerBlocoMarromNivel4;
        bool[] timerBlocoMarromNivel4existing;
        BlocoAzul[] mBlocoMarromQuebrado2Nivel4;
        int[] timerBlocoMarrom2Nivel4;
        bool[] timerBlocoMarrom2Nivel4existing;
        //nivel 5
        BlocoAzul[] mBlocoAzulNivel5;
        BlocoAmarelo[] mBlocoAmareloNivel5;
        BlocoAzul[] mBlocoAmareloQuebradoNivel5;
        int[] timerBlocoAmareloNivel5;
        bool[] timerBlocoAmareloNivel5existing;
        BlocoMarrom[] mBlocoMarromNivel5;
        BlocoAmarelo[] mBlocoMarromQuebradoNivel5;
        int[] timerBlocoMarromNivel5;
        bool[] timerBlocoMarromNivel5existing;
        BlocoAzul[] mBlocoMarromQuebrado2Nivel5;
        int[] timerBlocoMarrom2Nivel5;
        bool[] timerBlocoMarrom2Nivel5existing;
        BlocoVermelho[] mBlocoVermelhoNivel5;
        BlocoMarrom[] mBlocoVermelhoQuebradoNivel5;
        int[] timerBlocoVermelhoNivel5;
        bool[] timerBlocoVermelhoNivel5existing;
        BlocoAmarelo[] mBlocoVermelhoQuebrado2Nivel5;
        int[] timerBlocoVermelho2Nivel5;
        bool[] timerBlocoVermelho2Nivel5existing;
        BlocoAzul[] mBlocoVermelhoQuebrado3Nivel5;
        int[] timerBlocoVermelho3Nivel5;
        bool[] timerBlocoVermelho3Nivel5existing;
        //fim dos niveis
        Texture2D background;
        Texture2D[] levels;
        Vector2 mSoccerPosition = new Vector2(50, 50);
        float mSoccerBallRadius = 3f;
        Vector2 mEsferaPosition = new Vector2(30, 30);
        float mEsferaRadius = 3f;
        Vector2 mEsferaSize = new Vector2(6, 6);
        Vector2 mBastaoPosition = new Vector2(60, 25);
        Vector2 mBastaoSize = new Vector2(40, 3);
        Vector2 mBlocoPosition = new Vector2(0, 100);
        Vector2 mBlocoSize = new Vector2(10, 5);
        Vector2 mVidaPosition = new Vector2(15, 90);
        Vector2 mVidaSize = new Vector2(5, 5);
        //static public SoundEffect lifeLost;
        //static public SoundEffect stageClear;
        //GraphicsDeviceManager mGraphics;
        //SpriteBatch mSpriteBatch;
        // Support for loading and drawing the JPG image
        //Texture2D mJPGImage; // The UWB-JPG.jpg image to be loaded
        //Vector2 mJPGPosition; // Top-Left pixel position of UWB-JPG.jpg
        // Support for loading and drawing of the PNG image
        //Texture2D mPNGImage; // The UWB-PNG.png image to be loaded
        //Vector2 mPNGPosition; // Top-Left pixel position of UWB-PNG.png
        // Prefer window size
        const int kWindowWidth = 800;
        const int kWindowHeight = 600;
        const int kNumObjects = 4;
        MyGame mTheGame;

        // Work with the TexturedPrimitive class
        TexturedPrimitive[] mGraphicsObjects; // An array of objects
        int mCurrentIndex = 0;
        public Game1()
        {
            sGraphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Game1.sContent = Content;
            Game1.sRan = new Random();
            // Set preferred window size
            Game1.sGraphics.PreferredBackBufferWidth = kWindowWidth;
            Game1.sGraphics.PreferredBackBufferHeight = kWindowHeight;
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
            // Initialize the initial image positions.
            // mJPGPosition = new Vector2(10f, 10f);
            // mPNGPosition = new Vector2(100f, 100f);
            //mGraphicsObjects = new TexturedPrimitive[kNumObjects];
            // Important to let the base class perform its initialization
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            Game1.sSpriteBatch = new SpriteBatch(GraphicsDevice);
            //mSpriteBatch = new SpriteBatch(GraphicsDevice);

            // Define camera window bounds
            Camera.SetCameraWindow(new Vector2(10f, 20f), 100f);

            // Create the primitives.
            mGraphicsObjects = new TexturedPrimitive[kNumObjects];
            mGraphicsObjects[0] = new TexturedPrimitive(
           Content.Load<Texture2D>("UWB-JPG"), // Image file name
           new Vector2(15f, 25f), // Position to draw
           new Vector2(10f, 10f)); // Size to draw 
                                   //new Vector2(10, 10), // Position to draw
                                   //new Vector2(30, 30)); // Size to draw
            mGraphicsObjects[1] = new TexturedPrimitive(
            Content.Load<Texture2D>("UWB-JPG"),
            new Vector2(35f, 60f),
            new Vector2(50f, 50f));
            //new Vector2(200, 200),
            //new Vector2(100, 100));
            mGraphicsObjects[2] = new TexturedPrimitive(
           Content.Load<Texture2D>("UWB-PNG"),
           new Vector2(105f, 25f),
           new Vector2(10f, 10f));
            //new Vector2(50, 10),
            //new Vector2(30, 30));
            mGraphicsObjects[3] = new TexturedPrimitive(
           Content.Load<Texture2D>("UWB-PNG"),
           new Vector2(90f, 60f),
           new Vector2(35f, 35f));
            //new Vector2(50, 200),
            //new Vector2(100, 100));
            mUWBLogo = new TexturedPrimitive(Content.Load<Texture2D>("UWB-PNG"), new Vector2(30, 30), new Vector2(20, 20));
            vida = 5;
            score = 0;
            placarVida = new TexturedPrimitive[10];
            blocosNaTela = 0;
            nivelAtual = 1;
            int posicaoX = 13;
            int posicaoY = 92;
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                placarVida[i] = new TexturedPrimitive(Content.Load<Texture2D>("Block Breaker Esfera"), mVidaPosition, mVidaSize);
                placarVida[i].mPosition = new Vector2(posicaoX, posicaoY);
                posicaoX += 6;
            }
            mBall = new SoccerBall(mSoccerPosition, mSoccerBallRadius * 2f);
            mEsfera = new Esfera(mEsferaPosition, mEsferaSize);
            mBastao = new Bastao(mBastaoPosition, mBastaoSize);
            //mBloco = new BlocoAzul(mBlocoPosition, mBlocoSize);
            //carrega Nivel 1
            mBlocoAzulNivel1 = new BlocoAzul[40];
            posicaoX = 15;
            posicaoY = 85;
            j = 0;
            for (int i = 0; i < 40; i++)
            {
                mBlocoAzulNivel1[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoAzulNivel1[i].mPosition = new Vector2(posicaoX, posicaoY);
                posicaoX += 10;
                j++;
                if (j == 10)
                {
                    posicaoX = 15;
                    posicaoY -= 5;
                    j = 0;
                }
            }
            //carrega Nivel 2
            mBlocoAmareloNivel2 = new BlocoAmarelo[10];
            mBlocoAmareloQuebradoNivel2 = new BlocoAzul[10];
            timerBlocoAmareloNivel2 = new int[10];
            timerBlocoAmareloNivel2existing = new bool[10];
            posicaoX = 15;
            posicaoY = 85;
            j = 0;
            for (int i = 0; i < 10; i++)
            {
                mBlocoAmareloNivel2[i] = new BlocoAmarelo(mBlocoPosition, mBlocoSize);
                mBlocoAmareloNivel2[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoAmareloQuebradoNivel2[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoAmareloQuebradoNivel2[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoAmareloQuebradoNivel2[i].existe = false;
                timerBlocoAmareloNivel2[i] = 0;
                timerBlocoAmareloNivel2existing[i] = false;
                posicaoX += 10;
                j++;
            }
            mBlocoAzulNivel2 = new BlocoAzul[20];
            posicaoX = 15;
            posicaoY = 70;
            j = 0;
            for (int i = 0; i < 20; i++)
            {
                mBlocoAzulNivel2[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoAzulNivel2[i].mPosition = new Vector2(posicaoX, posicaoY);
                posicaoX += 10;
                j++;
                if (j == 10)
                {
                    posicaoX = 15;
                    posicaoY -= 15;
                    j = 0;
                }
            }
            //carrega Nivel 3
            mBlocoAmareloNivel3 = new BlocoAmarelo[20];
            mBlocoAmareloQuebradoNivel3 = new BlocoAzul[20];
            timerBlocoAmareloNivel3 = new int[20];
            timerBlocoAmareloNivel3existing = new bool[20];
            mBlocoAzulNivel3 = new BlocoAzul[20];
            posicaoX = 15;
            posicaoY = 85;
            j = 0;
            for (int i = 0; i < 20; i++)
            {
                mBlocoAmareloNivel3[i] = new BlocoAmarelo(mBlocoPosition, mBlocoSize);
                mBlocoAmareloNivel3[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoAmareloQuebradoNivel3[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoAmareloQuebradoNivel3[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoAmareloQuebradoNivel3[i].existe = false;
                timerBlocoAmareloNivel3[i] = 0;
                timerBlocoAmareloNivel3existing[i] = false;
                posicaoX += 10;
                j++;
                if (j == 10)
                {
                    posicaoX = 15;
                    posicaoY -= 30;
                    j = 0;
                }
            }
            posicaoX = 15;
            posicaoY = 70;
            j = 0;
            for (int i = 0; i < 20; i++)
            {
                mBlocoAzulNivel3[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoAzulNivel3[i].mPosition = new Vector2(posicaoX, posicaoY);
                posicaoX += 10;
                j++;
                if (j == 10)
                {
                    posicaoX = 15;
                    posicaoY -= 5;
                    j = 0;
                }
            }
            //carrega nivel 4
            mBlocoAzulNivel4 = new BlocoAzul[18];
            mBlocoAmareloNivel4 = new BlocoAmarelo[10];
            mBlocoAmareloQuebradoNivel4 = new BlocoAzul[10];
            timerBlocoAmareloNivel4 = new int[10];
            timerBlocoAmareloNivel4existing = new bool[10];
            mBlocoMarromNivel4 = new BlocoMarrom[4];
            mBlocoMarromQuebradoNivel4 = new BlocoAmarelo[4];
            timerBlocoMarromNivel4 = new int[4];
            timerBlocoMarromNivel4existing = new bool[4];
            mBlocoMarromQuebrado2Nivel4 = new BlocoAzul[4];
            timerBlocoMarrom2Nivel4 = new int[4];
            timerBlocoMarrom2Nivel4existing = new bool[4];
            posicaoX = 15;
            posicaoY = 55;
            j = 0;
            for (int i = 0; i < 18; i++)
            {
                mBlocoAzulNivel4[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoAzulNivel4[i].mPosition = new Vector2(posicaoX, posicaoY);
                if (i == 13)
                {
                    posicaoX += 20;
                }
                posicaoX += 10;
                j++;
                if (j == 10)
                {
                    posicaoX = 15;
                    posicaoY += 5;
                    j = 0;
                }
            }
            posicaoX = 15;
            posicaoY = 65;
            j = 0;
            for (int i = 0; i < 10; i++)
            {
                mBlocoAmareloNivel4[i] = new BlocoAmarelo(mBlocoPosition, mBlocoSize);
                mBlocoAmareloNivel4[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoAmareloQuebradoNivel4[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoAmareloQuebradoNivel4[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoAmareloQuebradoNivel4[i].existe = false;
                timerBlocoAmareloNivel4[i] = 0;
                timerBlocoAmareloNivel4existing[i] = false;
                if (i == 2)
                {
                    posicaoX += 40;
                }
                if (i == 7)
                {
                    posicaoX += 60;
                }
                posicaoX += 10;
                j++;
                if (j == 6)
                {
                    posicaoX = 15;
                    posicaoY += 5;
                    j = 0;
                }
            }
            posicaoX = 15;
            posicaoY = 75;
            j = 0;
            for (int i = 0; i < 4; i++)
            {
                mBlocoMarromNivel4[i] = new BlocoMarrom(mBlocoPosition, mBlocoSize);
                mBlocoMarromNivel4[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoMarromQuebradoNivel4[i] = new BlocoAmarelo(mBlocoPosition, mBlocoSize);
                mBlocoMarromQuebradoNivel4[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoMarromQuebradoNivel4[i].existe = false;
                timerBlocoMarromNivel4[i] = 0;
                timerBlocoMarromNivel4existing[i] = false;
                mBlocoMarromQuebrado2Nivel4[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoMarromQuebrado2Nivel4[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoMarromQuebrado2Nivel4[i].existe = false;
                timerBlocoMarrom2Nivel4[i] = 0;
                timerBlocoMarrom2Nivel4existing[i] = false;
                if (i == 0 || i == 2)
                {
                    posicaoX = 105;
                }
                j++;
                if (j == 2)
                {
                    posicaoX = 15;
                    posicaoY += 5;
                }
            }
            //carrega nivel 5
            mBlocoAzulNivel5 = new BlocoAzul[10];
            mBlocoAmareloNivel5 = new BlocoAmarelo[10];
            mBlocoAmareloQuebradoNivel5 = new BlocoAzul[10];
            timerBlocoAmareloNivel5 = new int[10];
            timerBlocoAmareloNivel5existing = new bool[10];
            mBlocoMarromNivel5 = new BlocoMarrom[28];
            mBlocoMarromQuebradoNivel5 = new BlocoAmarelo[28];
            timerBlocoMarromNivel5 = new int[28];
            timerBlocoMarromNivel5existing = new bool[28];
            mBlocoMarromQuebrado2Nivel5 = new BlocoAzul[28];
            timerBlocoMarrom2Nivel5 = new int[28];
            timerBlocoMarrom2Nivel5existing = new bool[28];
            mBlocoVermelhoNivel5 = new BlocoVermelho[4];
            mBlocoVermelhoQuebradoNivel5 = new BlocoMarrom[4];
            timerBlocoVermelhoNivel5 = new int[4];
            timerBlocoVermelhoNivel5existing = new bool[4];
            mBlocoVermelhoQuebrado2Nivel5 = new BlocoAmarelo[4];
            timerBlocoVermelho2Nivel5 = new int[4];
            timerBlocoVermelho2Nivel5existing = new bool[4];
            mBlocoVermelhoQuebrado3Nivel5 = new BlocoAzul[4];
            timerBlocoVermelho3Nivel5 = new int[4];
            timerBlocoVermelho3Nivel5existing = new bool[4];
            posicaoX = 15;
            posicaoY = 55;
            j = 0;
            for (int i = 0; i < 10; i++)
            {
                mBlocoAzulNivel5[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoAzulNivel5[i].mPosition = new Vector2(posicaoX, posicaoY);
                posicaoX += 10;
            }
            posicaoX = 15;
            posicaoY = 60;
            for (int i = 0; i < 10; i++)
            {
                mBlocoAmareloNivel5[i] = new BlocoAmarelo(mBlocoPosition, mBlocoSize);
                mBlocoAmareloNivel5[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoAmareloQuebradoNivel5[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoAmareloQuebradoNivel5[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoAmareloQuebradoNivel5[i].existe = false;
                timerBlocoAmareloNivel5[i] = 0;
                timerBlocoAmareloNivel5existing[i] = false;
                posicaoX += 10;
            }
            posicaoX = 15;
            posicaoY = 65;
            for (int i = 0; i < 28; i++)
            {
                mBlocoMarromNivel5[i] = new BlocoMarrom(mBlocoPosition, mBlocoSize);
                mBlocoMarromNivel5[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoMarromQuebradoNivel5[i] = new BlocoAmarelo(mBlocoPosition, mBlocoSize);
                mBlocoMarromQuebradoNivel5[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoMarromQuebradoNivel5[i].existe = false;
                timerBlocoMarromNivel5[i] = 0;
                timerBlocoMarromNivel5existing[i] = false;
                mBlocoMarromQuebrado2Nivel5[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoMarromQuebrado2Nivel5[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoMarromQuebrado2Nivel5[i].existe = false;
                timerBlocoMarrom2Nivel5[i] = 0;
                timerBlocoMarrom2Nivel5existing[i] = false;
                if (i == 0 || i == 4 || i == 8 || i == 2 || i == 6 || i == 14)
                {
                    posicaoX += 20;
                } else if (i == 3 || i == 7 || i == 15 || i == 17)
                {
                    posicaoX = 15;
                    posicaoY += 5;
                } else if (i == 1 || i == 5)
                {
                    posicaoX += 50;
                } else if(i == 16)
                {
                    posicaoX += 90;
                } else
                {
                    posicaoX += 10;
                }
            }
            posicaoX = 45;
            posicaoY = 80;
            for (int i = 0; i < 4; i++)
            {
                mBlocoVermelhoNivel5[i] = new BlocoVermelho(mBlocoPosition, mBlocoSize);
                mBlocoVermelhoNivel5[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoVermelhoQuebradoNivel5[i] = new BlocoMarrom(mBlocoPosition, mBlocoSize);
                mBlocoVermelhoQuebradoNivel5[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoVermelhoQuebradoNivel5[i].existe = false;
                timerBlocoVermelhoNivel5[i] = 0;
                timerBlocoVermelhoNivel5existing[i] = false;
                mBlocoVermelhoQuebrado2Nivel5[i] = new BlocoAmarelo(mBlocoPosition, mBlocoSize);
                mBlocoVermelhoQuebrado2Nivel5[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoVermelhoQuebrado2Nivel5[i].existe = false;
                timerBlocoVermelho2Nivel5[i] = 0;
                timerBlocoVermelho2Nivel5existing[i] = false;
                mBlocoVermelhoQuebrado3Nivel5[i] = new BlocoAzul(mBlocoPosition, mBlocoSize);
                mBlocoVermelhoQuebrado3Nivel5[i].mPosition = new Vector2(posicaoX, posicaoY);
                mBlocoVermelhoQuebrado3Nivel5[i].existe = false;
                timerBlocoVermelho3Nivel5[i] = 0;
                timerBlocoVermelho3Nivel5existing[i] = false;
                posicaoX += 10;
            }
            //fim dos niveis
            // Load the images.
            //mJPGImage = Content.Load<Texture2D>("UWB-JPG");
            //mPNGImage = Content.Load<Texture2D>("UWB-PNG");
            background = Content.Load<Texture2D>("Salty present 2015");
            levels = new Texture2D[6];
            levels[0] = Content.Load<Texture2D>("IPCA Nivel 1");
            levels[1] = Content.Load<Texture2D>("IPCA Nivel 2");
            levels[2] = Content.Load<Texture2D>("IPCA Nivel 3");
            levels[3] = Content.Load<Texture2D>("IPCA Nivel 4");
            levels[4] = Content.Load<Texture2D>("IPCA Nivel 5");
            levels[5] = Content.Load<Texture2D>("IPCA");
            //lifeLost = Content.Load<SoundEffect>("Life Lost");
            //stageClear = Content.Load<SoundEffect>("Stage Clear");
            mTheGame = new MyGame();
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
            /*#region Game Controller
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            // TODO: Add your update logic here
            // Update the image positions with left/right thumbsticks
            mJPGPosition += GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            mPNGPosition += GamePad.GetState(PlayerIndex.One).ThumbSticks.Right;
            #endregion
            #region Keyboard
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            // Update the image positions with Arrow keys
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                mJPGPosition.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                mJPGPosition.X++;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                mJPGPosition.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                mJPGPosition.Y++;
            // Update the image positions with AWSD
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                mPNGPosition.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                mPNGPosition.X++;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                mPNGPosition.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                mPNGPosition.Y++;
            #endregion
            #region Mouse
            // Poll mouse state
            MouseState mMouseState = Mouse.GetState();
            // If left mouse button is pressed
            if (mMouseState.LeftButton == ButtonState.Pressed)
                mJPGPosition = new Vector2(mMouseState.X, mMouseState.Y);
            // If right mouse button is pressed
            if (mMouseState.RightButton == ButtonState.Pressed)
                mPNGPosition = new Vector2(mMouseState.X, mMouseState.Y);
            #endregion*/
            // Allows the game to exit
            //if (InputWrapper.Buttons.Back == ButtonState.Pressed)
                //this.Exit();
            // "A" to toggle to full-screen mode
            /*if (InputWrapper.Buttons.A == ButtonState.Pressed)
            {
                if (!sGraphics.IsFullScreen)
                {
                    sGraphics.IsFullScreen = true;
                    sGraphics.ApplyChanges();
                }
            }*/
            // "B" toggles back to windowed mode
            /*if (InputWrapper.Buttons.B == ButtonState.Pressed)
            {
                if (sGraphics.IsFullScreen)
            {
                    sGraphics.IsFullScreen = false;
                    sGraphics.ApplyChanges();
                }
            }*/
            // Button X to select the next object to work with
            /*if (InputWrapper.Buttons.X == ButtonState.Pressed)
                mCurrentIndex = (mCurrentIndex + 1) % kNumObjects;*/
            // Update currently working object with thumb sticks.
            mGraphicsObjects[mCurrentIndex].Update(
            InputWrapper.ThumbSticks.Left,
            InputWrapper.ThumbSticks.Right);
            // Update the image positions with left/right thumbsticks
            //mJPGPosition += InputWrapper.ThumbSticks.Left;
            //mPNGPosition += InputWrapper.ThumbSticks.Right;
            //Actions for the SoccerBall
            //mUWBLogo.Update(InputWrapper.ThumbSticks.Left, Vector2.Zero);
            //mBall.Update();
            //mBall.Update(Vector2.Zero, InputWrapper.ThumbSticks.Right);
            //if (InputWrapper.Buttons.A == ButtonState.Pressed)
            //    mBall = new SoccerBall(mSoccerPosition, mSoccerBallRadius * 2f);
            /*mTheGame.UpdateGame(gameTime);
            if (InputWrapper.Buttons.A == ButtonState.Pressed)
                mTheGame = new MyGame();*/
            if (InputWrapper.Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }
            //mBloco.Update();
            if (nivelAtual > 3)
            {
                mBastao.Update();
                mEsfera.Update();
                if (vida == -1)
                {
                    nivelAtual = 3;
                }
                if (blocosNaTela == 0 && nivelAtual == 8)
                {
                    nivelAtual = 2;
                    score += (vida * 1000);
                }
                else
                {
                    if (blocosNaTela == 0)
                    {
                        nivelAtual++;
                        if (vida + 2 > 10)
                        {
                            vida = 10;
                        }
                        else
                        {
                            vida += 2;
                        }
                        switch (nivelAtual)
                        {
                            case 4:
                                blocosNaTela = 40;
                                break;
                            case 5:
                                blocosNaTela = 30;
                                break;
                            case 6:
                                blocosNaTela = 40;
                                break;
                            case 7:
                                blocosNaTela = 32;
                                break;
                            case 8:
                                blocosNaTela = 52;
                                break;
                        }
                        mEsfera.mPosition = mEsferaPosition;
                        mEsfera.mDeltaPosition = new Vector2(0.8f, 0.8f);
                        mBastao.mPosition = mBastaoPosition;
                    }
                }
            }
            switch (nivelAtual)
            {
                case 1:
                    if (InputWrapper.Buttons.Start == ButtonState.Pressed)
                    {
                        nivelAtual = 4;
                        blocosNaTela = 40;
                    }
                    break;
                case 2:
                    /*if (InputWrapper.Buttons.Start == ButtonState.Pressed)
                    {
                        vida = 5;
                        score = 0;
                        nivelAtual = 1;
                    }*/
                    break;
                case 3:
                    /*if (InputWrapper.Buttons.Start == ButtonState.Pressed)
                    {
                        vida = 5;
                        score = 0;
                        nivelAtual = 1;
                    }*/
                    break;
                case 4:
                    for (int i = 0; i < 40; i++)
                    {
                        mBlocoAzulNivel1[i].Update();
                        mBlocoAzulNivel1[i].CheckCollision(mEsfera);
                    }
                    mEsfera.colisaoBastao(mBastao.GetBounds());
                    break;
                case 5:
                    for (int i = 0; i < 10; i++)
                    {
                        mBlocoAmareloNivel2[i].Update();
                        mBlocoAmareloQuebradoNivel2[i].Update();
                        if(mBlocoAmareloNivel2[i].existe)
                        {
                            timerBlocoAmareloNivel2existing[i] = mBlocoAmareloNivel2[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoAmareloNivel2existing[i] && timerBlocoAmareloNivel2[i] <= 4)
                        {
                            timerBlocoAmareloNivel2[i]++;
                        }
                        if(timerBlocoAmareloNivel2[i] == 3)
                        {
                            mBlocoAmareloQuebradoNivel2[i].existe = true;
                        }
                        if (mBlocoAmareloQuebradoNivel2[i].existe)
                        {
                            mBlocoAmareloQuebradoNivel2[i].CheckCollision(mEsfera);
                        }
                    }
                    for (int i = 0; i < 20; i++)
                    {
                        mBlocoAzulNivel2[i].Update();
                        mBlocoAzulNivel2[i].CheckCollision(mEsfera);
                    }
                    mEsfera.colisaoBastao(mBastao.GetBounds());
                    break;
                case 6:
                    for (int i = 0; i < 20; i++)
                    {
                        mBlocoAmareloNivel3[i].Update();
                        mBlocoAmareloQuebradoNivel3[i].Update();
                        if (mBlocoAmareloNivel3[i].existe)
                        {
                            timerBlocoAmareloNivel3existing[i] = mBlocoAmareloNivel3[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoAmareloNivel3existing[i] && timerBlocoAmareloNivel3[i] <= 4)
                        {
                            timerBlocoAmareloNivel3[i]++;
                        }
                        if (timerBlocoAmareloNivel3[i] == 3)
                        {
                            mBlocoAmareloQuebradoNivel3[i].existe = true;
                        }
                        if (mBlocoAmareloQuebradoNivel3[i].existe)
                        {
                            mBlocoAmareloQuebradoNivel3[i].CheckCollision(mEsfera);
                        }
                        mBlocoAzulNivel3[i].Update();
                        mBlocoAzulNivel3[i].CheckCollision(mEsfera);
                    }
                    mEsfera.colisaoBastao(mBastao.GetBounds());
                    break;
                case 7:
                    for (int i = 0; i < 4; i++)
                    {
                        mBlocoMarromNivel4[i].Update();
                        mBlocoMarromQuebradoNivel4[i].Update();
                        mBlocoMarromQuebrado2Nivel4[i].Update();
                        if (mBlocoMarromNivel4[i].existe)
                        {
                            timerBlocoMarromNivel4existing[i] = mBlocoMarromNivel4[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoMarromNivel4existing[i] && timerBlocoMarromNivel4[i] <= 4)
                        {
                            timerBlocoMarromNivel4[i]++;
                        }
                        if (timerBlocoMarromNivel4[i] == 3)
                        {
                            mBlocoMarromQuebradoNivel4[i].existe = true;
                        }
                        if (mBlocoMarromQuebradoNivel4[i].existe)
                        {
                            timerBlocoMarrom2Nivel4existing[i] = mBlocoMarromQuebradoNivel4[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoMarrom2Nivel4existing[i] && timerBlocoMarrom2Nivel4[i] <= 4)
                        {
                            timerBlocoMarrom2Nivel4[i]++;
                        }
                        if (timerBlocoMarrom2Nivel4[i] == 3)
                        {
                            mBlocoMarromQuebrado2Nivel4[i].existe = true;
                        }
                        if (mBlocoMarromQuebrado2Nivel4[i].existe)
                        {
                            mBlocoMarromQuebrado2Nivel4[i].CheckCollision(mEsfera);
                        }
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        mBlocoAmareloNivel4[i].Update();
                        mBlocoAmareloQuebradoNivel4[i].Update();
                        if (mBlocoAmareloNivel4[i].existe)
                        {
                            timerBlocoAmareloNivel4existing[i] = mBlocoAmareloNivel4[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoAmareloNivel4existing[i] && timerBlocoAmareloNivel4[i] <= 4)
                        {
                            timerBlocoAmareloNivel4[i]++;
                        }
                        if (timerBlocoAmareloNivel4[i] == 3)
                        {
                            mBlocoAmareloQuebradoNivel4[i].existe = true;
                        }
                        if (mBlocoAmareloQuebradoNivel4[i].existe)
                        {
                            mBlocoAmareloQuebradoNivel4[i].CheckCollision(mEsfera);
                        }
                    }
                    for (int i = 0; i < 18; i++)
                    {
                        mBlocoAzulNivel4[i].Update();
                        mBlocoAzulNivel4[i].CheckCollision(mEsfera);
                    }
                    mEsfera.colisaoBastao(mBastao.GetBounds());
                    break;
                case 8:
                    for (int i = 0; i < 4; i++)
                    {
                        mBlocoVermelhoNivel5[i].Update();
                        mBlocoVermelhoQuebradoNivel5[i].Update();
                        mBlocoVermelhoQuebrado2Nivel5[i].Update();
                        if (mBlocoVermelhoNivel5[i].existe)
                        {
                            timerBlocoVermelhoNivel5existing[i] = mBlocoVermelhoNivel5[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoVermelhoNivel5existing[i] && timerBlocoVermelhoNivel5[i] <= 4)
                        {
                            timerBlocoVermelhoNivel5[i]++;
                        }
                        if (timerBlocoVermelhoNivel5[i] == 3)
                        {
                            mBlocoVermelhoQuebradoNivel5[i].existe = true;
                        }
                        if (mBlocoVermelhoQuebradoNivel5[i].existe)
                        {
                            timerBlocoVermelho2Nivel5existing[i] = mBlocoVermelhoQuebradoNivel5[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoVermelho2Nivel5existing[i] && timerBlocoVermelho2Nivel5[i] <= 4)
                        {
                            timerBlocoVermelho2Nivel5[i]++;
                        }
                        if (timerBlocoVermelho2Nivel5[i] == 3)
                        {
                            mBlocoVermelhoQuebrado2Nivel5[i].existe = true;
                        }
                        if (mBlocoVermelhoQuebrado2Nivel5[i].existe)
                        {
                            timerBlocoVermelho3Nivel5existing[i] = mBlocoVermelhoQuebrado2Nivel5[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoVermelho3Nivel5existing[i] && timerBlocoVermelho3Nivel5[i] <= 4)
                        {
                            timerBlocoVermelho3Nivel5[i]++;
                        }
                        if (timerBlocoVermelho3Nivel5[i] == 3)
                        {
                            mBlocoVermelhoQuebrado3Nivel5[i].existe = true;
                        }
                        if (mBlocoVermelhoQuebrado3Nivel5[i].existe)
                        {
                            mBlocoVermelhoQuebrado3Nivel5[i].CheckCollision(mEsfera);
                        }
                    }
                    for (int i = 0; i < 28; i++)
                    {
                        mBlocoMarromNivel5[i].Update();
                        mBlocoMarromQuebradoNivel5[i].Update();
                        mBlocoMarromQuebrado2Nivel5[i].Update();
                        if (mBlocoMarromNivel5[i].existe)
                        {
                            timerBlocoMarromNivel5existing[i] = mBlocoMarromNivel5[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoMarromNivel5existing[i] && timerBlocoMarromNivel5[i] <= 4)
                        {
                            timerBlocoMarromNivel5[i]++;
                        }
                        if (timerBlocoMarromNivel5[i] == 3)
                        {
                            mBlocoMarromQuebradoNivel5[i].existe = true;
                        }
                        if (mBlocoMarromQuebradoNivel5[i].existe)
                        {
                            timerBlocoMarrom2Nivel5existing[i] = mBlocoMarromQuebradoNivel5[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoMarrom2Nivel5existing[i] && timerBlocoMarrom2Nivel5[i] <= 4)
                        {
                            timerBlocoMarrom2Nivel5[i]++;
                        }
                        if (timerBlocoMarrom2Nivel5[i] == 3)
                        {
                            mBlocoMarromQuebrado2Nivel5[i].existe = true;
                        }
                        if (mBlocoMarromQuebrado2Nivel5[i].existe)
                        {
                            mBlocoMarromQuebrado2Nivel5[i].CheckCollision(mEsfera);
                        }
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        mBlocoAmareloNivel5[i].Update();
                        mBlocoAmareloQuebradoNivel5[i].Update();
                        if (mBlocoAmareloNivel5[i].existe)
                        {
                            timerBlocoAmareloNivel5existing[i] = mBlocoAmareloNivel5[i].CheckCollision(mEsfera);
                        }
                        if (timerBlocoAmareloNivel5existing[i] && timerBlocoAmareloNivel5[i] <= 4)
                        {
                            timerBlocoAmareloNivel5[i]++;
                        }
                        if (timerBlocoAmareloNivel5[i] == 3)
                        {
                            mBlocoAmareloQuebradoNivel5[i].existe = true;
                        }
                        if (mBlocoAmareloQuebradoNivel5[i].existe)
                        {
                            mBlocoAmareloQuebradoNivel5[i].CheckCollision(mEsfera);
                        }
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        mBlocoAzulNivel5[i].Update();
                        mBlocoAzulNivel5[i].CheckCollision(mEsfera);
                    }
                    mEsfera.colisaoBastao(mBastao.GetBounds());
                    break;
            }
            //mBloco.CheckCollision(mEsfera);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Clear to background color
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Game1.sSpriteBatch.Begin(); // Initialize drawing support
                                        //mSpriteBatch.Begin(); // Initialize drawing support
                                        // Loop over and draw each primitive
                                        /*foreach (TexturedPrimitive p in mGraphicsObjects)
                                        {
                                            p.Draw();
                                        }*/

            // Print out text message to echo status
            /*FontSupport.PrintStatus("Selected object is:" + mCurrentIndex +
            " Location=" + mGraphicsObjects[mCurrentIndex].GetMPosition(), null);
            FontSupport.PrintStatusAt(mGraphicsObjects[mCurrentIndex].GetMPosition(), "Selected",
           Color.Red);
            mUWBLogo.Draw();
            mBall.Draw();*/
            // Print out text message to echo status
            /*FontSupport.PrintStatus("Ball Position:" + mBall.GetMPosition(), null);
            FontSupport.PrintStatusAt(mUWBLogo.GetMPosition(),
            mUWBLogo.GetMPosition().ToString(), Color.White);
            FontSupport.PrintStatusAt(mBall.GetMPosition(), "Radius" + mBall.Radius, Color.Red);*/
            //mTheGame.DrawGame();

            switch (nivelAtual)
            {
                case 1:
                    Game1.sSpriteBatch.Draw(levels[5], new Rectangle(0, 0, 800, 800), Color.LightBlue);
                    FontSupport.PrintStatusAt(new Vector2(10, 95), "Game by Paulo Sergio Nunes Naressi", null);
                    FontSupport.PrintStatusAt(new Vector2(15, 80), "Use the Left and Right buttons to move the stick.", null);
                    FontSupport.PrintStatusAt(new Vector2(15, 75), "Break all the blocks in a level to advance!", null);
                    FontSupport.PrintStatusAt(new Vector2(45, 65), "BLOCK BREAKER IPCA", null);
                    FontSupport.PrintStatusAt(new Vector2(45, 25), "PRESS ENTER TO BEGIN", null);
                    break;
                case 2:
                    Game1.sSpriteBatch.Draw(levels[5], new Rectangle(0, 0, 800, 800), Color.Yellow);
                    FontSupport.PrintStatusAt(new Vector2(15, 80), "CONGRATULATIONS!!!", null);
                    FontSupport.PrintStatusAt(new Vector2(15, 75), "Final Score: " + score, null);
                    //FontSupport.PrintStatusAt(new Vector2(15, 70), "Press Enter to return to the Title Screen.", null);
                    break;
                case 3:
                    Game1.sSpriteBatch.Draw(levels[5], new Rectangle(0, 0, 800, 800), Color.Gray);
                    FontSupport.PrintStatusAt(new Vector2(15, 80), "GAME OVER...", null);
                    FontSupport.PrintStatusAt(new Vector2(15, 75), "Final Score: " + score, null);
                    //FontSupport.PrintStatusAt(new Vector2(15, 70), "Press Enter to return to the Title Screen.", null);
                    break;
                case 4:
                    Game1.sSpriteBatch.Draw(levels[0], new Rectangle(0, 0, 800, 800), Color.White);
                    mBastao.Draw();
                    mEsfera.Draw();
                    //mBloco.Draw2();
                    for (int i = 0; i < 40; i++)
                    {
                        mBlocoAzulNivel1[i].Draw2();
                    }
                    break;
                case 5:
                    Game1.sSpriteBatch.Draw(levels[1], new Rectangle(0, 0, 800, 800), Color.White);
                    mBastao.Draw();
                    mEsfera.Draw();
                    for (int i = 0; i < 10; i++)
                    {
                        mBlocoAmareloNivel2[i].Draw2();
                        mBlocoAmareloQuebradoNivel2[i].Draw2();
                    }
                    for (int i = 0; i < 20; i++)
                    {
                        mBlocoAzulNivel2[i].Draw2();
                    }
                    break;
                case 6:
                    Game1.sSpriteBatch.Draw(levels[2], new Rectangle(0, 0, 800, 800), Color.White);
                    mBastao.Draw();
                    mEsfera.Draw();
                    for (int i = 0; i < 20; i++)
                    {
                        mBlocoAmareloNivel3[i].Draw2();
                        mBlocoAmareloQuebradoNivel3[i].Draw2();
                        mBlocoAzulNivel3[i].Draw2();
                    }
                    break;
                case 7:
                    Game1.sSpriteBatch.Draw(levels[3], new Rectangle(0, 0, 800, 800), Color.White);
                    mBastao.Draw();
                    mEsfera.Draw();
                    for (int i = 0; i < 4; i++)
                    {
                        mBlocoMarromNivel4[i].Draw2();
                        mBlocoMarromQuebradoNivel4[i].Draw2();
                        mBlocoMarromQuebrado2Nivel4[i].Draw2();
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        mBlocoAmareloNivel4[i].Draw2();
                        mBlocoAmareloQuebradoNivel4[i].Draw2();
                    }
                    for (int i = 0; i < 18; i++)
                    {
                        mBlocoAzulNivel4[i].Draw2();
                    }
                    break;
                case 8:
                    Game1.sSpriteBatch.Draw(levels[4], new Rectangle(0, 0, 800, 800), Color.White);
                    for (int i = 0; i < 4; i++)
                    {
                        mBlocoVermelhoNivel5[i].Draw2();
                        mBlocoVermelhoQuebradoNivel5[i].Draw2();
                        mBlocoVermelhoQuebrado2Nivel5[i].Draw2();
                        mBlocoVermelhoQuebrado3Nivel5[i].Draw2();
                    }
                    for (int i = 0; i < 28; i++)
                    {
                        mBlocoMarromNivel5[i].Draw2();
                        mBlocoMarromQuebradoNivel5[i].Draw2();
                        mBlocoMarromQuebrado2Nivel5[i].Draw2();
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        mBlocoAmareloNivel5[i].Draw2();
                        mBlocoAmareloQuebradoNivel5[i].Draw2();
                    }
                    for (int i = 0; i < 10; i++)
                    {
                        mBlocoAzulNivel5[i].Draw2();
                    }
                    mBastao.Draw();
                    mEsfera.Draw();
                    break;
            }
            if (nivelAtual > 3)
            {
                for (int i = 0; i < vida; i++)
                {
                    placarVida[i].Draw();
                }
                FontSupport.PrintStatusAt(new Vector2(93, 95), "Score: " + score, null);
                if(nivelAtual == 8)
                {
                    FontSupport.PrintStatusAt(new Vector2(93, 93), "Stage: FINAL", null);
                }
                else
                {
                    FontSupport.PrintStatusAt(new Vector2(93, 93), "Stage: " + (nivelAtual - 3), null);
                }
            }
            Game1.sSpriteBatch.End(); // Inform graphics system we are done drawing
                                      // Draw the JPGImage
                                      //mSpriteBatch.Draw(mJPGImage, mJPGPosition, Color.White);
                                      // Draw the PNGImage
                                      //mSpriteBatch.Draw(mPNGImage, mPNGPosition, Color.White);
                                      //mSpriteBatch.End(); // Inform graphics system we are done drawing
                                      // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
