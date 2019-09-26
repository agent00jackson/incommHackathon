package ksu.team4.incomm.game;


import org.junit.Before;
import org.junit.Test;

import ksu.team4.incomm.model.MainModel;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

public class MainModelDiagonalCellsShould {

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
    public void returnTrueIfHasThreeSameDiagonalCellsFromLeft() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[0][0] = cell;
        mainModel.cells[1][1] = cell;
        mainModel.cells[2][2] = cell;
        boolean hasThreeSameDiagonalCells = mainModel.hasThreeSameDiagonalCells();
        assertTrue(hasThreeSameDiagonalCells);
    }

    @Test
    public void returnTrueIfHasThreeSameDiagonalCellsFromRight() throws Exception {
        Cell cell = new Cell(player);
        mainModel.cells[0][2] = cell;
        mainModel.cells[1][1] = cell;
        mainModel.cells[2][0] = cell;
        boolean hasThreeSameDiagonalCells = mainModel.hasThreeSameDiagonalCells();
        assertTrue(hasThreeSameDiagonalCells);
    }

    @Test
    public void returnFalseIfDoesNotHaveThreeSameDiagonalCells() throws Exception {
        Cell cell = new Cell(player);
        Cell anotherCell = new Cell(anotherPlayer);
        mainModel.cells[0][2] = cell;
        mainModel.cells[1][1] = cell;
        mainModel.cells[2][0] = anotherCell;
        boolean hasThreeSameDiagonalCells = mainModel.hasThreeSameDiagonalCells();
        assertFalse(hasThreeSameDiagonalCells);
    }
}
