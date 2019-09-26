package husaynhakeem.io.tictactoe_mvvm.game;


import org.junit.Before;
import org.junit.Test;

import husaynhakeem.io.tictactoe_mvvm.model.MainModel;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

public class MainModelHorizontalCellsShould {

    private MainModel mainModel;
    private Player player;
    private Player anotherPlayer;

    @Before
    public void setUp() throws Exception {
        mainModel = new MainModel("Husayn", "Yasin");
        player = mainModel.player1;
        anotherPlayer = mainModel.player2;
    }

    @Test
    public void returnTrueIfHasThreeSameHorizontalCellsAtRow1() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[0][0] = cell;
        mainModel.cells[0][1] = cell;
        mainModel.cells[0][2] = cell;
        boolean hasThreeSameHorizontalCells = mainModel.hasThreeSameHorizontalCells();
        assertTrue(hasThreeSameHorizontalCells);
    }

    @Test
    public void returnTrueIfHasThreeSameHorizontalCellsAtRow2() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[1][0] = cell;
        mainModel.cells[1][1] = cell;
        mainModel.cells[1][2] = cell;
        boolean hasThreeSameHorizontalCells = mainModel.hasThreeSameHorizontalCells();
        assertTrue(hasThreeSameHorizontalCells);
    }

    @Test
    public void returnTrueIfHasThreeSameHorizontalCellsAtRow3() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[2][0] = cell;
        mainModel.cells[2][1] = cell;
        mainModel.cells[2][2] = cell;
        boolean hasThreeSameHorizontalCells = mainModel.hasThreeSameHorizontalCells();
        assertTrue(hasThreeSameHorizontalCells);
    }

    @Test
    public void returnFalseIfDoesNotHaveThreeSameHorizontalCells() throws Exception {
        Cell cell = new Cell(player);
        Cell anotherCell = new Cell(anotherPlayer);
        mainModel.cells[0][0] = cell;
        mainModel.cells[0][1] = cell;
        mainModel.cells[0][2] = anotherCell;
        boolean hasThreeSameHorizontalCells = mainModel.hasThreeSameHorizontalCells();
        assertFalse(hasThreeSameHorizontalCells);
    }
}
