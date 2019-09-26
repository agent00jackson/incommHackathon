package ksu.team4.incomm.model;


import java.util.ArrayList;

import ksu.team4.incomm.DataRecords.Account;
import ksu.team4.incomm.R;

public class MainModel {

    private static final String TAG = MainModel.class.getSimpleName();

    //public MutableLiveData<Player> winner = new MutableLiveData<>();
    public ArrayList<Account> mAccounts = new ArrayList<Account>();

    public MainModel() {
        mAccounts.add(new Account(R.drawable.cfa));
        mAccounts.add(new Account(R.drawable.cfa));
        mAccounts.add(new Account(R.drawable.cfa));
        mAccounts.add(new Account(R.drawable.sbux));
        mAccounts.add(new Account(R.drawable.sbux));
        mAccounts.add(new Account(R.drawable.sbux));
        mAccounts.add(new Account(R.drawable.cfa));
        mAccounts.add(new Account(R.drawable.cfa));
        mAccounts.add(new Account(R.drawable.sbux));

    }


}
