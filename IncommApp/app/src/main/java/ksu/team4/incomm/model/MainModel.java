package ksu.team4.incomm.model;


import android.util.Log;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import ksu.team4.incomm.DataRecords.Account;
import ksu.team4.incomm.R;
import ksu.team4.incomm.utilities.IncommApi;
import okhttp3.Interceptor;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.Response;

public class MainModel {

    private static final String TAG = MainModel.class.getSimpleName();

    //public MutableLiveData<Player> winner = new MutableLiveData<>();
    public ArrayList<Account> mAccounts = new ArrayList<Account>();
    private IncommApi incomm = new IncommApi();

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

        //List<Account> accounts = incomm.getAccounts();
        //Log.d(TAG, "MainModel: retreived accounts " + accounts.toString());

    }


}
