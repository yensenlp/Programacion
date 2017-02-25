/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package prooofconcept2d;
import java.awt.Canvas;
import java.awt.Color;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.JFrame;

/**
 *
 * @author servkey
 */
public class FrmGame extends JFrame{
    private Thread thread;
    private CanvasDib canvasDib;
    
    public FrmGame(CanvasDib canvasDib){
       
        this.canvasDib = canvasDib;
        add(canvasDib);
        //Iniciar hilo
        thread = new Thread(){
              public void run(){
                  updating();
              }
        };
        thread.start();
     
        this.getContentPane().setBackground(Color.WHITE);
    }
    
    public void updating(){
        while (true){
            try {
                Thread.sleep(0);
                canvasDib.repaint();
            } catch (InterruptedException ex) {
                Logger.getLogger(FrmGame.class.getName()).log(Level.SEVERE, null, ex);
            }           
        }
    }
}
