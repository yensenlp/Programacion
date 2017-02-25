/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package prooofconcept2d;

import java.awt.BorderLayout;
import java.awt.event.ComponentListener;
import javax.swing.JFrame;
import javax.swing.JPanel;

/**
 *
 * @author servkey
 */
public class Principal {

    /**
     * @param args the command line arguments
     */
    
    public static void main(String[] args) {
        Escena1 escena1 = new Escena1();
        JugadorController jugadorController = new JugadorController();
        escena1.addKeyListener(jugadorController);
        escena1.setSize(800, 260);
       
        escena1.setVisible(true);
        escena1.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
     }
}
