package ksu.io.incomm.game;


import org.junit.Before;
import org.junit.Test;

import ksu.io.incomm.model.MainModel;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

public class MainModelVerticalCellsShould {

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
    public void returnTrueIfHasThreeSameVerticalCellsAtColumn1() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[0][0] = cell;
        mainModel.cells[1][0] = cell;
        mainModel.cells[2][0] = cell;
        boolean hasThreeSameVerticalCells = mainModel.hasThreeSameVerticalCells();
        assertTrue(hasThreeSameVerticalCells);
    }

    @Test
    public void returnTrueIfHasThreeSameVerticalCellsAtColumn2() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[0][1] = cell;
        mainModel.cells[1][1] = cell;
        mainModel.cells[2][1] = cell;
        boolean hasThreeSameVerticalCells = mainModel.hasThreeSameVerticalCells();
        assertTrue(hasThreeSameVerticalCells);
    }

    @Test
    public void returnTrueIfHasThreeSameVerticalCellsAtColumn3() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[0][2] = cell;
        mainModel.cells[1][2] = cell;
        mainModel.cells[2][2] = cell;
        boolean hasThreeSameVerticalCells = mainModel.hasThreeSameVerticalCells();
        assertTrue(hasThreeSameVerticalCells);
    }

    @Test
    public void returnFalseIfDoesNotHaveThreeSameVerticalCells() throws Exception {
        Cell cell = new Cell(player);
        Cell anotherCell = new Cell(anotherPlayer);
        mainModel.cells[0][0] = cell;
        mainModel.cells[1][0] = cell;
        mainModel.cells[2][0] = anotherCell;
        boolean hasThreeSameVerticalCells = mainModel.hasThreeSameVerticalCells();
        assertFalse(hasThreeSameVerticalCells);
    }
}
