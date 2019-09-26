package ksu.team4.incomm.viewmodel;


import android.arch.lifecycle.ViewModel;
import android.content.Context;
import android.support.v7.widget.LinearLayoutManager;

import ksu.team4.incomm.adapters.RecyclerViewAdapter;
import ksu.team4.incomm.model.MainModel;

public class MainViewModel extends ViewModel {

    //public ObservableArrayMap<String, String> cells;
    private MainModel mainModel;

    public LinearLayoutManager accountListLayoutMan;
    public RecyclerViewAdapter rvAdapter;
    public final Context vmContext;

    public MainViewModel(Context c) {
        mainModel = new MainModel();
        vmContext = c;
        accountListLayoutMan = new LinearLayoutManager(vmContext, LinearLayoutManager.HORIZONTAL, false);
        rvAdapter = new RecyclerViewAdapter(vmContext, mainModel.mAccounts);
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
