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
 
 * 
 */
public class Escena1 extends JFrame{
    private Thread thread;
    private CrearFondo crearFondo;
    
    public Escena1(){
       
        JugadorController jugadorController = new JugadorController();
        addKeyListener(jugadorController);
        setFocusable(true);
        
        this.crearFondo = new CrearFondo();
        add(crearFondo);
        
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
                crearFondo.repaint();
                Thread.sleep(10);//41   Los sleep para tratar de minimizar el trabajo del procesador
                crearFondo.repaint();
//                jugadorController.setX(x);
                int x=crearFondo.getX_player()+5;
                if(x>=800){
                    x=0;
                }
                crearFondo.setX_player(x);
                crearFondo.repaint();
                Thread.sleep(10);
                crearFondo.repaint();
            } catch (InterruptedException ex) {
                Logger.getLogger(Escena1.class.getName()).log(Level.SEVERE, null, ex);
            } 
        }
    }
}
