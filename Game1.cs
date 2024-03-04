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

        private bool useMajorDivions;
        private bool useMinorDivions;

        private int _width;
        private int _height;

        private int buffer;

        private List<Vector2> points;
        private List<Vector2> pointsToDraw;

        private List<string> function;

        private SpriteFont font;


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

            useMajorDivions = true;
            useMinorDivions = false;

            majorDivision = 1;
            minorDivision = 0.5;

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
                points.Add(new Vector2(buffer + pixels++, (float)convertPointY(y)));
            }

            pointsToDraw = points.Where(pt => pt.Y > buffer && pt.Y < (_height + buffer)).ToList();

            rectangle = new Texture2D(GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.White });

            font = Content.Load<SpriteFont>("font");
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

            // Draw border
            Vector2 TL = new Vector2(buffer, buffer);
            Vector2 TR = new Vector2(buffer + _width, buffer);
            Vector2 BL = new Vector2(buffer, buffer + _height);
            Vector2 BR = new Vector2(buffer + _width, buffer + _height);

            DrawLine(TL, TR, Color.Black);
            DrawLine(TR, BR, Color.Black);
            DrawLine(BR, BL, Color.Black);
            DrawLine(BL, TL, Color.Black);

            // Labels
            _spriteBatch.DrawString(font, minX.ToString(), new Vector2(buffer, buffer + _height + 5), Color.Black);
            _spriteBatch.DrawString(font, maxX.ToString(), new Vector2(_width + buffer, buffer + _height + 5), Color.Black);
            _spriteBatch.DrawString(font, minY.ToString(), new Vector2(buffer - 15, _height + buffer - 15), Color.Black);
            _spriteBatch.DrawString(font, maxY.ToString(), new Vector2(buffer - 15, buffer), Color.Black);

            // X = 0
            if (minX < 0 && maxX > 0)
            {
                float zeroCoord = (float)convertPointX(0);
                Vector2 start = new Vector2(zeroCoord, buffer);
                Vector2 end = new Vector2(zeroCoord, buffer + _height);
                DrawLine(start, end, Color.Black);
            }

            // Y = 0
            if (minY < 0 && maxY > 0)
            {
                float zeroCoord = (float)convertPointY(0);
                Vector2 start = new Vector2(buffer, zeroCoord);
                Vector2 end = new Vector2(buffer + _width, zeroCoord);
                DrawLine(start, end, Color.Black);
            }

            // Major divisions
            if(useMajorDivions)
            {
                // X
                double startXDiv = Math.Floor(minX / majorDivision) * majorDivision;
                for (double i = startXDiv; i < maxX; i += majorDivision)
                {
                    if (i == minX || i == 0) continue;

                    float coord = (float)convertPointX(i);
                    Vector2 startPos = new Vector2(coord, buffer);
                    Vector2 endPos = new Vector2(coord, buffer + _height);
                    DrawLine(startPos, endPos, Color.Gray);
                }

                // Major divisions (Y)
                double startYDiv = Math.Floor(minY / majorDivision) * majorDivision;
                for (double i = startYDiv; i < maxY; i += majorDivision)
                {
                    if (i == minY || i == 0) continue;

                    float coord = (float)convertPointY(i);
                    Vector2 startPos = new Vector2(buffer, coord);
                    Vector2 endPos = new Vector2(buffer + _width, coord);
                    DrawLine(startPos, endPos, Color.Gray);
                }
            }


            // Draw graph
            for (int i = 1; i < pointsToDraw.Count; i++)
            {
                Vector2 start = pointsToDraw[i - 1];
                Vector2 end = pointsToDraw[i];
                if (end.X - start.X == 1)
                    DrawLine(start, end, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        internal void DrawLine(Vector2 start, Vector2 end, Color color)
        {
            _spriteBatch.Draw(
                rectangle,
                start,
                null,
                color,
                (float)Math.Atan2(end.Y - start.Y, end.X - start.X), // Get the gradient of the line.
                new Vector2(0f, (float)rectangle.Height / 2),        // Rotate around the centre of the line.
                new Vector2(Vector2.Distance(start, end), 1f),       // Scale the line to the distance between the two points.
                SpriteEffects.None,
                0f);
        }

        internal double convertPointY(double y)
        {
            double proportion = (y - minY) / rangeY;

            return _height + buffer - proportion * _height;
        }
        internal double convertPointX(double x)
        {
            double proportion = (x - minX) / rangeX;

            return buffer + proportion * _width;
        }
    }
}