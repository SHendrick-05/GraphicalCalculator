using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace GraphicalCalculator
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D rectangle;

        private double minY;
        private double maxY;

        private double minX;
        private double maxX;

        private double rangeX;
        private double rangeY;

        private double majorDivision;
        private double minorDivision;

        private int _width;
        private int _height;

        private int buffer;

        private List<Vector2> points;
        private List<Vector2> pointsToDraw;

        private List<string> function;


        public Game1(string functionText)
        {
            Queue q = FunctionParser.ShuntingYard(functionText);
            function = new List<string>();

            while (q.Count > 0)
            {
                function.Add(q.Dequeue().ToString());
            }

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            buffer = 50;

            _width = _graphics.PreferredBackBufferWidth - (2 * buffer);
            _height = _graphics.PreferredBackBufferHeight - (2 * buffer);

            minX = -5;
            minY = -5;

            maxX = 5;
            maxY = 5;

            rangeY = maxY - minY;
            rangeX = maxX - minX;



            points = new List<Vector2>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            double Xperpixel = rangeX / _width;
            int pixels = 0;

            for(int xPixel = 0; xPixel < _width; xPixel++)
            {
                double x = minX + Xperpixel * xPixel;
                double y = FunctionParser.EvaluateFunction(function, x);
                points.Add(new Vector2(buffer + pixels++, (float)convertPoint(y)));
            }

            pointsToDraw = points.Where(pt => pt.Y > buffer && pt.Y < (_height + buffer)).ToList();

            rectangle = new Texture2D(GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            

            // Draw graph
            for(int i = 1; i < pointsToDraw.Count; i++)
            {
                Vector2 start = pointsToDraw[i - 1];
                Vector2 end = pointsToDraw[i];
                if (end.X - start.X == 1)
                    DrawLine(start, end);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        internal void DrawLine(Vector2 start, Vector2 end)
        {
            _spriteBatch.Draw(
                rectangle,
                start,
                null,
                Color.White,
                (float)Math.Atan2(end.Y - start.Y, end.X - start.X), // Get the gradient of the line.
                new Vector2(0f, (float)rectangle.Height / 2),        // Rotate around the centre of the line.
                new Vector2(Vector2.Distance(start, end), 1f),       // Scale the line to the distance between the two points.
                SpriteEffects.None,
                0f);
        }

        internal double convertPoint(double y)
        {
            double proportion = (y - minY) / rangeY;

            return _height + buffer - proportion * _height;
        }
    }
}