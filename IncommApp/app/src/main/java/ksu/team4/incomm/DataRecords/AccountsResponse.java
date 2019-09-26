package ksu.team4.incomm.DataRecords;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class AccountsResponse {
    @SerializedName("accounts")
    public List<Account> mAccounts;

}
