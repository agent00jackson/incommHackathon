package ksu.team4.incomm.DataRecords;

import com.google.gson.annotations.SerializedName;

import ksu.team4.incomm.R;

public class Account {
    public final int mImageId;

    @SerializedName("id")
    public String mId;

    @SerializedName("balance")
    public int mBalance;

    @SerializedName("owner")
    public String mOwner;

    public Account(int mImageId)
    {
        this.mImageId = mImageId;
    }

    public Account(String id, int balance, String owner)
    {
        mBalance = balance;
        mOwner = owner;
        mId = id;
        mImageId = R.drawable.cfa;
    }
}
