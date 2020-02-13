using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace układ_słoneczny
{
    class Cube
    {
        public Color color;
        private float angle = 0f;
        public float size;
        public float speed;
        public BasicEffect basicEffect;
        public VertexPositionColor[] userPrimitives;
        public Vector3 rotationCenter;
        public Vector3 position;
        public GraphicsDevice device;
        public Cube(GraphicsDevice graphicsDevice, Color color, float size, float speed, Vector3 rotationCenter, Vector3 position)
        {
            this.color = color;
            this.size = size;
            this.speed = speed;
            this.rotationCenter = rotationCenter;
            this.position = position;
            this.device = graphicsDevice;
            basicEffect = new BasicEffect(device);

        }
        public VertexPositionColor[] vertexPositionColors()
        {
            userPrimitives = new VertexPositionColor[36]{
                    new VertexPositionColor(new Vector3(-1, -1, 1), color),
                    new VertexPositionColor(new Vector3(-1, 1, 1), color),
                    new VertexPositionColor(new Vector3(1, -1, 1), color),
                    new VertexPositionColor(new Vector3(-1, 1, 1), color),
                    new VertexPositionColor(new Vector3(1, 1, 1), color),
                    new VertexPositionColor(new Vector3(1, -1, 1), color),
                    new VertexPositionColor(new Vector3(1, -1, -1), color),
                    new VertexPositionColor(new Vector3(-1, 1, -1), color),
                    new VertexPositionColor(new Vector3(-1, -1, -1), color),
                    new VertexPositionColor(new Vector3(1, -1, -1), color),
                    new VertexPositionColor(new Vector3(1, 1, -1), color),
                    new VertexPositionColor(new Vector3(-1, 1, -1), color),
                    new VertexPositionColor(new Vector3(-1, 1, -1), color),
                    new VertexPositionColor(new Vector3(-1, 1, 1), color),
                    new VertexPositionColor(new Vector3(-1, -1, -1), color),
                    new VertexPositionColor(new Vector3(-1, 1, 1), color),
                    new VertexPositionColor(new Vector3(-1, -1, 1), color),
                    new VertexPositionColor(new Vector3(-1, -1, -1), color),
                    new VertexPositionColor(new Vector3(1, 1, 1), color),
                    new VertexPositionColor(new Vector3(1, 1, -1), color),
                    new VertexPositionColor(new Vector3(1, -1, -1), color),
                    new VertexPositionColor(new Vector3(1, -1, -1), color),
                    new VertexPositionColor(new Vector3(1, -1, 1), color),
                    new VertexPositionColor(new Vector3(1, 1, 1), color),
                    new VertexPositionColor(new Vector3(-1, 1, -1), color),
                    new VertexPositionColor(new Vector3(1, 1, -1), color),
                    new VertexPositionColor(new Vector3(-1, 1, 1), color),
                    new VertexPositionColor(new Vector3(1, 1, -1), color),
                    new VertexPositionColor(new Vector3(1, 1, 1), color),
                    new VertexPositionColor(new Vector3(-1, 1, 1), color),
                    new VertexPositionColor(new Vector3(-1, -1, 1), color),
                    new VertexPositionColor(new Vector3(1, -1, -1), color),
                    new VertexPositionColor(new Vector3(-1, -1, -1), color),
                    new VertexPositionColor(new Vector3(1, -1, 1), color),
                    new VertexPositionColor(new Vector3(1, -1, -1), color),
                    new VertexPositionColor(new Vector3(-1, -1, 1), color)
        };
            return userPrimitives;

        }
        public void update(GameTime gameTime, Matrix worldMatrix,Matrix viewMatrix, Matrix projectionMatrix)
        {
            angle += speed;
            worldMatrix = Matrix.Identity * Matrix.CreateTranslation(position);
            worldMatrix *= Matrix.CreateScale(size);
            worldMatrix *= Matrix.CreateRotationX(angle);
            worldMatrix *= Matrix.CreateRotationZ(angle);
            worldMatrix *= Matrix.CreateTranslation(rotationCenter);
            basicEffect.World = worldMatrix;
            basicEffect.View = viewMatrix;
            basicEffect.Projection = projectionMatrix;
        }

        internal void Draw()
        {
           basicEffect.CurrentTechnique.Passes[0].Apply();
            device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,vertexPositionColors(),0, 12);
        }

       
    }
}
