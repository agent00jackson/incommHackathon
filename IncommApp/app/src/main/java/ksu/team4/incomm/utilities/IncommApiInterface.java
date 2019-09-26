package ksu.team4.incomm.utilities;

import ksu.team4.incomm.DataRecords.AccountsResponse;
import retrofit2.Call;
import retrofit2.http.GET;

public interface IncommApiInterface {
    @GET("/accounts")
    Call<AccountsResponse> getAccounts();
}
