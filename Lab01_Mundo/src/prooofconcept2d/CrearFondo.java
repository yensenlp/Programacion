/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package prooofconcept2d;

import java.awt.Canvas;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.net.URL;
import javax.imageio.ImageIO;

/**
 *
 * @author servkey
 */
public class CrearFondo extends Canvas{
    
    private BufferedImage fondo;
    private BufferedImage jugador;
    
    private int y_player=180;
    private int x_player=10;
    
    private BufferedImage cargarImagen(String file){
        BufferedImage img = null;
        try{
            URL image = getClass().getResource(file);
            img = ImageIO.read(image);
        }catch(Exception e){
        }
         return img;
    }
    
    @Override
    public void paint(Graphics graphics)
    {       
         if (fondo == null) {
             fondo = cargarImagen("./images/marioFondo.gif");
         }
         if(jugador==null){
             jugador = cargarImagen("./images/mariopd.png");
         }
         graphics.drawImage(fondo, 0, 0, this);
         graphics.drawImage(jugador, x_player, y_player, this);
         
         System.out.println("x_player"+x_player);
    }   

    @Override
    public void update(Graphics graphics)
    {
        super.update(graphics);
        paint(graphics);
    }

    public int getY_player() {
        return y_player;
    }

    public void setY_player(int y_player) {
        this.y_player = y_player;
    }

    public int getX_player() {
        return x_player;
    }

    public void setX_player(int x_player) {
        this.x_player = x_player;
    }
    
    
}
