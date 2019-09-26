package ksu.team4.incomm.viewmodel;


import android.arch.lifecycle.ViewModel;

import ksu.team4.incomm.model.MainModel;

public class MainViewModel extends ViewModel {

    //public ObservableArrayMap<String, String> cells;
    private MainModel mainModel;

    public void init() {
        mainModel = new MainModel();
    }

//    public void onClickedCellAt(int row, int column) {
//        if (mainModel.cells[row][column] == null) {
//            mainModel.cells[row][column] = new Cell(mainModel.currentPlayer);
//            cells.put(stringFromNumbers(row, column), mainModel.currentPlayer.value);
//            if (mainModel.hasGameEnded())
//                mainModel.reset();
//            else
//                mainModel.switchPlayer();
//        }
//    }

//    public LiveData<Player> getWinner() {
//        return mainModel.winner;
//    }
}
