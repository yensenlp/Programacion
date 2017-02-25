/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package prooofconcept2d;

import java.awt.BorderLayout;
import javax.swing.JFrame;
import javax.swing.JPanel;

/**
 *
 * @author servkey
 */
public class ProoOfConcept2D {

    /**
     * @param args the command line arguments
     */
    
    public static void main(String[] args) {
        CanvasDib canvas = new CanvasDib();
        FrmGame frameGame = new FrmGame(canvas);
        frameGame.setSize(800, 600);
       
        frameGame.setVisible(true);
        frameGame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
     }
}
