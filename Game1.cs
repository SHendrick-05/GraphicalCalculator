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

        private double centerX;
        private double centerY;

        private double rangeX;
        private double rangeY;

        private double majorDivision;
        private double minorDivision;

        private bool useMajorDivions;
        private bool useMinorDivions;

        private double increaseXPerPixel;

        private bool graphClicked;
        private Vector2 circlePos;
        private Texture2D circleTexture;


        private int _width;
        private int _height;

        private int buffer;

        private List<Vector2> points;
        private List<Vector2> pointsToDraw;


        private SpriteFont font;


        public Game1(string functionText, double xMin, double xMax, double yMin, double yMax)
        {
            // Parse function
            Queue q = FunctionParser.ShuntingYard(functionText);
            List<string> function = new List<string>();

            while (q.Count > 0)
            {
                function.Add(q.Dequeue().ToString());
            }

            Functions.function = function;

            // Change variables
            minX = xMin;
            maxX = xMax;

            minY = yMin;
            maxY = yMax;


            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            buffer = 50;

            _width = _graphics.PreferredBackBufferWidth - (2 * buffer);
            _height = _graphics.PreferredBackBufferHeight - (2 * buffer);

            rangeY = maxY - minY;
            rangeX = maxX - minX;

            centerX = (minX + maxX) / 2d;
            centerY = (minY + maxY) / 2d;

            increaseXPerPixel = rangeX / _width;

            useMajorDivions = true;
            useMinorDivions = true;

            majorDivision = 1;
            minorDivision = 0.5;

            points = new List<Vector2>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            updateFunction();

            rectangle = new Texture2D(GraphicsDevice, 1, 1);
            rectangle.SetData(new[] { Color.White });

            circleTexture = Content.Load<Texture2D>("circle");

            font = Content.Load<SpriteFont>("font");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Input.Update();


            // Positive = zoom in
            int scrollDifference = Input.mouseState.ScrollWheelValue - Input.prevMouseState.ScrollWheelValue;
            int tickDiff = scrollDifference / 120;

            if (tickDiff != 0)
            {

                double multiplier = tickDiff > 0 ? Math.Pow(0.9, tickDiff) : Math.Pow(1.1, -1 * tickDiff);

                int mouseX = Math.Max(Input.mouseState.X, buffer);
                int mouseY = Math.Max(Input.mouseState.Y, buffer);

                mouseX = Math.Min(mouseX, _width + buffer);
                mouseY = Math.Min(mouseY, _height + buffer);

                double mouseXCoord = ConvertCoordToX(mouseX);
                double mouseYCoord = ConvertCoordToY(mouseY);

                ChangeCenter(mouseXCoord, mouseYCoord, multiplier);

                increaseXPerPixel = rangeX / _width;




                if (Math.Min(majorDivision / rangeX, majorDivision / rangeY) < 1d / 20)
                {
                    minorDivision = majorDivision;
                    majorDivision *= 2;
                }

                if (Math.Max(majorDivision / rangeX, majorDivision / rangeY) > 1d / 2)
                {
                    majorDivision = minorDivision;
                    minorDivision /= 2;
                }
                updateFunction();
            }
            

            if (Input.mouseState.LeftButton == ButtonState.Pressed)
            {

                if (graphClicked)
                {
                    int X = Input.mouseState.X;
                    int minIndex = 0;
                    double min = 1000;
                    for (int i = 0; i < points.Count; i++)
                    {
                        double difference = Math.Abs(X - points[i].X);
                        if (difference < min)
                        {
                            min = difference;
                            minIndex = i;
                        }
                    }
                    circlePos = points[minIndex];
                }
                if (Input.prevMouseState.LeftButton == ButtonState.Pressed && !graphClicked)
                {
                    double xNum = ConvertCoordToX(Input.mouseState.X);
                    double prevXNum = ConvertCoordToX(Input.prevMouseState.X);

                    double yNum = ConvertCoordToX(Input.mouseState.Y);
                    double prevYNum = ConvertCoordToX(Input.prevMouseState.Y);

                    double xNumDiff = (xNum - prevXNum) * -1;
                    double yNumDiff = yNum - prevYNum;

                    ChangeCenter(centerX + xNumDiff, centerY + yNumDiff, 1, 1);

                    updateFunction();
                }
                else
                {
                    Vector2 mPos = new Vector2(Input.mouseState.X, Input.mouseState.Y);
                    Vector2 closestPoint = points.MinBy(v => Vector2.Distance(mPos, v));

                    if (Vector2.Distance(mPos, closestPoint) < 10)
                        graphClicked = true;
                }
            }
            else if (Input.prevMouseState.LeftButton == ButtonState.Pressed)
            {
                graphClicked = false;
            }

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
            _spriteBatch.DrawString(font, minX.ToString("G3"), new Vector2(buffer, buffer + _height + 5), Color.Black);
            _spriteBatch.DrawString(font, maxX.ToString("G3"), new Vector2(_width + buffer, buffer + _height + 5), Color.Black);
            _spriteBatch.DrawString(font, minY.ToString("G3"), new Vector2(buffer - 15, _height + buffer - 15), Color.Black);
            _spriteBatch.DrawString(font, maxY.ToString("G3"), new Vector2(buffer - 15, buffer), Color.Black);

            // X = 0
            if (minX < 0 && maxX > 0)
            {
                float zeroCoord = (float)ConvertXToCoord(0);
                Vector2 start = new Vector2(zeroCoord, buffer);
                Vector2 end = new Vector2(zeroCoord, buffer + _height);
                DrawLine(start, end, Color.Black);
            }

            // Y = 0
            if (minY < 0 && maxY > 0)
            {
                float zeroCoord = (float)ConvertYToCoord(0);
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

                    float coord = (float)ConvertXToCoord(i);
                    Vector2 startPos = new Vector2(coord, buffer);
                    Vector2 endPos = new Vector2(coord, buffer + _height);
                    DrawLine(startPos, endPos, Color.Gray);
                }

                
                // Major divisions (Y)
                double startYDiv = Math.Floor(minY / majorDivision) * majorDivision;
                for (double i = startYDiv; i < maxY; i += majorDivision)
                {
                    if (i == minY || i == 0) continue;

                    float coord = (float)ConvertYToCoord(i);
                    Vector2 startPos = new Vector2(buffer, coord);
                    Vector2 endPos = new Vector2(buffer + _width, coord);
                    DrawLine(startPos, endPos, Color.Gray);
                }
            }

            if (useMinorDivions)
            {
                // X
                double startXDiv = Math.Floor(minX / minorDivision) * minorDivision;
                for (double i = startXDiv; i < maxX; i += minorDivision)
                {
                    if (i == minX || i == 0) continue;

                    float coord = (float)ConvertXToCoord(i);
                    Vector2 startPos = new Vector2(coord, buffer);
                    Vector2 endPos = new Vector2(coord, buffer + _height);
                    DrawLine(startPos, endPos, Color.Gray * 0.25f);
                }


                // Y
                double startYDiv = Math.Floor(minY / minorDivision) * minorDivision;
                for (double i = startYDiv; i < maxY; i += minorDivision)
                {
                    if (i == minY || i == 0) continue;

                    float coord = (float)ConvertYToCoord(i);
                    Vector2 startPos = new Vector2(buffer, coord);
                    Vector2 endPos = new Vector2(buffer + _width, coord);
                    DrawLine(startPos, endPos, Color.Gray * 0.25f);
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

            // Draw circle on graph
            if (graphClicked)
            {
                float scale = (10f) / circleTexture.Width;

                _spriteBatch.Draw(
                    circleTexture,
                    circlePos,
                    null,
                    Color.White,
                    0f,
                    new Vector2(circleTexture.Width / 2f, circleTexture.Height / 2f),
                    new Vector2(scale, scale),
                    SpriteEffects.None,
                    1f);
            }

            _spriteBatch.DrawString(font, $"X: {Input.mouseState.X}\nY: {Input.mouseState.Y}", Vector2.Zero, Color.White);

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

        internal double ConvertYToCoord(double y)
        {
            double proportion = (y - minY) / rangeY;

            return _height + buffer - proportion * _height;
        }
        internal double ConvertXToCoord(double x)
        {
            double proportion = (x - minX) / rangeX;

            return buffer + proportion * _width;
        }

        internal double ConvertCoordToX(double coordX)
        {
            double proportion = (coordX - buffer) / _width;

            return minX + proportion * rangeX;
        }

        internal double ConvertCoordToY(double coordY)
        {
            double proportion = (coordY - buffer) / _height;

            return maxY - proportion * rangeY;
        }

        internal List<Vector2> MathPointsToDrawingPoints(Dictionary<double, double> mathPoints)
        {
            List<Vector2> result = new List<Vector2>();
            foreach(double x in mathPoints.Keys)
            {
                double y = mathPoints[x];
                result.Add(new Vector2((float)ConvertXToCoord(x), (float)ConvertYToCoord(y)));
            }
            return result;
        }

        internal void updateFunction()
        {
            var mathPoints = Functions.updatePoints(minX, maxX, increaseXPerPixel);
            points = MathPointsToDrawingPoints(mathPoints);

            bool maxFlag = false;
            bool minFlag = false;

            for(int i = 0; i < points.Count; i++)
            {

                Vector2 replacement = new Vector2(points[i].X, points[i].Y);
                if (replacement.Y < buffer && !maxFlag)
                {
                    maxFlag = true;
                    replacement.Y = buffer + 1;
                }
                else
                {
                    maxFlag = false;
                }

                if (replacement.Y > (buffer + _height) && !minFlag)
                {
                    minFlag = true;
                    replacement.Y = buffer + _height - 1;
                }
                else
                {
                    minFlag = false;
                }
                points[i] = replacement;
            }

            pointsToDraw = points.Where(pt => pt.Y > buffer && pt.Y < (_height + buffer)).ToList();
        }

        internal void ChangeCenter(double zoomCenterX, double zoomCenterY, double multiplier, double easingFactor = 0.1d)
        {
            double centerDifferenceX = zoomCenterX - centerX;
            double centerDifferenceY = zoomCenterY - centerY;

            int zoomMult = multiplier > 1 ? -1 : 1;
            
            centerX += zoomMult * centerDifferenceX * easingFactor;
            centerY += zoomMult * centerDifferenceY * easingFactor;

            maxX = (centerX + (rangeX / 2)) * multiplier;
            minX = (centerX - (rangeX / 2)) * multiplier;

            maxY = (centerY + (rangeY / 2)) * multiplier;
            minY = (centerY - (rangeY / 2)) * multiplier;

            rangeX = maxX - minX;
            rangeY = maxY - minY;
        }
    }
}