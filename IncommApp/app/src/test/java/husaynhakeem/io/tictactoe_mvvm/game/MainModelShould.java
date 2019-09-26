package husaynhakeem.io.tictactoe_mvvm.game;


import android.arch.core.executor.testing.InstantTaskExecutorRule;

import org.junit.Before;
import org.junit.Rule;
import org.junit.Test;

import husaynhakeem.io.tictactoe_mvvm.model.MainModel;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

public class MainModelShould {

    @Rule
    public InstantTaskExecutorRule instantTaskExecutorRule = new InstantTaskExecutorRule();

    private MainModel mainModel;
    private Player player;

    @Before
    public void setUp() throws Exception {
        mainModel = new MainModel("Husayn", "Yasin");
        player = mainModel.player1;
    }

    @Test
    public void endGameIfHasThreeSameHorizontalCells() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[0][0] = cell;
        mainModel.cells[0][1] = cell;
        mainModel.cells[0][2] = cell;
        boolean hasGameEnded = mainModel.hasGameEnded();
        assertTrue(hasGameEnded);
    }

    @Test
    public void endGameIfHasThreeSameVerticalCells() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[0][0] = cell;
        mainModel.cells[1][0] = cell;
        mainModel.cells[2][0] = cell;
        boolean hasGameEnded = mainModel.hasGameEnded();
        assertTrue(hasGameEnded);
    }

    @Test
    public void endGameIfHasThreeSameDiagonalCells() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[0][0] = cell;
        mainModel.cells[1][1] = cell;
        mainModel.cells[2][2] = cell;
        boolean hasGameEnded = mainModel.hasGameEnded();
        assertTrue(hasGameEnded);
    }

    @Test
    public void endGameIfBoardIsFull() throws Exception {
        Cell cell1 = new Cell(new Player("1", "x"));
        Cell cell2 = new Cell(new Player("2", "o"));
        Cell cell3 = new Cell(new Player("1", "x"));
        Cell cell4 = new Cell(new Player("2", "o"));
        Cell cell5 = new Cell(new Player("1", "x"));
        Cell cell6 = new Cell(new Player("2", "o"));
        Cell cell7 = new Cell(new Player("1", "x"));
        Cell cell8 = new Cell(new Player("2", "o"));
        Cell cell9 = new Cell(new Player("1", "x"));

        mainModel.cells[0][0] = cell1;
        mainModel.cells[0][1] = cell2;
        mainModel.cells[0][2] = cell3;
        mainModel.cells[1][0] = cell4;
        mainModel.cells[1][1] = cell5;
        mainModel.cells[1][2] = cell6;
        mainModel.cells[2][0] = cell7;
        mainModel.cells[2][1] = cell8;
        mainModel.cells[2][2] = cell9;

        boolean isBoardFull = mainModel.isBoardFull();
        assertTrue(isBoardFull);
    }

    @Test
    public void switchFromPlayer1ToPlayer2() throws Exception {
        mainModel.currentPlayer = mainModel.player1;
        mainModel.switchPlayer();
        assertEquals(mainModel.player2, mainModel.currentPlayer);
    }
}
