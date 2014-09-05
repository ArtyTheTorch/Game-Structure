using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;


namespace GameStructure
{
    class DrawSpriteState : IGameObject
    {
        TextureManager _textureManager;

        public DrawSpriteState(TextureManager textureManager)
        {
            _textureManager = textureManager;
        }

        #region IGameObject Members
        public void Update(double elapsedTime)
        { }
        public void Render()
        {
            Texture texture = _textureManager.Get("face_alpha");
            //Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            //Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture.Id);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            //Variables used for the dimensions of the sprite
            double height = 200;
            double width = 200;
            double halfHeight = height / 2;
            double halfWidth = width / 2;

            //Variables used for the position of the sprite
            double x = 0;
            double y = 0;
            double z = 0;

            //Texture coordinates
            float topUV = 0;
            float bottomUV = 1;
            float leftUV = 0;
            float rightUV = 1;

            //Colors for the sprite
            float red = 1;
            float green = 0;
            float blue = 0;
            float alpha = 0.01f;
            
            Gl.glBegin(Gl.GL_TRIANGLES);
            {
                //Color the sprite
                Gl.glColor4f(red,green,blue,alpha);

                //Top Half of Triangle
                Gl.glTexCoord2d(leftUV, topUV);
                Gl.glVertex3d(x - halfWidth, y + halfHeight, z); //Top Left
                Gl.glTexCoord2d(rightUV, topUV);
                Gl.glVertex3d(x + halfWidth, y + halfHeight, z); //Top Right
                Gl.glTexCoord2d(leftUV, bottomUV);
                Gl.glVertex3d(x - halfWidth, y - halfHeight, z); //Bottom Left

                //Bottom Half of Triangle
                Gl.glTexCoord2d(rightUV, topUV);
                Gl.glVertex3d(x + halfWidth, y + halfHeight, z); // top right
                Gl.glTexCoord2d(rightUV, bottomUV);
                Gl.glVertex3d(x + halfWidth, y - halfHeight, z); // bottom right
                Gl.glTexCoord2d(leftUV, bottomUV);
                Gl.glVertex3d(x - halfWidth, y - halfHeight, z); // bottom left
            }
            Gl.glEnd();
        }
        #endregion
    }
}
